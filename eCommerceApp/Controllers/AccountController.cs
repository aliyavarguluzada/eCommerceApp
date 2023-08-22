using eCommerceApp.Enums;
using eCommerceApp.Models;
using eCommerceApp.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var user = await _context.Users
                .Include(c => c.UserRole)
                .Where(c => c.Email == request.Email)
                .FirstOrDefaultAsync();

            if (user is null)
            {
                ModelState.AddModelError("", "Bele bir istifadeci yoxdu");
                return View(request);
            }

            var claims = new List<Claim>
        {
            new Claim("Email", user.Email),
            new Claim("Name", user.Name),
            new Claim("Role", user.UserRole.Name),
            new Claim("RoleId", user.UserRoleId.ToString()),
            new Claim("Id", user.Id.ToString())

        };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
           CookieAuthenticationDefaults.AuthenticationScheme,
           new ClaimsPrincipal(claimsIdentity));


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

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = await _context.Users.Where(c => c.Email == request.Email).FirstOrDefaultAsync();


            if (user is not null)
            {
                ModelState.AddModelError("", "This email already exists");
                return View(request);
            }


            user = new  User()
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                RegisterDte = DateTime.Now,
                UserRoleId = (int)UserRoleEnum.User,
                UserStatusId = (int)UserStatus.Active,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
            using (SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);
                var hash = sha256.ComputeHash(buffer);

                user.Password = hash;
            }
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login", "Account");
        }
    }

}
