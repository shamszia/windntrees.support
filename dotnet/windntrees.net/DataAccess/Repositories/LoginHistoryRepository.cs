using System;
using System.Linq;
using Abstraction.Filters;
using System.Linq.Expressions;
using Abstraction.Repository;

namespace DataAccess.Repositories
{
    public class LoginHistoryRepository : EntityRepository<LoginHistory>
    {
        public LoginHistoryRepository(DatabaseContext dbContext, string relatedObjects = "", bool enableLazyLoading = false) 
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override LoginHistory GenerateNewKey(LoginHistory contentObject)
        {
            contentObject.UID = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<LoginHistory> QueryRecords(IQueryable<LoginHistory> query, SearchFilter searchQuery = null)
        {
            Expression<Func<LoginHistory, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.key))
                {
                    condition = l => (l.UserID == searchQuery.key);
                    query = query.Where(condition);
                }

                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.IP.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<LoginHistory> SortRecords(IQueryable<LoginHistory> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<LoginHistory> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.LoginTime).ThenBy(l => l.IP);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.LoginTime).ThenBy(l => l.IP);
                }
            }
            return orderInterface;
        }
    }
}
