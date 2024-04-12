using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Mobile.Services
{
    public class CustomeItemToppingService : ICustomeItemToppingService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };
        public async Task AddCustomeItemTopping(Customitemtopping custom)
        {
            await client.PostAsJsonAsync("api/customeitemtopping/add/custometoppingItem", custom);
        }

        public async Task DeleteCustomeItemTopping(int id)
        {
            await client.DeleteAsync($"api/customeitemtopping/delete/{id}");
        }

        public async Task<IEnumerable<Customitemtopping>> GetAllCustomeItemTopping()
        {
            return await client.GetFromJsonAsync<List<Customitemtopping>>("api/customeitemtopping/custometoppingitem") ?? throw new Exception("Item not found");
        }

        public async Task<Customitemtopping> GetCustomeItemToppingById(int id)
        {
            var customitemtoppings = await client.GetFromJsonAsync<List<Customitemtopping>>("api/customeitemtopping/custometoppingitem");
            return customitemtoppings?.Where(cit => cit.CustomItemToppingId == id).FirstOrDefault() ?? throw new Exception("Item not found");

        }
    }
}
