using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using Application.Core.Data;
using Application.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Core.Repositories
{
    public class ApplicationRoleRepository : EntityRepository<ApplicationRole>
    {
        public ApplicationRoleRepository(ApplicationDbContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        {   
            
        }

        protected override IQueryable<ApplicationRole> QueryRecords(IQueryable<ApplicationRole> query, SearchFilter searchQuery = null)
        {
            Expression<Func<ApplicationRole, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Id.Contains(searchQuery.keyword) || l.Name.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<ApplicationRole> SortRecords(IQueryable<ApplicationRole> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<ApplicationRole> orderInterface = null;
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
                IQueryable<ApplicationRole> query = entitySet;
                return query.OrderBy(q => q.Id).
                    Select(c => new
                    {
                        Id = c.Id,
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
