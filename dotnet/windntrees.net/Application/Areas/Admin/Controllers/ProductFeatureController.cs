using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
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
            return new DatabaseContext();
        }

        protected override ContentRepository<ProductFeature> GetRepository()
        {
            RepositoryContent = new ProductFeatureRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult Create(
            [Bind(Include = "ProductID,Name,Description")]
            ProductFeature contentObject)
        {
            return base.Create(contentObject);
        }

        public override JsonResult Update(
            [Bind(Include = "UID,ProductID,Name,Description,RowVersion")]
            ProductFeature contentObject)
        {
            return base.Update(contentObject);
        }
    }
}