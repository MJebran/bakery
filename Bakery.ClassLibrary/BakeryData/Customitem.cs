using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Customitem
{
    public int CustomItemId { get; set; }

    public int ItemId { get; set; }

    public virtual ICollection<Customitemtopping> Customitemtoppings { get; set; } = new List<Customitemtopping>();

    public virtual Itemtype Item { get; set; } = null!;

    public virtual ICollection<Itempurchase> Itempurchases { get; set; } = new List<Itempurchase>();
}
