using Microsoft.AspNetCore.Mvc;

namespace BTLWed.Controllers
{
    public class DanhSachRapController : Controller
    {
        public IActionResult ChiTietRap()
        {
            return View();
        }
    }
}
