using System.Net.Http.Json;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Mobile.Services
{
    public class FavoriteItemService : IFavoriteItemService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };
        public async Task AddFavoriteitem(Favoriteitem item)
        {
            await client.PostAsJsonAsync("api/favoriteitem/add/favoriteitem", item);
        }

        public async Task DeleteFavoriteitem(int id)
        {
            await client.DeleteAsync($"api/favoriteitem/favoriteItem/{id}");
        }

        public async Task<IEnumerable<Favoriteitem>> GetAllFavoriteitem()
        {
            return await client.GetFromJsonAsync<List<Favoriteitem>>("api/favoriteitem/favoritieitems") ?? throw new Exception("favorite items not found");
        }

        public async Task<Favoriteitem> GetFavoriteitemById(int id)
        {
            return await client.GetFromJsonAsync<Favoriteitem>($"api/favoriteitem/favoriteitem/{id}") ?? throw new Exception("favorite item not found");
        }

        public async Task UpdateFavoriteitem(int id)
        {
            await client.PutAsync($"api/favoriteitem/update/favoriteItem/{id}", new StringContent(""));
        }
    }
}
