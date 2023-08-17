using eCommerceApp.DTOs.BannerAds;
using eCommerceApp.DTOs.Categories;
using eCommerceApp.DTOs.Products;
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
            //var sliders = await _context
            //    .Sliders
            //    .Where(c => c.SliderStatusId == (int)SliderStatus.Active)
            //    .Select(c => new SliderHomeIndexDto
            //    {
            //        Title = c.Title,
            //        Slogan = c.Slogan,
            //        BackgroundImage = _configuration["Files:Sliders"] + c.BackgroundImage,
            //        BottomImage = _configuration["Files:Sliders"] + c.BottomImage,
            //        TopImage = _configuration["Files:Sliders"] + c.TopImage,
            //        CategoryId = c.CategoryId,
            //    })
            //    .ToListAsync();


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



            var categories = await _context
                .Categories
                .Include(c => c.Products)
                .Select(c => new CategoryHomeIndexDto
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    Products = c.Products
                    .Where(a => a.ProductStatusId == (int)ProductStatus.Home)
                    .Select(a => new ProductDto
                    {
                        Name = a.Name,
                        Price = a.Price.ToString("#.##"),
                        CategoryName = c.Name,
                        ProductId = a.Id,
                        AfterDiscountPrice = a.Discount == null ? null : (a.Price - (a.Price * a.Discount / 100)).ToString(),
                        MainImage = _configuration["Files:Products"] + a.ProductPhotos.Where(b => b.IsMain == true).Select(b => b.Image).FirstOrDefault(),
                        Images = a.ProductPhotos.Where(b => b.IsMain == false).Select(b => _configuration["Files:Products"] + b.Image).ToList()
                    })
                    .ToList()

                })
                .ToListAsync();

            //var products = new List<ProductDto>();


            //foreach (var category in categories)
            //{
            //    var categoryProducts = await _context
            //        .Products
            //        .Where(c => c.CategoryId == category.CategoryId && c.ProductStatusId == (int)ProductStatus.Active)
            //        .Take(10)
            //        .Select(c => new ProductDto { })
            //        .ToListAsync();

            //    products.AddRange(categoryProducts);

            //}

            ViewBag.Categories = categories;
            var vm = new HomeIndexVm();

            vm.BannerAds = bannerAds;
            //vm.Sliders = sliders;
            vm.Categories = categories;
            //vm.Products = products;



            return View(vm);
        }
    }
}
