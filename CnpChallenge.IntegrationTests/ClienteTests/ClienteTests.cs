using System.Net.Mime;
using CnpChallenge.IntegrationTests.Extensions.WebApplicationFactoryExtensions;
using FluentAssertions;

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
}