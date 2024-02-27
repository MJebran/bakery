using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public DateOnly? PurcahseDate { get; set; }

    public bool Ispayed { get; set; }

    public int PurchaseUserId { get; set; }

    public virtual ICollection<Itempurchase> Itempurchases { get; set; } = new List<Itempurchase>();

    public virtual User PurchaseUser { get; set; } = null!;
}
