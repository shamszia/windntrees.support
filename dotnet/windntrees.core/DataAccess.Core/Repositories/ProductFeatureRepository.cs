using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using DataAccess.Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Core.Repositories
{
    public class ProductFeatureRepository : EntityRepository<ProductFeature>
    {
        public ProductFeatureRepository(ApplicationContext dbContext, string relatedObjects = "", bool enableLazyLoading = false) 
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override ProductFeature GenerateNewKey(ProductFeature contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<ProductFeature> QueryRecords(IQueryable<ProductFeature> query, SearchFilter searchQuery = null)
        {
            Expression<Func<ProductFeature, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.key))
                {
                    Nullable<Guid> key = null;
                    try
                    {
                        key = Guid.Parse(searchQuery.key);
                    }
                    catch { }

                    if (key != null)
                    {
                        condition = l => (l.ProductId == key);
                        query = query.Where(condition);
                    }
                }

                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Name.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }
            return query;
        }

        protected override IOrderedQueryable<ProductFeature> SortRecords(IQueryable<ProductFeature> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<ProductFeature> orderInterface = null;
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
    }
}
