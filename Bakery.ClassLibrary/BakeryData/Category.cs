using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Category")]
public partial class Category
{
    [PrimaryKey, AutoIncrement]
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryDescription { get; set; }

    [OneToMany]
    public virtual ICollection<Itemtype> Itemtypes { get; set; } = new List<Itemtype>();
}
