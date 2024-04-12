using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using System.Net.Http.Json;

namespace Bakery.Mobile.Services
{
    public class RoleService : IRoleService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await client.GetFromJsonAsync<List<Role>>("api/role/roles") ?? throw new Exception("roles not found");
        }
    }
}
