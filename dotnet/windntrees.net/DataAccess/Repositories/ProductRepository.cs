using System;
using System.Linq;
using Abstraction.Filters;
using System.Linq.Expressions;
using Abstraction.Repository;

namespace DataAccess.Repositories
{
    public class ProductRepository : EntityRepository<Product>
    {
        public ProductRepository(DatabaseContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override Product GenerateNewKey(Product contentObject)
        {
            contentObject.UID = Guid.NewGuid();
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
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    var product = dbContext.Products.Where(l => l.UID == uid).SingleOrDefault();
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
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    var product = dbContext.Products.Where(l => l.Name == name).FirstOrDefault();
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
