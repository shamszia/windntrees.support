using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using Application.Core.Models.Configuration;
using DataAccess.Core;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.IO;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_users")]
    public class ProductController : CRUDController<Product>
    {
        private ApplicationSettings applicationSettings;

        public ProductController(IOptions<ApplicationSettings> options)
        {
            applicationSettings = options.Value;

            FilesExtensionsLimit = applicationSettings.AllowedExtensions;
            FileLengthLimit = int.Parse(applicationSettings.MaxFileSizeInKB);

            RootPath = Startup.ENV.WebRootPath;
        }

        public IActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<Product> GetRepository()
        {
            RepositoryContent = new ProductRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult CreateContent([FromForm] Product contentObject)
        {
            //for model validation will be overriden by repository
            contentObject.Uid = Guid.NewGuid();
            ModelState.Remove("Uid");
            ModelState.SetModelValue("Uid", new ValueProviderResult(contentObject.Uid.ToString(), System.Threading.Thread.CurrentThread.CurrentCulture));

            StringValues ServiceValue = string.Empty;
            Request.Form.TryGetValue("Service", out ServiceValue);
            string Service = ServiceValue.ToString();

            if (Service != null)
            {
                if (Service.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Service = true;
                    if (ModelState.Remove("Service"))
                    {
                        ModelState.SetModelValue("Service", new ValueProviderResult("true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            return base.CreateContent(contentObject);
        }

        public override JsonResult UpdateContent([FromForm] Product contentObject)
        {
            StringValues ServiceValue = string.Empty;
            Request.Form.TryGetValue("Service", out ServiceValue);
            string Service = ServiceValue.ToString();

            if (Service != null)
            {
                if (Service.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Service = true;
                    if (ModelState.Remove("Service"))
                    {
                        ModelState.SetModelValue("Service", new ValueProviderResult("true", System.Threading.Thread.CurrentThread.CurrentCulture));
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
            Repository.Update(contentObject, contentObject.Uid.ToString());
            return contentObject;
        }
    }
}