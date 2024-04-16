using System.Net.Http.Json;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.Mobile.Services
{
    public class CustomItemService : ICustomItemService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };

        public async Task AddCustomitem(Customitem customitem)
        {
            await client.PostAsJsonAsync("api/customitem/add/customitem", customitem);
        }

        public async Task DeleteCustomitem(int id)
        {
            await client.DeleteAsync($"api/customitem/delete/customitem/{id}");
        }

        public async Task<IEnumerable<Customitem>> GetAllCustomitem()
        {
            return await client.GetFromJsonAsync<List<Customitem>>("api/customitem/customitems") ?? throw new Exception("custom items not found");
        }

        public async Task<Customitem> GetCustomeItemById(int id)
        {
            return await client.GetFromJsonAsync<Customitem>($"api/customitem/customitem/{id}") ?? throw new Exception("custom item not found");
        }

        public async Task UpdateCustomitem(int id)
        {
            await client.PutAsync($"api/customitem/update/customitem/{id}", new StringContent(""));
        }
    }
}
