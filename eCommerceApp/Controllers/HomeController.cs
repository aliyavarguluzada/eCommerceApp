using eCommerceApp.DTOs.BannerAds;
using eCommerceApp.DTOs.Sliders;
using eCommerceApp.Enums;
using eCommerceApp.Migrations;
using eCommerceApp.Models;
using eCommerceApp.ViewModels.Home;
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
                .Where(c => c.SliderStatusId == (int)SliderStatus.Active)
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


            var take = Convert.ToInt32(_configuration["Lists:BannerAds"]);

            var bannerAds = await _context
                .BannerAds
                .Where(c => c.BannerStatusId == (int)BannerStatus.Active)
                .Select(c => new BannerHomeIndexDto
            {
                BannerId = c.Id,
                CategoryId = c.CategoryId,
                Image = _configuration["Files:BannerAds"] + c.Image
            }).Take(take).ToListAsync();

            var vm = new HomeIndexVm();

            vm.BannerAds = bannerAds;
            vm.Sliders = sliders;



            return View(vm);
        }
    }
}
