using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Bakery.WebApp.Services
{
    public class ItemTypeService(IDbContextFactory<PostgresContext> factory) : IItemTypeService
    {
        public async Task AddItemtype(Itemtype size)
        {
            var context = await factory.CreateDbContextAsync();
            await context.Itemtypes.AddAsync(size);
            context.SaveChanges();
        }

        public async Task DeleteItemtype(int id)
        {
            var context = await factory.CreateDbContextAsync();
            Itemtype itemType = new Itemtype()
            {
                ItemTypeId = id,
            };
            context.Itemtypes.Remove(itemType);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Itemtype>> GetAllItemtypes()
        {
            var context = await factory.CreateDbContextAsync();
            var items = context.Itemtypes.Include(c => c.Category).ToListAsync();
            return await items;
        }

        public async Task UpdateItemtype(int id)
        {
            var context = await factory.CreateDbContextAsync();
            Itemtype itemType = new Itemtype()
            {
                ItemTypeId = id
            };
            context.Itemtypes.Update(itemType);
            context.SaveChanges();
        }
    }
}
