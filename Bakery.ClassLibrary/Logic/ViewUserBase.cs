using Microsoft.AspNetCore.Components;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.ClassLibrary.Logic;
public class ViewUserBase : ComponentBase
{
    [Inject]
    IUserService? _userService { get; set; }

    [Inject]
    NavigationManager? _navigationManager { get; set; }
    protected List<User> users { get; set; } = new();
    protected override async Task OnInitializedAsync()
    {
        users = (await _userService!.GetAllUsers()).ToList<User>();
    }
    public async Task DeleteUser(User userToDelete)
    {
        await _userService!.DeleteUser(userToDelete.UserId);
        if (_navigationManager is not null)
        {
            _navigationManager!.Refresh();
        }
    }

}