using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WindnTreesSEO.Models;
using WindnTreesSEO.Models.Database.Repositories;

namespace WindnTreesSEO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var categoryRepository = new CategoryRepository(new Models.Database.ApplicationContext());
            var productRepository = new ProductRepository(new Models.Database.ApplicationContext());
            var categories = categoryRepository.List(new WindnTrees.ICRUDS.Standard.SearchInput { keyword = "" });
            var newProducts = productRepository.ListRandom(new WindnTrees.ICRUDS.Standard.SearchInput { total = 10 });
            var topProducts = productRepository.ListRandom(new WindnTrees.ICRUDS.Standard.SearchInput { total = 5 });

            var productViewModel = new ProductViewModel
            {
                Categories = categories,
                NewProducts = newProducts,
                Top5Products = topProducts
            };

            return View(productViewModel);
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult CategoryTopics()
        {
            return View();
        }

        public IActionResult CRUDSList()
        {
            return View();
        }

        public IActionResult Topic()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
