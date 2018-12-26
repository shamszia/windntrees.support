using System;
using System.Collections.Generic;
using System.Linq;
using Abstraction.Results;
using Abstraction.Filters;
using Abstraction.Repository;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class UserRepository : EntityRepository<User>
    {
        public UserRepository(DatabaseContext dbContext, string relatedObjects = "Roles", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override IQueryable<User> QueryRecords(IQueryable<User> query, SearchFilter searchQuery = null)
        {
            Expression<Func<User, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.UserId.Contains(searchQuery.keyword) || l.UserName.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<User> SortRecords(IQueryable<User> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<User> orderInterface = null;
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
                    using (DatabaseContext ctx = new DatabaseContext())
                    {

                        List<UserRecord> records = (from usr in ctx.Users
                                                    select new UserRecord
                                                    {
                                                        UserId = usr.UserId,
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
                                                        Roles = (from role in ctx.Roles.Where(r => r.Users.Contains(usr)) select new RoleRecord { RoleId = role.RoleId, Name = role.Name }).ToList()
                                                    }).OrderBy(l => l.CreationDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

                        int count = (from usr in ctx.Users
                                     select usr.UserId).Count();
                        return new PagedRecords<UserRecord>(records, count);
                    }
                }
                else
                {
                    using (DatabaseContext ctx = new DatabaseContext())
                    {
                        List<UserRecord> records = (from usr in ctx.Users.Where(l => l.UserName.Contains(filterKeyword) ||
                                                    l.FirstName.Contains(filterKeyword) ||
                                                    l.LastName.Contains(filterKeyword) ||
                                                    l.Email.Contains(filterKeyword))
                                                    select new UserRecord
                                                    {
                                                        UserId = usr.UserId,
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
                                                        Roles = (from role in ctx.Roles.Where(r => r.Users.Contains(usr)) select new RoleRecord { RoleId = role.RoleId, Name = role.Name }).ToList()
                                                    }).OrderBy(l => l.CreationDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

                        int count = (from usr in ctx.Users.Where(l => l.UserName.Contains(filterKeyword) ||
                                                    l.FirstName.Contains(filterKeyword) ||
                                                    l.LastName.Contains(filterKeyword) ||
                                                    l.Email.Contains(filterKeyword))
                                     select usr.UserId).Count();
                        return new PagedRecords<UserRecord>(records, count);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
