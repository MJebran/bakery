using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace Bakery.Mobile.Services
{
    public class UserService : IUserService
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://kakeybakery.azurewebsites.net/") };
        public async Task AddUser(User user)
        {
            await client.PostAsJsonAsync("api/user/add/user", user);
        }

        public async Task DeleteUser(int id)
        {
            await client.DeleteAsync($"api/user/delete/user/{id}");
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await client.GetFromJsonAsync<List<User>>("api/user/users") ?? throw new Exception("users not found");
        }

        public async Task UpdateUser(int id)
        {
            await client.PutAsync($"api/user/update/user/{id}", new StringContent(""));
        }
    }
}
