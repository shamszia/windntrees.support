using Abstraction.Controllers;
using DataAccess;
using System.Web.Mvc;
using Abstraction.Repository;
using System.Data.Entity;
using DataAccess.Repositories;

namespace Application.Controllers
{
    public class ColorController : CRUDController<Color>
    {
        // GET: Color
        public ActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Color> GetRepository()
        {
            RepositoryContent = new ColorRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }
    }
}