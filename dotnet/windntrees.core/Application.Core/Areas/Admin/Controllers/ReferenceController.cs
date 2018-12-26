using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using Abstraction.Core.Results;
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
using System.Collections.Generic;
using System.IO;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_users")]
    public class ReferenceController : CRUDController<Reference>
    {
        private ApplicationSettings applicationSettings;

        public ReferenceController(IOptions<ApplicationSettings> options)
        {
            applicationSettings = options.Value;

            FilesExtensionsLimit = applicationSettings.AllowedExtensions;
            FileLengthLimit = int.Parse(applicationSettings.MaxFileSizeInKB);
            RootPath = Startup.ENV.WebRootPath;
        }

        public IActionResult Index(string id)
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

        protected override ContentRepository<Reference> GetRepository()
        {
            RepositoryContent = new ReferenceRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult CreateContent([FromForm] Reference contentObject)
        {
            //for model validation will be overriden by repository
            contentObject.Uid = Guid.NewGuid();
            ModelState.Remove("Uid");
            ModelState.SetModelValue("Uid", new ValueProviderResult(contentObject.Uid.ToString(), System.Threading.Thread.CurrentThread.CurrentCulture));
            

            StringValues DownloadValue = string.Empty;
            Request.Form.TryGetValue("Download", out DownloadValue);
            string Download = DownloadValue.ToString();

            if (Download != null)
            {
                if (Download.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Download = true;
                    if (ModelState.Remove("Download"))
                    {
                        ModelState.SetModelValue("Download", new ValueProviderResult("true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            StringValues SizeValue = string.Empty;
            Request.Form.TryGetValue("Size", out SizeValue);
            string Size = SizeValue.ToString();

            if (string.IsNullOrEmpty(Size))
            {
                contentObject.Size = 0;
                if (ModelState.Remove("Size"))
                {
                    ModelState.SetModelValue("Size", new ValueProviderResult("0", System.Threading.Thread.CurrentThread.CurrentCulture));
                }
            }

            return base.CreateContent(contentObject);
        }

        public override JsonResult UpdateContent([FromForm] Reference contentObject)
        {
            StringValues DownloadValue = string.Empty;
            Request.Form.TryGetValue("Download", out DownloadValue);
            string Download = DownloadValue.ToString();

            if (Download != null)
            {
                if (Download.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Download = true;
                    if (ModelState.Remove("Download"))
                    {
                        ModelState.SetModelValue("Download", new ValueProviderResult("true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            return base.UpdateContent(contentObject);
        }

        protected override Reference SaveNewContent(Reference contentObject, string uploadType = "", string fileName = null, long size = 0, MemoryStream fileStream = null)
        {
            contentObject.ContentFile = fileName;
            contentObject.Size = size;

            contentObject.Readable = false;
            contentObject.Picture = false;
            contentObject.AudioVideo = false;

            if (uploadType != null)
            {
                if (uploadType.Equals("readable", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Readable = true;

                }
                else if (uploadType.Equals("image", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Picture = true;

                }
                else if (uploadType.Equals("video", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.AudioVideo = true;
                }
            }

            if (fileStream != null)
            {
                if (fileStream.Length > 0)
                {
                    contentObject.ContentBytes = fileStream.GetBuffer();
                }
            }

            Repository.Create(contentObject);

            return contentObject;
        }

        protected override Reference SaveExistingContent(Reference contentObject, string uploadType = "", string fileName = null, long size = 0, MemoryStream fileStream = null)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                contentObject.ContentFile = fileName;
                contentObject.Size = size;

                contentObject.Readable = false;
                contentObject.Picture = false;
                contentObject.AudioVideo = false;

                if (uploadType != null)
                {
                    if (uploadType.Equals("readable", StringComparison.OrdinalIgnoreCase))
                    {
                        contentObject.Readable = true;

                    }
                    else if (uploadType.Equals("image", StringComparison.OrdinalIgnoreCase))
                    {
                        contentObject.Picture = true;

                    }
                    else if (uploadType.Equals("video", StringComparison.OrdinalIgnoreCase))
                    {
                        contentObject.AudioVideo = true;
                    }
                }
            }

            if (fileStream != null)
            {
                if (fileStream.Length > 0)
                {
                    contentObject.ContentBytes = fileStream.GetBuffer();
                }
            }

            Repository.Update(contentObject, contentObject.Uid.ToString());

            return contentObject;
        }

        [HttpGet]
        public ActionResult GetContent(string id)
        {
            try
            {
                var content = Repository.Get(id);
                return File(content.ContentBytes, "application/binary", content.ContentFile);
            }
            catch
            {
                List<ObjectError> errors = new List<ObjectError>();
                errors.Add(new ObjectError("exception", GetStandardErrMessage()));
                return Json(new { errors = errors });
            }
        }
    }
}