using System.Net;
using FluentAssertions;

namespace CnpChallenge.IntegrationTests.ClienteTests;

public partial class ClienteTests
{
    [Theory]
    [InlineData("/api/v1/cliente/6")]
    [InlineData("/api/v1/cliente/15")]
    public async Task Delete_EnsureItemIsDeleted(string url)
    {
        await SeedDatabase("clientes_dataset_skim");

        var getResponse = await _client.GetAsync(url);
        getResponse.EnsureSuccessStatusCode();
        getResponse.Should().NotBeNull();

        var deleteResponse = await _client.DeleteAsync(url);
        deleteResponse.EnsureSuccessStatusCode();
        deleteResponse.Should().NotBeNull();
        deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var getPostDeleteResponse = await _client.GetAsync(url);
        getPostDeleteResponse.Should().NotBeNull();
        getPostDeleteResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Theory]
    [InlineData("/api/v1/cliente/0")]
    [InlineData("/api/v1/cliente/16")]
    [InlineData("/api/v1/cliente/1001")]
    public async Task Delete_EndpointReturnsErrorForInvalidId(string url)
    {
        await SeedDatabase("clientes_dataset_skim");

        var response = await _client.DeleteAsync(url);
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Theory]
    [InlineData("/api/v1/cliente/a")]
    [InlineData("/api/v1/cliente/@")]
    public async Task Delete_EndpointReturnsErrorForBadIdParameter(string url)
    {
        var response = await _client.DeleteAsync(url);
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}