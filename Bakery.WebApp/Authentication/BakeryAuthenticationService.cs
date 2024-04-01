using System.Reflection.Metadata.Ecma335;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.WebApp.Authentication;

public class BakeryAuthenticationService : IBakeryAutheticationService
{
    public BakeryAuthenticationService(IUserService _userService) { this._userService = _userService; }
    private IUserService _userService { get; set; }
    private User? authenticatedUser {get; set;}
    public async Task<User> RegisterUserAsync(string email, string name, string surname)
    {
        User newUser = new()
        {
            UserEmail = email,
            UserName = $"{name} {surname}",
            UserRoleId = 1
        };

        await _userService.AddUser(newUser);

        authenticatedUser = newUser;

        return newUser;
    }

    public async Task<bool> IsUserAuthenticatedAsync(string email)
    {
        var user = (await _userService.GetAllUsers()).FirstOrDefault(u => u.UserEmail == email);

        if(user is not null)
        {
            authenticatedUser = user;
            return true;
        }
        else
        {
            authenticatedUser = null;
            return false;
        }
    }

    public bool UserExists() => authenticatedUser != null;
    public User GetAuthenticatedUser() { return authenticatedUser;}
}