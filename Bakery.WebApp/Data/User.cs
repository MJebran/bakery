using System;
using System.Collections.Generic;

namespace Bakery.WebApp.Data;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public int? UserPhone { get; set; }

    public int UserRoleId { get; set; }

    public virtual ICollection<Favoriteitem> Favoriteitems { get; set; } = new List<Favoriteitem>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual Role UserRole { get; set; } = null!;
}
