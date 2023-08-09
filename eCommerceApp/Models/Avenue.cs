using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public partial class Avenue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RegionId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<UserAdress> UserAdresses { get; set; } = new List<UserAdress>();
}
