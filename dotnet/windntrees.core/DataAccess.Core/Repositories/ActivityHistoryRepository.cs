using System;
using System.Linq;
using System.Linq.Expressions;
using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using DataAccess.Core.Models;

namespace DataAccess.Core.Repositories
{
    public class ActivityHistoryRepository : EntityRepository<ActivityHistory>
    {
        public ActivityHistoryRepository(ApplicationContext dbContext, string relatedObjects = "", bool enableLazyLoading = false) 
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override ActivityHistory GenerateNewKey(ActivityHistory contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<ActivityHistory> QueryRecords(IQueryable<ActivityHistory> query, SearchFilter searchQuery = null)
        {
            Expression<Func<ActivityHistory, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.key))
                {
                    condition = l => (l.UserId == searchQuery.key);
                    query = query.Where(condition);
                }

                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Activity.Contains(searchQuery.keyword) || l.Request.Contains(searchQuery.keyword) || l.Ipaddress.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<ActivityHistory> SortRecords(IQueryable<ActivityHistory> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<ActivityHistory> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.ActivityTime).ThenBy(l => l.Ipaddress);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.ActivityTime).ThenBy(l => l.Ipaddress);
                }
            }
            return orderInterface;
        }
    }
}
