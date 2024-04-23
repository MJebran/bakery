using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Bakery.WebApp.Services
{
    public class ItemPurchaseService(IDbContextFactory<PostgresContext> dbFactory) : IItemPurchaseService
    {
        public async Task AddItempurchase(Itempurchase itempurchase)
        {
            var context = await dbFactory.CreateDbContextAsync();
            context.Itempurchases.Add(itempurchase);
            context.SaveChanges();
        }

        public async Task DeleteItempurchase(int id)
        {
            var context = await dbFactory.CreateDbContextAsync();
            var itempurchase = new Itempurchase()
            {
                ItempurchaseId = id
            };
            context.Itempurchases.Remove(itempurchase);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Itempurchase>> GetAllItempurchase()
        {
            var context = await dbFactory.CreateDbContextAsync();
            var itempurchases = await context.Itempurchases
            .Include(ip => ip.ItempurchaseItem)
                    .ThenInclude(ci => ci.Item)
            .Include(ip => ip.ItempurchaseItem)
                    .ThenInclude(ci => ci.Customitemtoppings)
                        .ThenInclude(cit => cit.Topping)
            .ToListAsync();
            return itempurchases;
        }

        public async Task<Itempurchase> GetItempurchaseById(int id)
        {
            var context = await dbFactory.CreateDbContextAsync();
            var itempurchase = await context.Itempurchases
                .Where(item => item.ItempurchaseId == id)
                .Include(c => c.ItempurchaseItem)
                .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync();
            return itempurchase;
        }

        public async Task UpdateItempurchase(Itempurchase itempurchase)
        {
            var context = await dbFactory.CreateDbContextAsync();
            context.Itempurchases.Update(itempurchase);
            context.SaveChanges();
        }

    }
}
