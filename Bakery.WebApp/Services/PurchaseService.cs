using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Bakery.WebApp.Services
{
    public class PurchaseService(IDbContextFactory<PostgresContext> factory) : IPurchaseService
    {
        public async Task AddPurchase(Purchase size)
        {
            var context = await factory.CreateDbContextAsync();
            await context.AddAsync(size);
            await context.SaveChangesAsync();
        }

        public async Task DeletePurchase(int id)
        {
            var context = await factory.CreateDbContextAsync();
            Purchase purchase = new Purchase()
            {
                PurchaseId = id
            };
            context.Remove(purchase);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchase()
        {
            var context = await factory.CreateDbContextAsync();
            var purchases = context.Purchases
            .Include(p => p.Itempurchases)
                .ThenInclude(ip => ip.ItempurchaseItem)
                    .ThenInclude(ci => ci.Item)
            .Include(p => p.Itempurchases)
                .ThenInclude(ip => ip.ItempurchaseItem)
                    .ThenInclude(ci => ci.Customitemtoppings)
                        .ThenInclude(cit => cit.Topping)
            .ToList();

            return purchases;
        }

        public async Task<Purchase> GetPurchase(int id)
        {
            var context = await factory.CreateDbContextAsync();
            return await context.Purchases.
                Where(p => p.PurchaseId == id)
                .FirstOrDefaultAsync() ?? new Purchase();
        }

        public async Task UpdatePurchase(int id)
        {
            var context = await factory.CreateDbContextAsync();
            Purchase purchase = new Purchase()
            {
                PurchaseId = id
            };
            context.Purchases.Update(purchase);
            context.SaveChanges();
        }
    }
}
