using Microsoft.Extensions.Logging;
using Bakery.Mobile.Services;
using Bakery.ClassLibrary.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;
using Bakery.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Bakery.ClassLibrary.Logic;
using System.Text.Json.Serialization;


namespace Bakery.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services
            .AddSingleton<ISizeService, SizeService>()
            .AddSingleton<ISizeService, SizeService>()
            .AddSingleton<ICategoryService, CategoryService>()
            .AddSingleton<IToppingService, ToppingService>()
            .AddSingleton<IRoleService, RoleService>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<IItemTypeService, ItemTypeService>()
            .AddSingleton<ICustomItemService, CustomItemService>()
            .AddSingleton<IPurchaseService, PurchaseService>()
            .AddSingleton<ICustomItemService, CustomItemService>()
            .AddSingleton<ICustomeItemToppingService, CustomeItemToppingService>()
            .AddSingleton<IItemPurchaseService, ItemPurchaseService>()
            .AddSingleton<IFavoriteItemService, FavoriteItemService>()
            .AddSingleton<IBakeryAutheticationService, BakeryAuthenticationService>()
            .AddScoped<HttpClient>()
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie().Services
            .AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication_Google_ClientId"] ?? throw new Exception("Client Id not found");
                options.ClientSecret = builder.Configuration["Authentication_Google_ClientSecret"] ?? throw new Exception("Client secret not found");
                options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                options.ClaimActions.MapJsonKey("urn:google:image", "picture");
            });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
