﻿using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public class Brand
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int BrandStatusId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
