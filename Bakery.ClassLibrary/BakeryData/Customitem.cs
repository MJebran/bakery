using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Customitem")]
public partial class Customitem
{
    [PrimaryKey, AutoIncrement]
    public int CustomItemId { get; set; }

    [ForeignKey(typeof(Itemtype))]
    public int ItemId { get; set; }

    [OneToMany]
    public virtual ICollection<Customitemtopping> Customitemtoppings { get; set; } = new List<Customitemtopping>();

    [ManyToOne]
    public virtual Itemtype Item { get; set; } = null!;

    [OneToMany]
    public virtual ICollection<Itempurchase> Itempurchases { get; set; } = new List<Itempurchase>();
}
