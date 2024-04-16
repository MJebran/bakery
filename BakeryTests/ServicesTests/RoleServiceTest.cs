using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace BakeryTests.ServiceTests;

public class RoleServiceTest : IRoleService
{
    List<Role> roles { get; set; }
    public RoleServiceTest()
    {
        roles = new();
    }
    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        await Task.CompletedTask;
        return roles;
    }
}