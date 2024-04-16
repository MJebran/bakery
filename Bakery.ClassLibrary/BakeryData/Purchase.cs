using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Purchase")]
public partial class Purchase
{
    [PrimaryKey, AutoIncrement]
    public int PurchaseId { get; set; }

    public DateOnly? PurcahseDate { get; set; }

    public bool Ispayed { get; set; }

    [ForeignKey(typeof(Purchase))]
    public int PurchaseUserId { get; set; }

    [OneToMany]
    public virtual ICollection<Itempurchase> Itempurchases { get; set; } = new List<Itempurchase>();

    [ManyToOne]
    public virtual User PurchaseUser { get; set; } = null!;
}
