using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Size
{
    public int SizeId { get; set; }

    public string? SizeName { get; set; }

    public virtual ICollection<Itemtype> Itemtypes { get; set; } = new List<Itemtype>();
}
