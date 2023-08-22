 using eCommerceApp.DTOs.Sliders;
using eCommerceApp.Enums;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Components
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public SliderViewComponent(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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


            return View(sliders);
        }
    }
}
