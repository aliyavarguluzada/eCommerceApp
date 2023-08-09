using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public partial class UserAdress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Addres { get; set; } = null!;

    public int CityId { get; set; }

    public int RegionId { get; set; }

    public int AvenueId { get; set; }

    public int? Phone { get; set; }

    public bool IsMain { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Avenue Avenue { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
