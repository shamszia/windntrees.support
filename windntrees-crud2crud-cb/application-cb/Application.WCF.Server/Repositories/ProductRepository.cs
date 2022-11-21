using System;
using System.Linq;
using WindnTrees.ICRUDS;
using System.Linq.Expressions;
using WindnTrees.CRUDS.Repository;
using System.Collections.Generic;
using Application.Models.Standard.DataAccess;
using Application.WCF.Server.DataAccess;

namespace Application.WCF.Server.Repositories
{
    public class ProductRepository : ServiceRepository<Product>
    {
        public ProductRepository()
            : base(new ApplicationEntities())
        {

        }

        public ProductRepository(ApplicationEntities dbContext, string relatedObjects = "", bool enableLazyLoading = false)
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

        protected override IQueryable<Product> QueryRecords(IQueryable<Product> query, SearchInput searchQuery = null)
        {
            Expression<Func<Product, bool>> condition = null;
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
            return query;
        }

        protected override IOrderedQueryable<Product> SortRecords(IQueryable<Product> query, SearchInput searchQuery = null)
        {
            IOrderedQueryable<Product> orderInterface = null;

            orderInterface = query.OrderBy(l => l.Name);
            return orderInterface;
        }

        public override List<Product> List(SearchInput queryObject)
        {
            try
            {
                return base.List(queryObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProductByID(string id)
        {
            try
            {
                Guid uid = Guid.Parse(id);
                using (ApplicationEntities dbContext = new ApplicationEntities())
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
                using (ApplicationEntities dbContext = new ApplicationEntities())
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
