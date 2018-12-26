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
    public class IdentityRoleRepository : EntityRepository<IdentityRole>
    {
        public IdentityRoleRepository(ApplicationDbContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        {   
            
        }

        protected override IQueryable<IdentityRole> QueryRecords(IQueryable<IdentityRole> query, SearchFilter searchQuery = null)
        {
            Expression<Func<IdentityRole, bool>> condition = null;
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

        protected override IOrderedQueryable<IdentityRole> SortRecords(IQueryable<IdentityRole> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<IdentityRole> orderInterface = null;
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
                IQueryable<IdentityRole> query = entitySet;
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
