using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Abstraction.Results;
using Abstraction.Filters;
using Abstraction.Repository;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class CompanyRepository : EntityRepository<Company>
    {
        public CompanyRepository(DatabaseContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override Company GenerateNewKey(Company contentObject)
        {
            contentObject.UID = Guid.NewGuid();
            contentObject.Enabled = true;

            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Company> QueryRecords(IQueryable<Company> query, SearchFilter searchQuery = null)
        {
            Expression<Func<Company, bool>> condition = null;

            query = query.Where(l => l.Enabled == true);

            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.UID.ToString().Contains(searchQuery.keyword) || l.LegalCode.Contains(searchQuery.keyword) || l.LegalName.Contains(searchQuery.keyword) || l.NTN.Contains(searchQuery.keyword) || l.STRN.Contains(searchQuery.keyword) || l.Director.Contains(searchQuery.keyword) || l.ContactPerson.Contains(searchQuery.keyword) || l.Phone1.Contains(searchQuery.keyword) || l.Phone2.Contains(searchQuery.keyword) || l.Cell1.Contains(searchQuery.keyword) || l.Cell2.Contains(searchQuery.keyword) || l.Email.Contains(searchQuery.keyword) || l.ContactPersonPhone.Contains(searchQuery.keyword) || l.ContactPersonCell.Contains(searchQuery.keyword) || l.ContactPersonCell.Contains(searchQuery.keyword) || l.ContactPersonEmail.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<Company> SortRecords(IQueryable<Company> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<Company> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.LegalName);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.LegalName);
                }
            }
            return orderInterface;
        }
    }
}
