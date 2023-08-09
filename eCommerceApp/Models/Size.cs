using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public partial class Size
{
    public int Id { get; set; }

    public int Name { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
