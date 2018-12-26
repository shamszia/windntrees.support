using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using DataAccess.Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Core.Repositories
{
    public class LicenseInfoRepository : EntityRepository<LicenseInfo>
    {
        public LicenseInfoRepository(ApplicationContext dbContext, string relatedObjects = "", bool enableLazyLoading = false) 
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override IQueryable<LicenseInfo> QueryRecords(IQueryable<LicenseInfo> query, SearchFilter searchQuery = null)
        {
            Expression<Func<LicenseInfo, bool>> condition = null;
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
            }
            return query;
        }

        protected override IOrderedQueryable<LicenseInfo> SortRecords(IQueryable<LicenseInfo> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<LicenseInfo> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.Code);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.Code);
                }
            }
            return orderInterface;
        }
    }
}
