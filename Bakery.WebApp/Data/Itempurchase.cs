using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Itempurchase
{
    public int ItempurchaseId { get; set; }

    public int? ItempurchaseQuantity { get; set; }

    public int ItempurchaseItemId { get; set; }

    public int PurchaseId { get; set; }

    public virtual Customitem ItempurchaseItem { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
