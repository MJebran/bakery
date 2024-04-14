using System.Reflection.Metadata.Ecma335;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.WebApp.Authentication;

public class BakeryAuthenticationService : IBakeryAutheticationService
{
    public BakeryAuthenticationService(IUserService _userService, IRoleService _roleService) 
    { 
        this._userService = _userService; 
        this._roleService = _roleService;
    }
    private IUserService _userService { get; set; }
    private IRoleService _roleService {get; set;}
    public User? authenticatedUser {get; set;}
    public Role? authenticatedUserRole {get; set;}
    public async Task<User> RegisterUserAsync(string email, string name, string surname)
    {
        User newUser = new()
        {
            UserEmail = email,
            UserName = $"{name} {surname}",
            UserRoleId = 2
        };

        await _userService.AddUser(newUser);

        authenticatedUser = newUser;
        authenticatedUserRole = (await _roleService.GetAllRoles()).Where(r => r.RoleId == 2).FirstOrDefault();

        return newUser;
    }
    public async Task<bool> IsUserAuthenticatedAsync(string email)
    {
        var user = (await _userService.GetAllUsers()).FirstOrDefault(u => u.UserEmail == email);

        if(user is not null)
        {
            authenticatedUser = user;
            authenticatedUserRole = (await _roleService.GetAllRoles()).Where(r => r.RoleId == user.UserRoleId).FirstOrDefault();
            return true;
        }
        else
        {
            authenticatedUser = null;
            return false;
        }
    }
    public bool UserExists() => authenticatedUser != null;
    public User? GetAuthenticatedUser() { return authenticatedUser; }
    public Role? GetAuthenticatedUserRole() { return authenticatedUserRole; }
}