using BTLWed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BTLWed.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult homePageCinema()
        {
            return View();
        }
        public IActionResult pageLichChieu()
        {
            return View();
        }

        public IActionResult pageTinTuc()
        {
            return View();
        }
        public IActionResult pageTin()
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
