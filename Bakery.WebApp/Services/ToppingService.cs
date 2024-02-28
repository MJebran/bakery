using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Services
{
    public class ToppingService(IDbContextFactory<PostgresContext> dbFactory) : IToppingService
    {
        public async Task AddTopping(Topping topping)
        {
            var context = await dbFactory.CreateDbContextAsync();
            var value = context.Toppings.AddAsync(topping);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Topping>> GetAllToppings()
        {
            var context = await dbFactory.CreateDbContextAsync();
            var value = context.Toppings.ToListAsync();
            return await value;
        }
    }
}
