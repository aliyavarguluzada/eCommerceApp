using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public  class ProductColor
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Color Color { get; set; }

    public virtual Product Product { get; set; }
}
