using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Bakery.WebApp.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace Bakery.ClassLibrary.Logic;
public class LoginControlBase : ComponentBase
{
    [Inject]
    AuthenticationStateProvider? AuthenticationStateProvider { get; set; }
    [Inject]
    IBakeryAutheticationService? _authenticationService { get; set; }
    protected ClaimsPrincipal? User;
    protected string? GivenName;
    protected string? Surname;
    protected string? Email;
    protected string? Avatar;
    protected override async Task OnInitializedAsync()
    {
        User = (await AuthenticationStateProvider!.GetAuthenticationStateAsync()).User;

        var givenName = User.FindFirst(ClaimTypes.GivenName);
        GivenName = givenName?.Value ?? "";

        var surname = User.FindFirst(ClaimTypes.Surname);
        Surname = surname?.Value ?? "";

        var avatar = User.FindFirst("urn:google:image");
        Avatar = avatar != null ? avatar.Value : "";

        var email = User.FindFirst(ClaimTypes.Email);
        Email = email?.Value ?? "";

        if (!await _authenticationService!.IsUserAuthenticatedAsync(Email))
        {
            if (Email != "unknown" && Email != "")
            {
                await _authenticationService.RegisterUserAsync(Email, GivenName, Surname);
            }
        }
    }
}