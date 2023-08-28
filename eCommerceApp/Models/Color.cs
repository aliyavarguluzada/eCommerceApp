using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public  class Color
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
}
