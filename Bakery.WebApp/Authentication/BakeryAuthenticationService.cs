using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Authentication;

public class BakeryAuthenticationService : IBakeryAutheticationService
{
    public BakeryAuthenticationService(IUserService _userService) { this._userService = _userService; }
    IUserService _userService { get; set; }
    public bool IsAuthenticated {get; set;}
    public string authenticatedName {get; set;}
    public string authenticatedSurname {get; set;}
    public string authenticatedEmail {get; set;}
    public void AutheticateUser(string email, string name, string surname)
    {
        IsAuthenticated = true;
        authenticatedName = name;
        authenticatedEmail = email;
        authenticatedSurname = surname;
    }

    public async Task<User> RegisterUserAsync(string email, string name, string surname)
    {
        User newUser = new()
        {
            UserEmail = email,
            UserName = $"{name} {surname}",
            UserRoleId = 1
        };

        await _userService.AddUser(newUser);

        AutheticateUser(email, name, surname);

        return newUser;
    }

    public async Task<bool> IsUserRegisteredAsync(string email)
    {
        var users = await _userService.GetAllUsers();

        return users.FirstOrDefault(u => u.UserEmail == email) != null;
    }
}