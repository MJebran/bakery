using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicalToyMachine.Data;
using System.Security.Claims;

namespace MythicalToyMachine.Pages.Identity
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUserRoleService userRoleService;

        public LoginModel(IUserRoleService userRoleService)
        {
            this.userRoleService = userRoleService;
        }
        public IActionResult OnGetAsync(string returnUrl = null)
        {
            string provider = "Google";
            // Request a redirect to the external login provider.
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Page("./Login",
                pageHandler: "Callback",
                values: new { returnUrl }),
            };
            return new ChallengeResult(provider, authenticationProperties);
        }
        public async Task<IActionResult> OnGetCallbackAsync(
            string returnUrl = null, string remoteError = null)
        {
            // Get the information about the user from the external login provider
            var GoogleUser = this.User.Identities.FirstOrDefault();
            if (GoogleUser.IsAuthenticated)
            {
                await userRoleService.LookUpUserAsync(GoogleUser.FindFirst(ClaimTypes.Email).Value,
                    GoogleUser.FindFirst(ClaimTypes.Name).Value,
                    GoogleUser.FindFirst(ClaimTypes.Surname).Value
                    );
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(GoogleUser),
                authProperties);
            }
            return LocalRedirect("/"); //TODO: Find a way to send you back to the page you were on instead of index every time
        }
    }
}
