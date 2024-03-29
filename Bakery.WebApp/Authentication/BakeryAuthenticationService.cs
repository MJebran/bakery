using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.WebApp.Authentication;

public class BakeryAuthenticationService : IBakeryAutheticationService
{
    public BakeryAuthenticationService(IUserService _userService) { this._userService = _userService; }
    private IUserService _userService { get; set; }
    private User authenticatedUser {get; set;}
    public bool IsAuthenticated {get; set;}
    public async Task AutheticateUserAsync(string email)
    {
        var users = await _userService.GetAllUsers();
        authenticatedUser = users.Where(u => u.UserEmail == email).First<User>();
        
        IsAuthenticated = true;
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

        return newUser;
    }

    public async Task<bool> IsUserRegisteredAsync(string email)
    {
        var users = await _userService.GetAllUsers();

        return users.FirstOrDefault(u => u.UserEmail == email) != null;
    }

    public User GetAuthenticatedUser() {return authenticatedUser;}
}