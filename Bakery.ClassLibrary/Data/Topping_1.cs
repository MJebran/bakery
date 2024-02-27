using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Topping
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Itemtype> Itemtypes { get; set; } = new List<Itemtype>();
}
