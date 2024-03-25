using Bakery.WebApp.Data;
using System.Security.Claims;

namespace Bakery.WebApp.Authentication;

public interface IAutheticationService
{
    public bool IsAuthenticated { get; }
    public Task<int> LookUpUserAsync(string email, string name, string surname);
    public Task<User> GetUser(string email);
}
