using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using BakeryTests;
using System.Net.Http.Json;

class CategoryServiceTest : ICategoryService
{
    public List<Category> categories {get; set;}
    public CategoryServiceTest()
    {
        categories = new();
    }
    public async Task AddCategory(Category category)
    {
        categories.Add(category);

    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return categories;
    }
}