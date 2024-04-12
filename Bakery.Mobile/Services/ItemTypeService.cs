using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace Bakery.Mobile.Services
{
    public class ItemTypeService : IItemTypeService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };
        public async Task AddItemtype(Itemtype item)
        {
            await client.PostAsJsonAsync("api/itemtype/add/itemtype", item);
        }

        public async Task DeleteItemtype(int id)
        {
            await client.DeleteAsync($"api/itemtype/delete/{id}");
        }

        public async Task<IEnumerable<Itemtype>> GetAllItemtypes()
        {
            return await client.GetFromJsonAsync<List<Itemtype>>("api/itemtype/itemtypes") ?? throw new Exception("item types not found");
        }

        public async Task UpdateItemtype(int id)
        {
            await client.PutAsync($"api/itemtype/update/itemtype/{id}", new StringContent(""));
        }
    }
}
