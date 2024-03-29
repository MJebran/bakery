using Bakery.WebApp.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Bakery.WebApp.Authentication;

public interface IBakeryAutheticationService
{
    Task<User> RegisterUserAsync(string email, string name, string surname);
    Task<bool> IsUserRegisteredAsync(string email);
    Task AutheticateUserAsync(string email);
    User GetAuthenticatedUser();
}
