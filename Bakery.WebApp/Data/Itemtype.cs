using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Itemtype
{
    public int ItemTypeId { get; set; }

    public string? ItemName { get; set; }

    public decimal? ItemPrice { get; set; }

    public int? ItmeCalories { get; set; }

    public decimal? ItemWeight { get; set; }

    public string? ItemDescription { get; set; }

    public int CategoryId { get; set; }

    public int SizeId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Customitem> Customitems { get; set; } = new List<Customitem>();

    public virtual ICollection<Favoriteitem> Favoriteitems { get; set; } = new List<Favoriteitem>();

    public virtual Size Size { get; set; } = null!;
}
