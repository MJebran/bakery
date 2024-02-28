using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Services
{

    public class CategoryService(IDbContextFactory<PostgresContext> dbFactory) : ICategoryService
    {
        public async Task AddCategory(Category category)
        {
            var context = await dbFactory.CreateDbContextAsync();
            var value = context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var context = await dbFactory.CreateDbContextAsync();
            var value = context.Categories.ToListAsync();
            return await value;
        }
    }
}
