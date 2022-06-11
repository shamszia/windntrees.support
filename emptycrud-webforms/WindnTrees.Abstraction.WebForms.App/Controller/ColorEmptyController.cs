using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WindnTrees.Abstraction.WebForms.App.DataAccess;
using WindnTrees.Abstraction.WebForms.Controllers;
using WindnTrees.CRUDS.Repository;

namespace WindnTrees.Abstraction.WebForms.App.Controller
{
    public class ColorEmptyController : EmptyCRUDLController<Color>
    {
        public ColorEmptyController()
        {
            m_TargetRedirection = true;
        }

        protected override CRUDLMEmptyRepository<Color> GetRepository()
        {
            return new ColorEmptyRepository();
        }

        protected override DbContext GetDBContext()
        {
            return new webapplication7Entities();
        }

        //controller target (CRUDMethod)

        [HttpPost]
        public Results.ResultObject<Color> CreateCRUD()
        {
            return base.Create();
        }

        [HttpGet]
        public Results.ResultObject<Color> ReadCRUD()
        {
            return base.Read();
        }

        [HttpPost]
        public Results.ResultObject<Color> UpdateCRUD()
        {
            return base.Update();
        }

        [HttpPost]
        public Results.ResultObject<Color> DeleteCRUD()
        {
            return base.Delete();
        }

        [HttpPost]
        public Results.ResultList<Color> ListCRUD()
        {
            return base.List();
        }
    }
}
