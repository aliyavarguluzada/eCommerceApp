using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public  class Product
{
    public int Id { get; set; }

    public string MainCode { get; set; }

    public bool IsMain { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public int Discount { get; set; }

    public string ShortDesc { get; set; }

    public int BrandId { get; set; }

    public string ProductCode { get; set; }

    public bool HasStock { get; set; }

    public int StockCount { get; set; }

    public string Description { get; set; }

    public int ProductStatusId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime Updated { get; set; }

    public virtual Brand Brand { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

    public virtual ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
