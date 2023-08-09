using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
