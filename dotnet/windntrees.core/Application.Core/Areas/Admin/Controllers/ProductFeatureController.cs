using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using DataAccess.Core;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_users")]
    public class ProductFeatureController : CRUDController<ProductFeature>
    {
        public ActionResult Index(string id)
        {
            if (id != null)
            {
                ViewData.Add(new KeyValuePair<string, object>("TransactionID", id));
            }
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<ProductFeature> GetRepository()
        {
            RepositoryContent = new ProductFeatureRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }
    }
}