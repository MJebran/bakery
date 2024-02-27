using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;


namespace Bakery.WebApp.Services
{
    public class SizeService(IDbContextFactory<PostgresContext> dbFactory) : ISizeService
    {

        public async Task AddSize(Size size)
        {
            var context = await dbFactory.CreateDbContextAsync();
            var value = context.Sizes.AddAsync(size);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Size>> GetAllSizes()
        {
            var context = await dbFactory.CreateDbContextAsync();
            var value = context.Sizes.ToListAsync();
            return await value;
        }
    }
}
