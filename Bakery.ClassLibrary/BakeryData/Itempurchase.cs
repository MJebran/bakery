using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Itempurchase")]
public partial class Itempurchase
{
    [PrimaryKey, AutoIncrement]
    public int ItempurchaseId { get; set; }
    public int? ItempurchaseQuantity { get; set; }

    [ForeignKey(typeof(Customitem))]
    public int ItempurchaseItemId { get; set; }

    [ForeignKey(typeof(Purchase))]
    public int PurchaseId { get; set; }

    [ManyToOne]
    public virtual Customitem ItempurchaseItem { get; set; } = null!;

    [ManyToOne]
    public virtual Purchase Purchase { get; set; } = null!;
}
