using Abstraction.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Application.Core.Controllers
{
    public class HelpController : BasicController
    {
        // GET: Help
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}