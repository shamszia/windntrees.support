using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Abstraction.Controllers;
using System.IO;
using System.Data.Entity;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_advertisements")]
    public class AdvertisementController : CRUDController<Advertisement>
    {
        // GET: Admin/Advertisement
        public ActionResult Index(string id)
        {
            if (id != null)
            {
                ViewData.Add(new KeyValuePair<string, object>("ReferenceID", id));
            }

            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Advertisement> GetRepository()
        {
            RepositoryContent = new AdvertisementRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult Create(
            [Bind(Include = "ReferenceID,Heading,SubHeading,Detail,Picture,Video,Link1,Link2,Source,Page,Location,SortOrder,News,Enabled")]
            Advertisement contentObject)
        {
            contentObject.RecordTime = DateTime.UtcNow;
            contentObject.UpdateTime = DateTime.UtcNow;

            return base.Create(contentObject);
        }

        public override JsonResult Update(
            [Bind(Include = "UID,ReferenceID,RecordTime,UpdateTime,Heading,SubHeading,Detail,Picture,Video,Link1,Link2,Source,Page,Location,SortOrder,News,Enabled,RowVersion")]
            Advertisement contentObject)
        {
            contentObject.UpdateTime = DateTime.UtcNow;
            return base.Update(contentObject);
        }

        protected override Boolean SaveFile(Object recordId, string fileName, string uploadType = null)
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
            [Bind(Include = "Heading,ReferenceID,SubHeading,Detail,Picture,Video,Link1,Link2,Source,Page,Location,SortOrder,News,Enabled")]
            Advertisement contentObject)
        {
            contentObject.RecordTime = DateTime.UtcNow;
            contentObject.UpdateTime = DateTime.UtcNow;

            if (Request.Form.Get("News") != null)
            {
                if (Request.Form.Get("News").Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.News = true;
                    if (ModelState.Remove("News"))
                    {
                        ModelState.SetModelValue("News", new ValueProviderResult(false, "true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            if (Request.Form.Get("Enabled") != null)
            {
                if (Request.Form.Get("Enabled").Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Enabled = true;
                    if (ModelState.Remove("Enabled"))
                    {
                        ModelState.SetModelValue("Enabled", new ValueProviderResult(false, "true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            return base.CreateContent(contentObject);
        }

        public override JsonResult UpdateContent(
            [Bind(Include = "UID,ReferenceID,RecordTime,UpdateTime,Heading,SubHeading,Detail,Picture,Video,Link1,Link2,Source,Page,Location,SortOrder,News,Enabled,RowVersion")]
            Advertisement contentObject)
        {

            contentObject.UpdateTime = DateTime.UtcNow;

            if (Request.Form.Get("News") != null)
            {
                if (Request.Form.Get("News").Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.News = true;
                    if (ModelState.Remove("News"))
                    {
                        ModelState.SetModelValue("News", new ValueProviderResult(false, "true", System.Threading.Thread.CurrentThread.CurrentCulture));
                    }
                }
            }

            if (Request.Form.Get("Enabled") != null)
            {
                if (Request.Form.Get("Enabled").Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    contentObject.Enabled = true;
                    if (ModelState.Remove("Enabled"))
                    {
                        ModelState.SetModelValue("Enabled", new ValueProviderResult(false, "true", System.Threading.Thread.CurrentThread.CurrentCulture));
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

            Repository.Update(contentObject);

            return contentObject;
        }
    }
}