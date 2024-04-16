using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Services
{
    public class UserService(IDbContextFactory<PostgresContext> dbfactory) : IUserService
    {
        public async Task AddUser(User user)
        {
            var context = await dbfactory.CreateDbContextAsync();
            var value = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var context = await dbfactory.CreateDbContextAsync();
            User user = new User()
            {
                UserId = id
            };
            context.Users.Remove(user);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var context = await dbfactory.CreateDbContextAsync();
            var value = await context.Users.Include(u => u.UserRole).ToListAsync();
            return value;

        }

        public async Task UpdateUser(int id)
        {
            var context = await dbfactory.CreateDbContextAsync();
            User user = new User()
            {
                UserId = id
            };
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
