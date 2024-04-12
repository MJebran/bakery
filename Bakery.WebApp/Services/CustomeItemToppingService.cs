using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Services
{
    public class CustomeItemToppingService(IDbContextFactory<PostgresContext> factory) : ICustomeItemToppingService
    {
        public async Task AddCustomeItemTopping(Customitemtopping custom)
        {
            var context = await factory.CreateDbContextAsync();
            await context.Customitemtoppings.AddAsync(custom);
            context.SaveChanges();
        }

        public async Task DeleteCustomeItemTopping(int id)
        {
            var context = await factory.CreateDbContextAsync();
            Customitemtopping customItemType = new Customitemtopping()
            {
                CustomItemToppingId = id,
            };
            context.Customitemtoppings.Remove(customItemType);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Customitemtopping>> GetAllCustomeItemTopping()
        {
            var context = await factory.CreateDbContextAsync();
            var customeItemToppings = context.Customitemtoppings
                .Include(c => c.CustomItem)
                .ThenInclude(i => i.Item)
                .Include(c => c.Topping)
                .ToListAsync();
            return await customeItemToppings;
        }

        public async Task<Customitemtopping> GetCustomeItemToppingById(int id)
        {
            var context = await factory.CreateDbContextAsync();
            return await context.Customitemtoppings.
                Where(p => p.CustomItemToppingId == id)
                .FirstOrDefaultAsync() ?? new Customitemtopping();
        }
    }
}
