using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using Abstraction.Core.Results;
using DataAccess.Core;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_users")]
    public class CompanyController : CRUDController<Company>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<Company> GetRepository()
        {
            RepositoryContent = new CompanyRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }

        public IActionResult Index()
        {
            return View();
        }

        public override JsonResult Create([FromBody] Company contentObject)
        {
            contentObject.Enabled = true;
            return base.Create(contentObject);
        }

        public override JsonResult Update([FromBody] Company contentObject)
        {
            contentObject.Enabled = true;
            return base.Update(contentObject);
        }

        public override JsonResult Delete([FromBody] Company contentObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contentObject.Enabled = false;
                    Repository.Update(contentObject, contentObject.Uid.ToString());

                    return GetObjectResult(contentObject, null, false);
                }
            }
            catch (Exception ex)
            {
                return GetObjectResultWithException(null, ex);
            }

            return GetObjectResult(contentObject, GetModelStateErrors(), false);
        }
    }
}