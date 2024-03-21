using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Components;
using Bakery.WebApp.Data;
using Bakery.WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<ISizeService, SizeService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IToppingService, ToppingService>();
builder.Services.AddSingleton<IRoleService, RoleService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IItemTypeService, ItemTypeService>();
builder.Services.AddSingleton<ICustomItemService, CustomItemService>();
builder.Services.AddSingleton<IPurchaseService, PurchaseService>();
builder.Services.AddSingleton<ICustomItemService, CustomItemService>();
builder.Services.AddSingleton<IFavoriteItemService, FavoriteItemService>();
builder.Services.AddSingleton<IBlobStorageService, BlobService>();

//Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<PostgresContext>(options => options.UseNpgsql("Name=db"));



builder.Services.AddAuthentication("Cookies")
              .AddCookie(opt =>
              {
                  opt.Cookie.Name = "TryingoutGoogleOAuth";
                  opt.LoginPath = "/google-login";
              })
              .AddGoogle(opt =>
              {
                  opt.ClientId = builder.Configuration["ClientId"];
                  opt.ClientSecret = builder.Configuration["ClientSecret"];
                  opt.CallbackPath = "/google-login";
              });

//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? "";
//    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? "";
//});

var app = builder.Build();

// Swagger Components
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public partial class Program { }
