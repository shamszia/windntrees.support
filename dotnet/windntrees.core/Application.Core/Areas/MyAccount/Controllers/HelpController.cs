using Abstraction.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Application.Core.Areas.MyAccount.Controllers
{
    [Area("MyAccount")]
    public class HelpController : BasicController
    {
        // GET: MyAccount/Help
        public IActionResult Index()
        {
            return Redirect("~/help/index");
        }

        public IActionResult About()
        {
            return Redirect("~/help/about");
        }
    }
}