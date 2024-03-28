using Bakery.WebApp.Data;
using System.Security.Claims;

namespace Bakery.WebApp.Authentication;

public interface IBakeryAutheticationService
{
    string authenticatedName {get; set;}
    string authenticatedSurname {get; set;}
    string authenticatedEmail {get; set;}
    bool IsAuthenticated {get; set;}
    Task<User> RegisterUserAsync(string email, string name, string surname);
    Task<bool> IsUserRegisteredAsync(string email);
    void AutheticateUser(string email, string name, string surname);
}
