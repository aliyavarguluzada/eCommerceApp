﻿using System;
using System.Collections.Generic;

namespace eCommerceApp.Models;

public  class Region
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CityId { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public virtual ICollection<Avenue> Avenues { get; set; } = new List<Avenue>();

    public virtual City City { get; set; }
}
