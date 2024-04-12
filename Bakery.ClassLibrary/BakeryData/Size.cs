using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Size")]
public partial class Size
{
    [PrimaryKey, AutoIncrement]
    public int SizeId { get; set; }

    public string? SizeName { get; set; }

    [OneToMany]
    public virtual ICollection<Itemtype> Itemtypes { get; set; } = new List<Itemtype>();
}
