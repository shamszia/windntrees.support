using System;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using System.IO;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class ProductController : CRUDController<Product>
    {
        public ActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Product> GetRepository()
        {
            RepositoryContent = new ProductRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult CreateContent(
            [Bind(Include = "Name,Description,Version,Code,LegalCode,ProductYear,Category,Manufacturer,Unit,Color,Service,Picture")]
            Product contentObject)
        {
            if (Request.Form.Get("Service") != null)
            {
                if (Request.Form.Get("Service").Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Service = true;
                    if (ModelState.Remove("Service"))
                    {
                        ModelState.SetModelValue("Service", new ValueProviderResult(false, "true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            return base.CreateContent(contentObject);
        }

        public override JsonResult UpdateContent(
            [Bind(Include = "UID,Name,Description,Version,Code,LegalCode,ProductYear,Category,Manufacturer,Unit,Color,Service,Picture,RowVersion")]
            Product contentObject)
        {
            if (Request.Form.Get("Service") != null)
            {
                if (Request.Form.Get("Service").Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Service = true;
                    if (ModelState.Remove("Service"))
                    {
                        ModelState.SetModelValue("Service", new ValueProviderResult(false, "true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            return base.UpdateContent(contentObject);
        }

        protected override Product SaveNewContent(Product contentObject, string uploadType = "", string fileName = null, long size = 0, MemoryStream fileStream = null)
        {
            contentObject.Picture = fileName;
            Repository.Create(contentObject);
            return contentObject;
        }

        protected override Product SaveExistingContent(Product contentObject, string uploadType = "", string fileName = null, long size = 0, MemoryStream fileStream = null)
        {
            contentObject.Picture = fileName;
            Repository.Update(contentObject);
            return contentObject;
        }
    }
}