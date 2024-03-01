using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Testcontainers.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Bakery.WebApp.Data;

namespace BakeryTests
{
    public class BakeryWebAPIFactory :  WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer;

        public BakeryWebAPIFactory()
        {
            var backupFile = Directory.GetFiles("../../../..", "*.sql", SearchOption.AllDirectories)
                .Select(f => new FileInfo(f))
                .OrderByDescending(fi => fi.LastWriteTime)
                .First();

            _dbContainer = new PostgreSqlBuilder()
              .WithImage("postgres")
              .WithPassword("Password@123")
              .WithBindMount(backupFile.FullName, "/docker-entrypoint-initdb.d/init.sql")
              .Build();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                //var connection = _dbContainer.GetConnectionString();
                services.RemoveAll(typeof(DbContextOptions<PostgresContext>));
                services.AddDbContext<PostgresContext>(options => options.UseNpgsql(_dbContainer.GetConnectionString()));
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
        }
        async Task IAsyncLifetime.DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }
    }
}
