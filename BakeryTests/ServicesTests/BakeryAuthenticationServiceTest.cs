using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;
using Bakery.WebApp.Data;

public class BakeryAutheticationServiceTest : IBakeryAutheticationService
{
    private IUserService _userService { get; set; }
    private IRoleService _roleService { get; set; }
    public User? authenticatedUser { get; set; }
    public Role? authenticatedUserRole { get; set; }
    public BakeryAutheticationServiceTest(IUserService _userService, IRoleService _roleService)
    {
        this._userService = _userService;
        this._roleService = _roleService;
    }

    public User? GetAuthenticatedUser()
    {
         return authenticatedUser;
    }

    public Role? GetAuthenticatedUserRole()
    {
        return authenticatedUserRole;
    }

    public async Task<bool> IsUserAuthenticatedAsync(string email)
    {
        var user = (await _userService.GetAllUsers()).FirstOrDefault(u => u.UserEmail == email);

        if (user is not null)
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

    public bool UserExists()
    {
        return authenticatedUser != null;
    }
}