using Microsoft.Extensions.Logging;
using Bakery.Mobile.Services;
using Bakery.ClassLibrary.Services;

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
            .AddScoped<HttpClient>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
