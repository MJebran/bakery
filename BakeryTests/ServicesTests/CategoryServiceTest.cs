using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace BakeryTests.ServiceTests;
public class CategoryServiceTest : ICategoryService
{
    public List<Category> categories { get; set; }
    public CategoryServiceTest()
    {
        categories = new();
    }
    public async Task AddCategory(Category category)
    {
        categories.Add(category);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        await Task.CompletedTask;
        return categories;
    }
}