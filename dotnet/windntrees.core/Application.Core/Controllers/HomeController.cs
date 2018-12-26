using Abstraction.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Application.Core.Controllers
{   
    public class HomeController : BasicController
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {   
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Documentation()
        {
            return View();
        }
    }
}
