using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Services
{
    public class RoleService(IDbContextFactory<PostgresContext> dbFactory) : IRoleService
    {
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var context = await dbFactory.CreateDbContextAsync(); //actull database Mustafa
            var roles = await context.Roles.ToListAsync();
            return roles;
        }
    }
}
