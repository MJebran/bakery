using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Data;

[Table("Role")]
public partial class Role
{
    [PrimaryKey, AutoIncrement]
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? RoleDescription { get; set; }

    [OneToMany]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
