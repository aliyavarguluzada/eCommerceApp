using eCommerceApp.Enums;
using eCommerceApp.Models;
using eCommerceApp.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Cryptography;
using System.Text;

namespace eCommerceApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel request)
        {
            var user = await _context.Users.Where(c => c.Email == request.Email).FirstOrDefaultAsync();

            if (user is null)
            {
                ModelState.AddModelError("", "Bele bir istifadeci yoxdu");
                return View(request);
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);
                var hash = sha256.ComputeHash(buffer);

                if (!user.Password.SequenceEqual(hash))
                {
                    ModelState.AddModelError("", "Passwords do not match");
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = await _context.Users.Where(c => c.Email == request.Email).FirstOrDefaultAsync();


            if(user is not null)
            {
                ModelState.AddModelError("","This email already exists");
                return View(request);
            }


            user = new User()
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                RegisterDte = DateTime.Now,
                UserRoleId = (int)UserRoleEnum.User,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
            using (SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);
                var hash = sha256.ComputeHash(buffer);

                user.Password = hash;
            }
            await _context.AddAsync(User);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login", "Account");
        }
    }

}
