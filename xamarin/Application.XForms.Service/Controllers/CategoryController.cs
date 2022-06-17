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
    public class CategoryController : CRUDLController<Category>
    {
        public CategoryController()
        {
            m_TargetRedirection = true;
        }
 
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override EntityRepository<Category> GetRepository()
        {
            return new CategoryRepository((ApplicationContext)GetDBContext());
        }

        //CRUD

        public override JsonResult Create([FromBody] Category contentObject)
        {
            return base.Create(contentObject);
        }

        public override JsonResult Read(string id)
        {
            return base.Read(id);
        }

        public override JsonResult Update([FromBody] Category contentObject)
        {
            return base.Update(contentObject);
        }

        public override JsonResult Delete([FromBody] Category contentObject)
        {
            return base.Delete(contentObject);
        }

        public override JsonResult List([FromBody] WebInput webInput)
        {
            return base.List(webInput);
        }

        //CRUD Actions

        public JsonResult CreateCRUD([FromBody] Category contentObject)
        {
            return base.Create(contentObject);
        }

        public JsonResult ReadCRUD(string id)
        {
            return base.Read(id);
        }

        public JsonResult UpdateCRUD([FromBody] Category contentObject)
        {
            return base.Update(contentObject);
        }

        public JsonResult DeleteCRUD([FromBody] Category contentObject)
        {
            return base.Delete(contentObject);
        }

        public JsonResult ListCRUD([FromBody] WebInput webInput)
        {
            return base.List(webInput);
        }
    }
}