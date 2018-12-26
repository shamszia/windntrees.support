using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using System.IO;
using Abstraction.Controllers;
using Abstraction.Results;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class ReferenceController : CRUDController<Reference>
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

        protected override ContentRepository<Reference> GetRepository()
        {
            RepositoryContent = new ReferenceRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult CreateContent(
            [Bind(Include = "ReferenceID,Name,Description,ContentFile,Size,Readable,Picture,AudioVideo,Download")]
            Reference contentObject)
        {

            if (Request.Form.Get("Download") != null)
            {
                if (Request.Form.Get("Download").Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Download = true;
                    if (ModelState.Remove("Download"))
                    {
                        ModelState.SetModelValue("Download", new ValueProviderResult(false, "true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            if (Request.Form.Get("Size") != null)
            {
                if (string.IsNullOrEmpty(Request.Form.Get("Size")))
                {
                    contentObject.Size = 0;
                    if (ModelState.Remove("Size"))
                    {
                        ModelState.SetModelValue("Size", new ValueProviderResult(0, "0", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            return base.CreateContent(contentObject);
        }

        public override JsonResult UpdateContent(
            [Bind(Include = "UID,ReferenceID,Name,Description,ContentFile,Size,Readable,Picture,AudioVideo,Download,RowVersion")]
            Reference contentObject)
        {
            if (Request.Form.Get("Download") != null)
            {
                if (Request.Form.Get("Download").Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Download = true;

                    if (ModelState.Remove("Download"))
                    {
                        ModelState.SetModelValue("Download", new ValueProviderResult(false, "true", System.Threading.Thread.CurrentThread.CurrentCulture));
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

            Repository.Update(contentObject);

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
                return Json(new { errors = errors }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}