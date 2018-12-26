using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using DataAccess.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Core.Repositories
{
    public class ProductRepository : EntityRepository<Product>
    {
        private IConfiguration Configuration { get; set; }

        public ProductRepository(ApplicationContext dbContext, string relatedObjects = "", bool enableLazyLoading = false, IConfiguration configuration = null)
            : base(dbContext, relatedObjects, enableLazyLoading)
        {
            Configuration = configuration;
        }

        protected override Product GenerateNewKey(Product contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Product> QueryRecords(IQueryable<Product> query, SearchFilter searchQuery = null)
        {
            Expression<Func<Product, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.key))
                {
                    condition = l => (l.Manufacturer == searchQuery.key);
                    query = query.Where(condition);
                }

                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Name.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword) || l.Color.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }
            return query;
        }

        protected override IOrderedQueryable<Product> SortRecords(IQueryable<Product> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<Product> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.Name);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.Name);
                }
            }
            return orderInterface;
        }

        public Product GetProductByID(string id)
        {
            try
            {
                Guid uid = Guid.Parse(id);
                using (ApplicationContext dbContext = new ApplicationContext())
                {
                    var product = dbContext.Product.Where(l => l.Uid == uid).SingleOrDefault();
                    return product;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProductByName(string name)
        {
            try
            {
                using (ApplicationContext dbContext = new ApplicationContext())
                {
                    var product = dbContext.Product.Where(l => l.Name == name).FirstOrDefault();
                    return product;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
