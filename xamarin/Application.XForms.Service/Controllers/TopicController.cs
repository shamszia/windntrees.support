using Microsoft.EntityFrameworkCore;
using WindnTrees.Abstraction.Core.Controllers;
using WindnTrees.CRUDS.Repository.Core;
using WindnTreesSEO.Models.Database.Repositories;
using WindnTreesSEO.Models.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using WindnTrees.ICRUDS.Standard;

namespace WindnTreesSEO.Controllers
{
    public class TopicController : CRUDLController<Topic>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override EntityRepository<Topic> GetRepository()
        {
            return new TopicRepository((ApplicationContext)GetDBContext());
        }

        public override JsonResult Create([FromBody] Topic contentObject)
        {
            try
            {
                return base.Create(contentObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override JsonResult Update([FromBody] Topic contentObject)
        {
            try
            {
                return base.Update(contentObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override JsonResult Delete([FromBody] Topic contentObject)
        {
            try
            {
                return base.Delete(contentObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override JsonResult List([FromBody] WebInput webInput)
        {
            try
            {
                return base.List(webInput);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}