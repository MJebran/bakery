using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Favoriteitem")]
public partial class Favoriteitem
{
    [PrimaryKey, AutoIncrement]
    public int FavoriteitemId { get; set; }

    [ForeignKey(typeof(User))]
    public int UserId { get; set; }

    [ForeignKey(typeof(Itemtype))]
    public int ItemId { get; set; }
    
    [ManyToOne]
    public virtual Itemtype Item { get; set; } = null!;

    [ManyToOne]
    public virtual User User { get; set; } = null!;
}
