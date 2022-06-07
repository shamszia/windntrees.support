using System;
using System.Linq;
using WindnTrees.ICRUDS;
using System.Linq.Expressions;
using Application.Models.Standard.DataAccess;
using WindnTrees.CRUDS.Repository;
using Application.WCF.Server.DataAccess;

namespace Application.WCF.Server.Repositories
{
    public class ProductFeatureRepository : ServiceRepository<ProductFeature>
    {
        public ProductFeatureRepository()
            : base(new ApplicationEntities())
        {

        }

        public ProductFeatureRepository(ApplicationEntities dbContext, string relatedObjects = "", bool enableLazyLoading = false) 
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override ProductFeature GenerateNewKey(ProductFeature contentObject)
        {
            contentObject.UID = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<ProductFeature> QueryRecords(IQueryable<ProductFeature> query, SearchInput searchQuery = null)
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
                        condition = l => (l.ProductID == key);
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

        protected override IOrderedQueryable<ProductFeature> SortRecords(IQueryable<ProductFeature> query, SearchInput searchQuery = null)
        {
            IOrderedQueryable<ProductFeature> orderInterface = null;
            
            if (searchQuery != null)
            {
                if (searchQuery.ascend != null)
                {
                    if ((bool)searchQuery.ascend)
                    {
                        orderInterface = query.OrderBy(l => l.Name);
                    }
                }
                else if (searchQuery.descend != null)
                {
                    if ((bool)searchQuery.descend)
                    {
                        orderInterface = query.OrderByDescending(l => l.Name);
                    }
                }
            }
            return orderInterface;
        }
    }
}
