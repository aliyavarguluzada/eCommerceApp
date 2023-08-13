using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }

}
