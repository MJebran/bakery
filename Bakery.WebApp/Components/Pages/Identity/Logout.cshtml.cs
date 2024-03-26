using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bakery.WebApp.Components.Pages.Identity;
public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnGetAsync(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        try
        {
            await HttpContext
                .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
        }
        catch (Exception ex)
        {
            var error = ex.Message;
        }

        return LocalRedirect(returnUrl);
    }
}
