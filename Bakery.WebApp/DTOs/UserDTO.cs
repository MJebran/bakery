namespace Bakery.WebApp.Services;

public class UserDTO
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public int? UserPhone { get; set; }
    public int UserRoleId { get; set; }
}
