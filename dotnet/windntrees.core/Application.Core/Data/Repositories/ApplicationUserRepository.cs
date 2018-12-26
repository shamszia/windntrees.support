using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using Abstraction.Core.Results;
using Application.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Core.Data
{
    public class ApplicationUserRepository : EntityRepository<ApplicationUser>
    {
        public ApplicationUserRepository(ApplicationDbContext dbContext, string relatedObjects = "Roles", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override IQueryable<ApplicationUser> QueryRecords(IQueryable<ApplicationUser> query, SearchFilter searchQuery = null)
        {
            Expression<Func<ApplicationUser, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Id.Contains(searchQuery.keyword) || l.UserName.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<ApplicationUser> SortRecords(IQueryable<ApplicationUser> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<ApplicationUser> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.CreationDate);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.CreationDate);
                }
            }
            return orderInterface;
        }

        public PagedRecords<UserRecord> GetPagedUsersWithCount(string filterKeyword = null,
            int pageSize = 10,
            int pageNumber = 1)
        {
            try
            {
                if (filterKeyword == null)
                {
                    using (ApplicationDbContext ctx = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>()))
                    {

                        List<UserRecord> records = (from usr in ctx.Users
                                                    select new UserRecord
                                                    {
                                                        UserId = usr.Id,
                                                        UserName = usr.UserName,
                                                        FirstName = usr.FirstName,
                                                        LastName = usr.LastName,
                                                        Sex = usr.Sex,
                                                        Title = usr.Title,
                                                        ImageFile = usr.ImageFile,
                                                        Package = usr.Package,
                                                        Email = usr.Email,
                                                        EmailConfirmed = usr.EmailConfirmed,
                                                        CreationDate = usr.CreationDate,
                                                        ExpiryDate = usr.ExpiryDate,
                                                        IsApproved = usr.IsApproved,
                                                        ApprovedBy = usr.ApprovedBy,                                                        
                                                        Roles = (from roles in ctx.UserRoles.Where(r => r.UserId == usr.Id) select new RoleRecord { RoleId = roles.RoleId }).ToList()
                                                    }).OrderBy(l => l.CreationDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

                        int count = (from usr in ctx.Users
                                     select usr.Id).Count();
                        return new PagedRecords<UserRecord>(records, count);
                    }
                }
                else
                {
                    using (ApplicationDbContext ctx = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>()))
                    {
                        List<UserRecord> records = (from usr in ctx.Users.Where(l => l.UserName.Contains(filterKeyword) ||
                                                    l.FirstName.Contains(filterKeyword) ||
                                                    l.LastName.Contains(filterKeyword) ||
                                                    l.Email.Contains(filterKeyword))
                                                    select new UserRecord
                                                    {
                                                        UserId = usr.Id,
                                                        UserName = usr.UserName,
                                                        FirstName = usr.FirstName,
                                                        LastName = usr.LastName,
                                                        Sex = usr.Sex,
                                                        Title = usr.Title,
                                                        ImageFile = usr.ImageFile,
                                                        Package = usr.Package,
                                                        Email = usr.Email,
                                                        EmailConfirmed = usr.EmailConfirmed,
                                                        CreationDate = usr.CreationDate,
                                                        ExpiryDate = usr.ExpiryDate,
                                                        IsApproved = usr.IsApproved,
                                                        ApprovedBy = usr.ApprovedBy,
                                                        Roles = (from roles in ctx.UserRoles.Where(r => r.UserId == usr.Id) select new RoleRecord { RoleId = roles.RoleId }).ToList()
                                                    }).OrderBy(l => l.CreationDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

                        int count = (from usr in ctx.Users.Where(l => l.UserName.Contains(filterKeyword) ||
                                                    l.FirstName.Contains(filterKeyword) ||
                                                    l.LastName.Contains(filterKeyword) ||
                                                    l.Email.Contains(filterKeyword))
                                     select usr.Id).Count();
                        return new PagedRecords<UserRecord>(records, count);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplicationUser GetByName(string name)
        {
            ApplicationUser result = PostRead(entitySet.Where(l => l.UserName == name).SingleOrDefault());
            return result;
        }
    }
}
