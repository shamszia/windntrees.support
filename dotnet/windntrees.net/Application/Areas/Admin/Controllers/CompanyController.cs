using System;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using System.Collections.Generic;
using Abstraction.Results;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class CompanyController : CRUDController<Company>
    {
        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Company> GetRepository()
        {
            RepositoryContent = new CompanyRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        public ActionResult Index()
        {
            return View();
        }

        public override JsonResult Delete(Company contentObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contentObject.Enabled = false;
                    Repository.Update(contentObject);

                    return GetObjectResult(contentObject, null, false);
                }
            }
            catch (Exception ex)
            {
                return GetObjectResultWithException(null, ex);
            }

            List<ObjectError> errors = new List<ObjectError>();
            errors.Add(new ObjectError("Company", SharedLibrary.Resources.Global.StandardMessages.Err));

            return GetObjectResult(contentObject, errors, false);
        }
    }
}