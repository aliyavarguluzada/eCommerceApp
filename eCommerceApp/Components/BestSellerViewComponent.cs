using eCommerceApp.DTOs.Categories;
using eCommerceApp.DTOs.Products;
using eCommerceApp.Enums;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Components
{
    public class BestSellerViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public BestSellerViewComponent(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
         {

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



            return View(categories);
        }

    }
}
