using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WindnTrees.ICRUDS;

namespace WindnTrees.Abstraction.WebForms.App.DataAccess
{
    public class EmployeeEmptyRepository : WindnTrees.CRUDS.Repository.EntityEmptyRepository<Employee>
    {
        public EmployeeEmptyRepository()
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

        protected override Employee GetContentForCreate()
        {
            return new Employee
            {
                Id = DateTime.Now.Ticks.ToString(),
                Name = "",
                Designation = "",
                Salary = 1000
            };
        }

        protected override string GetIdForRead()
        {
            var employee = new webapplication7Entities().Employees.FirstOrDefault();
            return employee.Id;
        }

        protected override Employee GetContentForUpdate()
        {
            var employee = new webapplication7Entities().Employees.FirstOrDefault();
            return employee;
        }

        protected override Employee GetContentForDelete()
        {
            var employee = new webapplication7Entities().Employees.FirstOrDefault();
            return employee;
        }

        protected override SearchInput GetConditionsForListing()
        {
            return new SearchInput
            {
                keyword = "",
                page = 1,
                size = 10
            };
        }
    }
}