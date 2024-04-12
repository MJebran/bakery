using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace Bakery.Mobile.Services
{
    public class ItemPurchaseService : IItemPurchaseService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };
        public async Task AddItempurchase(Itempurchase itempurchase)
        {
            await client.PostAsJsonAsync("api/itempurchase/add/itempurchase", itempurchase);
        }

        public async Task DeleteItempurchase(int id)
        {
            await client.DeleteAsync($"api/itempurchase/delete/itempurchase/{id}");
        }

        public async Task<IEnumerable<Itempurchase>> GetAllItempurchase()
        {
            return await client.GetFromJsonAsync<List<Itempurchase>>("api/itempurchase/itempurchases") ?? throw new Exception("item purchases not found");
        }

        public async Task<Itempurchase> GetItempurchaseById(int id)
        {
            return await client.GetFromJsonAsync<Itempurchase>($"api/itempurchase/itempurchase/{id}") ?? throw new Exception("item purchase not found");
        }

        public async Task UpdateItempurchase(int id)
        {
            await client.PutAsync($"api/itempurchase/update/itempurchase/{id}", new StringContent(""));
        }

    }
}
