using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Itemtype")]
public partial class Itemtype
{
    [PrimaryKey, AutoIncrement]
    public int ItemTypeId { get; set; }

    public string? ItemName { get; set; }

    public decimal? ItemPrice { get; set; }

    public int? ItmeCalories { get; set; }

    public decimal? ItemWeight { get; set; }

    public string? ItemDescription { get; set; }

    [ForeignKey(typeof(Category))]
    public int CategoryId { get; set; }

    [ForeignKey(typeof(Size))]
    public int SizeId { get; set; }

    [ManyToOne]
    public virtual Category Category { get; set; } = null!;

    [OneToMany]
    public virtual ICollection<Customitem> Customitems { get; set; } = new List<Customitem>();

    [OneToMany]
    public virtual ICollection<Favoriteitem> Favoriteitems { get; set; } = new List<Favoriteitem>();

    [ManyToOne]
    public virtual Size Size { get; set; } = null!;
}
