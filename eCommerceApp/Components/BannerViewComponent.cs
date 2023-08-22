using eCommerceApp.DTOs.BannerAds;
using eCommerceApp.Enums;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Components
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public BannerViewComponent(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var take = Convert.ToInt32(_configuration["Lists:BannerAds"]);

            var bannerAds = await _context
                .BannerAds
                .Where(c => c.BannerStatusId == (int)BannerStatus.Active)
                .OrderByDescending(c => c.Id)
                .Select(c => new BannerHomeIndexDto
                {
                    BannerId = c.Id,
                    CategoryId = c.CategoryId,
                    Image = _configuration["Files:BannerAds"] + c.Image

                }).Take(take).ToListAsync();


            return View(bannerAds);
        }

    }
}
