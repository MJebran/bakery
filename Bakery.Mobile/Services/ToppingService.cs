using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace Bakery.Mobile.Services
{
    public class ToppingService : IToppingService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };
        public async Task AddTopping(Topping topping)
        {
            await client.PostAsJsonAsync("api/topping/add/topping", topping);
        }

        public async Task<IEnumerable<Topping>> GetAllToppings()
        {
            return await client.GetFromJsonAsync<List<Topping>>("api/topping/toppings") ?? throw new Exception("toppings not found");
        }
    }
}
