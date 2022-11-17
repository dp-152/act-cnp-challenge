using System.Net.Mime;
using CnpChallenge.API.DTO.Cliente;
using CnpChallenge.Domain.Model.ClienteModel;
using CnpChallenge.Infrastructure.Context;
using CnpChallenge.IntegrationTests.Extensions.WebApplicationFactoryExtensions;
using CnpChallenge.IntegrationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;

namespace CnpChallenge.IntegrationTests.ClienteTests;

public class ClienteTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public ClienteTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Theory]
    [InlineData("/api/v1/cliente")]
    public async Task Get_EndpointReturnsSuccessAndCorrectContentType(string url)
    {
        var response = await _client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        response?.Content?.Headers?.ContentType?.ToString().Should().Contain(MediaTypeNames.Application.Json);
    }

    [Fact]
    public async Task Get_EndpointReturnsValidData()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<MainContext>();

            await DbSeedingHelper.SeedClientes(context, "clientes_dataset_skim");
        }

        var response = await _client.GetAsync("/api/v1/cliente/6");
        response.EnsureSuccessStatusCode();

        var content = JsonConvert.DeserializeObject<ClienteResponseDto>(await response.Content.ReadAsStringAsync());

        var comparisonSubject = await AssetsHelper.LoadJsonAsset<Cliente>("clienteid_6_data");

        content.Should().NotBeNull();

        content!.Id.Should().Be(6);
        content.Should().BeEquivalentTo(comparisonSubject, config => 
            config
                .Excluding(c => c.Path.EndsWith("ClienteId"))
                .Excluding(c => c.Path.EndsWith("Cliente"))
            );
    }
}