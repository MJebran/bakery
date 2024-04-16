using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Customitemtopping")]
public partial class Customitemtopping
{
    [PrimaryKey, AutoIncrement]
    public int CustomItemToppingId { get; set; }

    public int? CustomItemToppingQuantity { get; set; }

    [ForeignKey(typeof(Customitem))]
    public int CustomItemId { get; set; }

    [ForeignKey(typeof(Topping))]
    public int ToppingId { get; set; }

    [ManyToOne]
    public virtual Customitem CustomItem { get; set; } = null!;

    [ManyToOne]
    public virtual Topping Topping { get; set; } = null!;
}
