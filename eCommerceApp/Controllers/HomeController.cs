using eCommerceApp.DTOs.Sliders;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public HomeController(ApplicationDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _context
                .Sliders
                .Select(c => new SliderHomeIndexDto
                {
                    Title = c.Title,
                    Slogan = c.Slogan,
                    BackgroundImage = _configuration["Files:Sliders"] + c.BackgroundImage,
                    BottomImage = _configuration["Files:Sliders"] + c.BottomImage,
                    TopImage = _configuration["Files:Sliders"] + c.TopImage,
                    CategoryId = c.CategoryId,
                })
                .ToListAsync();
            return View(sliders);
        }
    }
}
