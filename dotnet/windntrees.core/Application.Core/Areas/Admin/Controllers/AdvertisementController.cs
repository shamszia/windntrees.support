using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using DataAccess.Core;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Application.Core.Models.Configuration;
using Microsoft.Extensions.Options;
using DataAccess.Core.Models;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_advertisements")]
    public class AdvertisementController : CRUDController<Advertisement>
    {
        private ApplicationSettings applicationSettings;

        public AdvertisementController(IOptions<ApplicationSettings> options)
        {
            applicationSettings = options.Value;

            FilesExtensionsLimit = applicationSettings.AllowedExtensions;
            FileLengthLimit = int.Parse(applicationSettings.MaxFileSizeInKB);

            RootPath = Startup.ENV.WebRootPath;
        }

        // GET: Admin/Advertisement
        public IActionResult Index(string id)
        {
            if (id != null)
            {
                ViewData.Add(new KeyValuePair<string, object>("ReferenceId", id));
            }

            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<Advertisement> GetRepository()
        {
            RepositoryContent = new AdvertisementRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult Create(
            [Bind(include: new string[] {"ReferenceId","Heading","SubHeading","Detail","Picture","Video","Link1","Link2","Source","Page","Location","SortOrder","News","Enabled" })]
            [FromBody] Advertisement contentObject)
        {
            contentObject.RecordTime = DateTime.UtcNow;
            contentObject.UpdateTime = DateTime.UtcNow;

            return base.Create(contentObject);
        }

        public override JsonResult Update(
            [Bind(include: new string[] { "Uid", "ReferenceId", "RecordTime", "UpdateTime", "Heading","SubHeading","Detail","Picture","Video","Link1","Link2","Source","Page","Location","SortOrder","News","Enabled", "RowVersion" })]
            [FromBody] Advertisement contentObject)
        {
            contentObject.UpdateTime = DateTime.UtcNow;
            return base.Update(contentObject);
        }

        protected override Boolean SaveUpload(Object recordId, string fileName, string uploadType = null)
        {
            try
            {
                var record = Repository.Get(recordId);

                if (uploadType != null)
                {
                    if (uploadType.Equals("image", StringComparison.OrdinalIgnoreCase))
                    {
                        record.Picture = fileName;
                    }
                    else if (uploadType.Equals("video", StringComparison.OrdinalIgnoreCase))
                    {
                        record.Video = fileName;
                    }
                }
                else
                {
                    record.Picture = fileName;
                }

                //extend repository with direct query to update required fields.
                Repository.Update(record);

                return true;
            }
            catch (Exception ex)
            {
                MessageNotifier.notifyException(this, ex.Message);
            }

            return false;
        }

        public override JsonResult CreateContent(
            [Bind(include: new string[] { "ReferenceId", "Heading","SubHeading","Detail","Picture","Video","Link1","Link2","Source","Page","Location","SortOrder","News","Enabled" })]
            [FromForm] Advertisement contentObject)
        {
            contentObject.RecordTime = DateTime.UtcNow;
            contentObject.UpdateTime = DateTime.UtcNow;

            StringValues newsValue = string.Empty;
            Request.Form.TryGetValue("News", out newsValue);
            string news = newsValue.ToString();

            if (news != null)
            {
                if (news.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.News = true;
                    if (ModelState.Remove("News"))
                    {
                        ModelState.SetModelValue("News", new ValueProviderResult("true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            StringValues enabledValue = string.Empty;
            Request.Form.TryGetValue("Enabled", out enabledValue);
            string enabled = enabledValue.ToString();

            if (enabled != null)
            {
                if (enabled.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Enabled = true;
                    if (ModelState.Remove("Enabled"))
                    {
                        ModelState.SetModelValue("Enabled", new ValueProviderResult("true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            return base.CreateContent(contentObject);
        }

        public override JsonResult UpdateContent(
            [Bind(include: new string[] { "Uid", "ReferenceId", "RecordTime", "UpdateTime", "Heading","SubHeading","Detail","Picture","Video","Link1","Link2","Source","Page","Location","SortOrder","News","Enabled", "RowVersion" })]
            [FromForm] Advertisement contentObject)
        {

            contentObject.UpdateTime = DateTime.UtcNow;

            StringValues newsValue = string.Empty;
            Request.Form.TryGetValue("News", out newsValue);
            string news = newsValue.ToString();

            if (news != null)
            {
                if (news.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.News = true;
                    if (ModelState.Remove("News"))
                    {
                        ModelState.SetModelValue("News", new ValueProviderResult("true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            StringValues enabledValue = string.Empty;
            Request.Form.TryGetValue("Enabled", out enabledValue);
            string enabled = enabledValue.ToString();

            if (enabled != null)
            {
                if (enabled.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Enabled = true;
                    if (ModelState.Remove("Enabled"))
                    {
                        ModelState.SetModelValue("Enabled", new ValueProviderResult("true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            return base.UpdateContent(contentObject);
        }

        protected override Advertisement SaveNewContent(Advertisement contentObject, string uploadType = "", string fileName = null, long size = 0, MemoryStream fileStream = null)
        {   
            if (uploadType != null)
            {
                if (uploadType.Equals("image", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Picture = fileName;
                }
                else if (uploadType.Equals("video", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Video = fileName;
                }
            }
            else
            {
                contentObject.Picture = fileName;
            }

            Repository.Create(contentObject);

            return contentObject;
        }

        protected override Advertisement SaveExistingContent(Advertisement contentObject, string uploadType = "", string fileName = null, long size = 0, MemoryStream fileStream = null)
        {
            if (contentObject != null)
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    if (uploadType != null)
                    {
                        if (uploadType != null)
                        {
                            if (uploadType.Equals("image", StringComparison.OrdinalIgnoreCase))
                            {
                                contentObject.Picture = fileName;
                            }
                            else if (uploadType.Equals("video", StringComparison.OrdinalIgnoreCase))
                            {
                                contentObject.Video = fileName;
                            }
                        }
                        else
                        {
                            contentObject.Picture = fileName;
                        }
                    }
                }
            }

            Repository.Update(contentObject, contentObject.Uid.ToString());
            return contentObject;
        }
    }
}