using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Bakery.WebApp.Data;
 
namespace Bakery.Mobile.MauiAuth0;
 
public class MauiAuthManager(HttpClient client) //: IAuthenticationManager
{
    private Task<AuthenticationState>? authenticationState = null;
    private AuthenticationState? state;
    public User? User { get; set; } = null;

    private async Task GetAuthState()
    {
        if (authenticationState == null)
        {
            return;
        }

        if (state is null)
        {
            state = await authenticationState;
        }
    }

    public async Task SetAuthState(Task<AuthenticationState>? authState)
    {
        authenticationState = authState;
        await GetAuthState();
    }

    public async Task<bool> IsUserLoggedIn()
    {
        await GetAuthState();

        if (state is null) { return false; }
        if (state.User.Identity is null) { return false; }
        if (state.User.Identity.IsAuthenticated is false) { return false; }

        string email = await GetUserEmail();
        User = await GetUserFromEmail(email);

        return true;
    }

    public async Task<User> GetUserFromEmail(string email)
    {
        User? result = null;
        try
        {
            result = await client.GetFromJsonAsync<User>($"api/customer/get_by_email/{email}");
        }
        catch { }

        if (result is null)
        {
            return await CreateUser();
        }

        return result;
    }

    public async Task<User> CreateUser()
    {
        await GetAuthState();
        if (state is null) { throw new NullReferenceException("Error: User is not logged in!"); }

        User user = new()
        {
            UserName = state!.User!.Identity!.Name,
            UserEmail = state.User.Claims
                        .Where(c => c.Type.Contains("emailaddress"))
                        .FirstOrDefault()!.Value
        };

        await client.PostAsJsonAsync("api/customer/add", user);

        return user;
    }

    public async Task<string> GetUserEmail()
    {
        await GetAuthState();
        if (state is null) { throw new NullReferenceException("Error: User is not logged in!"); }

        var user = state.User.Claims
            .Where(c => c.Type.Contains("emailaddress"))
            .FirstOrDefault();

        if (user is null) { throw new NullReferenceException("Error: User has no email!"); }
        return user.Value;
    }
}