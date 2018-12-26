using System;
using System.Linq;
using System.Linq.Expressions;
using Abstraction.Filters;
using Abstraction.Repository;

namespace DataAccess.Repositories
{
    public class RolesRepository : EntityRepository<Role>
    {
        public RolesRepository(DatabaseContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override IQueryable<Role> QueryRecords(IQueryable<Role> query, SearchFilter searchQuery = null)
        {
            Expression<Func<Role, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.RoleId.Contains(searchQuery.keyword) || l.Name.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<Role> SortRecords(IQueryable<Role> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<Role> orderInterface = null;
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

        public virtual Array GetAllRoles()
        {
            try
            {
                IQueryable<Role> query = entitySet;
                return query.OrderBy(q => q.RoleId).
                    Select(c => new
                    {
                        RoleId = c.RoleId,
                        Name = c.Name
                    }).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
