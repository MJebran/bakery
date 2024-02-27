using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Topping
{
    public int ToppingId { get; set; }

    public string? ToppingName { get; set; }

    public decimal? ToppingPrice { get; set; }

    public decimal? ToppingWeight { get; set; }

    public int? ToppingCalories { get; set; }

    public string? ToppingUnit { get; set; }

    public virtual ICollection<Customitem> Customitems { get; set; } = new List<Customitem>();
}
