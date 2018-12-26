using Abstraction.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Application.Core.Controllers
{
    public class TermsController : BasicController
    {
        // GET: Terms
        public IActionResult Index()
        {
            return View();
        }
    }
}