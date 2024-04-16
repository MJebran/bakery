using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Services
{
    public class FavoriteItemService(IDbContextFactory<PostgresContext> factory) : IFavoriteItemService
    {
        public async Task AddFavoriteitem(Favoriteitem size)
        {
            var context = await factory.CreateDbContextAsync();
            await context.AddAsync(size);
            await context.SaveChangesAsync();
        }

        public async Task DeleteFavoriteitem(int id)
        {
            var context = await factory.CreateDbContextAsync();
            context.Remove(id);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Favoriteitem>> GetAllFavoriteitem()
        {
            var context = await factory.CreateDbContextAsync();
            return await context.Favoriteitems.ToListAsync();
        }

        public async Task<Favoriteitem> GetFavoriteitemById(int id)
        {
            var context = await factory.CreateDbContextAsync();
            return await context.Favoriteitems
                .Where(fv => fv.FavoriteitemId == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateFavoriteitem(int id)
        {
            var context = await factory.CreateDbContextAsync();
            Favoriteitem favorite = new Favoriteitem()
            {
                FavoriteitemId = id
            };
            context.Update(favorite);
            await context.SaveChangesAsync();
        }
    }
}
