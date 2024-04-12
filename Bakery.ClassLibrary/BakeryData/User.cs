using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("User")]
public partial class User
{
    [PrimaryKey, AutoIncrement]
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public int? UserPhone { get; set; }

    public int UserRoleId { get; set; }

    [OneToMany]
    public virtual ICollection<Favoriteitem> Favoriteitems { get; set; } = new List<Favoriteitem>();

    [OneToMany]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    [ManyToOne]
    public virtual Role UserRole { get; set; } = null!;
}
