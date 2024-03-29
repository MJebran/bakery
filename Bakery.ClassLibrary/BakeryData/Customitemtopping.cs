using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Customitemtopping
{
    public int CustomItemToppingId { get; set; }

    public int? CustomItemToppingQuantity { get; set; }

    public int CustomItemId { get; set; }

    public int ToppingId { get; set; }

    public virtual Customitem CustomItem { get; set; } = null!;

    public virtual Topping Topping { get; set; } = null!;
}
