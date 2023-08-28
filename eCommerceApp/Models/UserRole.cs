using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public  class UserRole
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
