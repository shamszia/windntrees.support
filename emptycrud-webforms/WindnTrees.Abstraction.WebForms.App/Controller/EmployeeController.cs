using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WindnTrees.Abstraction.WebForms.App.DataAccess;
using WindnTrees.Abstraction.WebForms.Controllers;
using WindnTrees.CRUDS.Repository;

namespace WindnTrees.Abstraction.WebForms.App.Controller
{
    public class EmployeeController : CRUDLController<Employee>
    {
        protected override CRUDLMRepository<Employee> GetRepository()
        {
            return new EmployeeRepository();
        }

    }
}