using System.Web.Mvc;
using Abstraction.Controllers;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_myaccount,mngr_users")]
    public class ListsController : BasicController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}