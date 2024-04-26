using Auth0.OidcClient;
using Bakery.WebApp.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Bakery.Mobile.MauiAuth0;

public class Auth0AuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());
    private readonly Auth0Client auth0Client;
    IBakeryAutheticationService? _authenticationService;

    public Auth0AuthenticationStateProvider(Auth0Client client, IBakeryAutheticationService? authenticationService)
    {
        auth0Client = client;
        _authenticationService = authenticationService;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(new AuthenticationState(currentUser));

    public Task LogInAsync()
    {
        var loginTask = LogInAsyncCore();
        NotifyAuthenticationStateChanged(loginTask);

        return loginTask;

        async Task<AuthenticationState> LogInAsyncCore()
        {
            var user = await LoginWithAuth0Async();
            currentUser = user;
            //if (!await _authenticationService!.IsUserAuthenticatedAsync(Email))
            //{
            //    if (Email != "unknown" && Email != "")
            //    {
            //        await _authenticationService.RegisterUserAsync(Email, GivenName, Surname);
            //    }
            //}
            return new AuthenticationState(currentUser);
        }
    }

    private async Task<ClaimsPrincipal> LoginWithAuth0Async()
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());
        var loginResult = await auth0Client.LoginAsync();

        if (!loginResult.IsError)
        {
            authenticatedUser = loginResult.User;
        }
        return authenticatedUser;
    }

    public async void LogOut()
    {
        await auth0Client.LogoutAsync();
        currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(currentUser)));
    }
}