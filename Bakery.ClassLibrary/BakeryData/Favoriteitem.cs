using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class Favoriteitem
{
    public int FavoriteitemId { get; set; }

    public int UserId { get; set; }

    public int ItemId { get; set; }

    public virtual Itemtype Item { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
