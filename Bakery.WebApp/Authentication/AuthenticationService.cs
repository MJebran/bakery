using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Authentication;

public class AuthenticationService : IAutheticationService
{
    AuthenticationService(IUserService _userService) { this._userService = _userService; }
    public bool IsAuthenticated { get; private set; }
    IUserService _userService { get; set; }
    public async Task<User> GetUser(string email)
    {
        if (email is not null)
        {
            var users = await _userService.GetAllUsers();
            return users.FirstOrDefault(u => u.UserEmail == email) ?? new User();
        }
        throw new Exception("no email provided");
    }

    public async Task<int> LookUpUserAsync( string email, string name, string surname)
    {
        if (email is not null)
        {
            var users = await _userService.GetAllUsers();
            var user = users.FirstOrDefault(u => u.UserEmail == email) ?? new User();

            if (user is null)
            {
                User newUser = new()
                {
                    UserEmail = email,
                    UserName = $"{name} {surname}",
                    UserRoleId = 1
                };

                await _userService.AddUser(newUser);
            }

            IsAuthenticated = true;

            return users.FirstOrDefault(u => u.UserEmail == email)!.UserId; 
        }
        throw new Exception("no email provided");
    }
}