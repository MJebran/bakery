using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Topping")]
public partial class Topping
{
    [PrimaryKey, AutoIncrement]
    public int ToppingId { get; set; }

    public string? ToppingName { get; set; }

    public decimal? ToppingPrice { get; set; }

    public decimal? ToppingWeight { get; set; }

    public int? ToppingCalories { get; set; }

    public string? ToppingUnit { get; set; }

    [OneToMany]
    public virtual ICollection<Customitemtopping> Customitemtoppings { get; set; } = new List<Customitemtopping>();
}
