using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Services
{
    public class CustomItemService(IDbContextFactory<PostgresContext> dbfactory) : ICustomItemService
    {
        public async Task AddCustomitem(Customitem customitem)
        {
            var context = await dbfactory.CreateDbContextAsync(); // accessing and strong it
            context.Customitems.Add(customitem); // adding it 
            context.SaveChanges(); // saving it

        }

        public async Task DeleteCustomitem(int id)
        {
            var context = await dbfactory.CreateDbContextAsync();
            Customitem customitem = new Customitem() // new instance 
            {
                CustomItemId = id // seting the id to the object, it  sends the value to that object. 
            };           
            context.Customitems.Remove(customitem);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Customitem>> GetAllCustomitem()
        {
            var context = await dbfactory.CreateDbContextAsync();
            var customitems = await context.Customitems.ToListAsync();
            return customitems;
        }

        public async Task<Customitem> GetCustomeItemById(int id)
        {
            var context = await dbfactory.CreateDbContextAsync();
            var customitem = await context.Customitems.FirstOrDefaultAsync(x => x.CustomItemId == id);
            return customitem;
        }

        public async Task UpdateCustomitem(int id)
        {
            var context = await dbfactory.CreateDbContextAsync();
            Customitem customitem = new Customitem()
            {
                CustomItemId = id
            };
            context.Customitems.Update(customitem);
            context.SaveChanges();
        }
    }
}
