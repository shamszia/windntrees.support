using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WindnTrees.Abstraction.Core.Controllers;
using WindnTrees.CRUDS.Repository.Core;
using WindnTrees.ICRUDS.Standard;
using WindnTreesSEO.Models.Database;
using WindnTreesSEO.Models.Database.Repositories;
using Newtonsoft.Json;

namespace WindnTreesSEO.Controllers
{
    public class CategoryEmptyController : EmptyCRUDLController<Category>
    {
        public CategoryEmptyController()
        {
            m_TargetRedirection = true;
        }

        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override CRUDLMEmptyRepository<Category> GetRepository()
        {
            return new CategoryEmptyRepository((ApplicationContext)GetDBContext());
        }

        // GET: CategoryEmpty
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public override JsonResult Create()
        {
            return base.Create();
        }

        [HttpGet]
        public override JsonResult Read()
        {
            return base.Read();
        }

        [HttpGet]
        public override JsonResult Update()
        {
            return base.Update();
        }

        [HttpGet]
        public override JsonResult Delete()
        {
            return base.Delete();
        }

        [HttpGet]
        public override JsonResult List()
        {
            return base.List();
        }


        //controller target (CRUDMethod)

        [HttpGet]
        public JsonResult CreateCRUD()
        {
            return base.Create();
        }

        [HttpGet]
        public JsonResult ReadCRUD()
        {
            return base.Read();
        }

        [HttpGet]
        public JsonResult UpdateCRUD()
        {
            return base.Update();
        }

        [HttpGet]
        public JsonResult DeleteCRUD()
        {
            return base.Delete();
        }

        [HttpGet]
        public JsonResult ListCRUD()
        {
            return base.List();
        }
    }
}
