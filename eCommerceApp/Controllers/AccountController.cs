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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return await RedirectToAction("");
        }
    }

}
