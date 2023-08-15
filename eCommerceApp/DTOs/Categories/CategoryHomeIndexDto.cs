using eCommerceApp.DTOs.Products;

namespace eCommerceApp.DTOs.Categories
{
    public class CategoryHomeIndexDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }

    }
}
