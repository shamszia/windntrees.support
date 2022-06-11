using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WindnTrees.ICRUDS;

namespace WindnTrees.Abstraction.WebForms.App.DataAccess
{
    public class EmployeeRepository : WindnTrees.CRUDS.Repository.EntityRepository<Employee>
    {
        public EmployeeRepository()
            : base(new webapplication7Entities(), "", false)
        {

        }

        protected override IQueryable<Employee> QueryRecords(IQueryable<Employee> query, SearchInput queryObject = null)
        {
            queryObject.keyword = string.IsNullOrEmpty(queryObject.keyword) ? string.Empty : queryObject.keyword;
            query = query.Where(l => l.Name.Contains(queryObject.keyword) || l.Designation.Contains(queryObject.keyword));
            return query;
        }

        protected override IOrderedQueryable<Employee> SortRecords(IQueryable<Employee> query, SearchInput queryObject = null)
        {
            return query.OrderBy(l => l.Name);
        }
    }
}