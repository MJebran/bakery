using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;
using Bakery.WebApp.Data;
using Bakery.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Bakery.WebApp.Components;
using System.Text.Json.Serialization;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Bakery.WebApp.Telemetry;

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

builder.Services.AddSingleton<PopularPagesMetric>();
builder.Services.AddSingleton<ExampleHandler>();

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

builder.Services.AddHealthChecks();

builder.Services.AddOpenTelemetry()
.WithMetrics(b =>
    {
        b
        .AddAspNetCoreInstrumentation()
        .AddMeter(PopularPagesMetric.MetricName)
        .AddPrometheusExporter()
        .AddOtlpExporter(o =>
        {
            o.Endpoint = new Uri("http://kakey1-collector:4317/"); //MIGHT NEED TO CHANGE This to otel-collector
        });
    }); ;

builder.Logging.AddOpenTelemetry(logs => 
    logs
        .AddConsoleExporter()
        .AddOtlpExporter(o =>
        {
            o.Endpoint = new Uri("http://kakey1-collector:4317/");// Might be the other direccion
        }));

using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(logging =>
    {
        logging.AddOtlpExporter();
    });
});


builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

var handler = app.Services.GetRequiredService<ExampleHandler>();
// app.MapGet("/log", ()=> {
//     Meters.LurisCount += 1
// })
// handler.HandleRequest());
app.MapGet("/log1", ()=>handler.HandleRequest());
app.MapGet("/log2", ()=>handler.HandleRequest());
app.MapGet("/log3", ()=>handler.HandleRequest());
app.MapGet("/log4", ()=>handler.HandleRequest());
app.MapGet("/log5", ()=>handler.HandleRequest());

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Heathchecks

app.MapHealthChecks("/health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
});

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

//Swagger
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.Run();

public partial class Program { }
