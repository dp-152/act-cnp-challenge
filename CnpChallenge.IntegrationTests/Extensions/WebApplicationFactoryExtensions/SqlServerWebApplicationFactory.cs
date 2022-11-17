using CnpChallenge.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace CnpChallenge.IntegrationTests.Extensions.WebApplicationFactoryExtensions;

public class SqlServerWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    private IConfiguration? _configuration;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(configBuilder =>
        {
            _configuration = configBuilder.Build();
        });

        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MainContext>));
            if (descriptor is not null) services.Remove(descriptor);
            
            services.AddDbContext<MainContext>((_, optionsBuilder) =>
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(_configuration!.GetConnectionString("Testing"));
            });
        });

        builder.UseEnvironment("Development");
    }
}