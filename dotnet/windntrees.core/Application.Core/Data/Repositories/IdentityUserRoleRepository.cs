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
    public class IdentityUserRoleRepository : EntityRepository<IdentityUserRole<string>>
    {
        public IdentityUserRoleRepository(ApplicationDbContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        {   
        }

        protected override IQueryable<IdentityUserRole<string>> QueryRecords(IQueryable<IdentityUserRole<string>> query, SearchFilter searchQuery = null)
        {
            Expression<Func<IdentityUserRole<string>, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.RoleId.Contains(searchQuery.keyword) || l.UserId.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<IdentityUserRole<string>> SortRecords(IQueryable<IdentityUserRole<string>> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<IdentityUserRole<string>> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.RoleId);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.RoleId);
                }
            }
            return orderInterface;
        }

        public virtual Array GetAllRoles()
        {
            try
            {
                IQueryable<IdentityUserRole<string>> query = entitySet;
                return query.OrderBy(q => q.RoleId).
                    Select(c => new
                    {
                        UserId = c.UserId,
                        RoleId = c.RoleId
                    }).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveUserRoles (string userId)
        {
            var identityRoles = entitySet.Where(l => l.UserId == userId).ToArray();
            foreach (var identityRole in identityRoles)
            {
                entitySet.Remove(identityRole);
            }
            context.SaveChanges();
        }

        public void AddUserRole (string userId, string roleId)
        {
            entitySet.Add(new IdentityUserRole<string> { UserId = userId, RoleId = roleId });
            context.SaveChanges();
        }

        public void AddUserRoles(string userId, string[] roles)
        {
            foreach(var role in roles)
            {
                entitySet.Add(new IdentityUserRole<string> { UserId = userId, RoleId = role });
            }

            context.SaveChanges();
        }
    }
}
