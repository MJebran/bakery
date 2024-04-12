using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using System.Net.Http.Json;


namespace Bakery.Mobile.Services
{
    public class SizeService : ISizeService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };

        public async Task AddSize(WebApp.Data.Size size)
        {
            await client.PostAsJsonAsync("api/size/add/size", size);
        }

        public async Task<IEnumerable<WebApp.Data.Size>> GetAllSizes()
        {
            return await client.GetFromJsonAsync<List<WebApp.Data.Size>>("api/size/sizes") ?? throw new Exception("custom items not found");
        }
    }
}
