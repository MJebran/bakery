using System.Net.Http.Json;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.Mobile.Services
{
    public class CategoryService : ICategoryService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };

        public async Task AddCategory(Category category)
        {
            await client.PostAsJsonAsync("api/category/add/category", category);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await client.GetFromJsonAsync<List<Category>>("api/category/categories") ?? throw new Exception("categories not found");
        }
    }
}
