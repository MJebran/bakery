using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Bakery.Mobile.Services
{
    public class PurchaseService : IPurchaseService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };
        public async Task AddPurchase(Purchase purchase)
        {
            await client.PostAsJsonAsync("api/purchase/add/purchase", purchase);
        }

        public async Task DeletePurchase(int id)
        {
            await client.DeleteAsync($"api/purchase/delete/purchase/{id}");
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchase()
        {
            return await client.GetFromJsonAsync<List<Purchase>>("api/purchase/purchases") ?? throw new Exception("purchases not found");
        }

        public async Task<Purchase> GetPurchase(int id)
        {
            return await client.GetFromJsonAsync<Purchase>($"api/purchase/purchase/{id}") ?? throw new Exception("purchase not found");
        }

        public async Task UpdatePurchase(Purchase purchase)
        {
            string json = JsonSerializer.Serialize(purchase);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync($"api/purchase/update/purchase", content);
        }
    }
}
