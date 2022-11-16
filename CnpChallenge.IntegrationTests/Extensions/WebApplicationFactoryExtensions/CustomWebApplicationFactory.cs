using CnpChallenge.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CnpChallenge.IntegrationTests.Extensions.WebApplicationFactoryExtensions;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    private readonly SqliteConnection _keepAliveConnection;
    
    public CustomWebApplicationFactory()
    {
        _keepAliveConnection = new SqliteConnection("DataSource=testdb;mode=memory;cache=shared");
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        _keepAliveConnection.Open();
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MainContext>));
            if (descriptor is not null) services.Remove(descriptor);
            
            services.AddDbContext<MainContext>((_, optionsBuilder) =>
            {
                optionsBuilder
                    .UseSqlite(_keepAliveConnection);
            });
        });

        builder.UseEnvironment("Development");
    }

    protected override void Dispose(bool disposing)
    {
        _keepAliveConnection.Close();
        base.Dispose(disposing);
    }
}