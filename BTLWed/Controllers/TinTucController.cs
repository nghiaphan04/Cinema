using Microsoft.AspNetCore.Mvc;
using BTLWed.Models;
using System.Diagnostics;

namespace BTLWed.Controllers
{
    public class TinTucController : Controller
    {
        public IActionResult TinTuc()
        {
            return View();
        }
        public IActionResult ChiTietTinTuc()
        {
            return View();
        }
    }
}
