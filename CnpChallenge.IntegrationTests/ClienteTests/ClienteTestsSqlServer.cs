using CnpChallenge.Infrastructure.Context;
using CnpChallenge.IntegrationTests.Extensions.WebApplicationFactoryExtensions;
using CnpChallenge.IntegrationTests.Helpers;

namespace CnpChallenge.IntegrationTests.ClienteTests;

public partial class ClienteTestsSqlServer : IClassFixture<SqlServerWebApplicationFactory<Program>>
{
    
    private readonly SqlServerWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public ClienteTestsSqlServer(SqlServerWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    private async Task SeedDatabase(string dataset)
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<MainContext>();
            await DbSeedingHelper.ResetClientes(context, dataset);
        }
    }
}