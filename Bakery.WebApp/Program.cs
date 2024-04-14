using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;
using Bakery.WebApp.Data;
using Bakery.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Bakery.WebApp.Logic;
using Bakery.WebApp.Components;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorPages(options =>
    {
        options.RootDirectory = "/Components/Pages/Identity";
    }).Services
    .AddServerSideBlazor().Services
    .AddSingleton<ISizeService, SizeService>()
    .AddSingleton<IEmailService, EmailService>()
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
    .AddSingleton<IBlobStorageService, BlobService>()
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


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

//Swagger
builder.Services.AddControllers();
// added this to deal with A possible object cycle was detected.
builder.Services.AddControllers().AddJsonOptions(x =>
           x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<PostgresContext>(options => options.UseNpgsql("Name=db"));

builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseCookiePolicy()
    .UseAuthentication()
    .UseRouting()
    .UseAntiforgery();

app.MapRazorPages();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Bakery.ClassLibrary.Components.Home).Assembly);



//app.MapBlazorHub();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();

public partial class Program { }
