using eCommerceApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [MyAuth("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

