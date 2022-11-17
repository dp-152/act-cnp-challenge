using System.Net;
using System.Net.Mime;
using CnpChallenge.API.DTO.Cliente;
using CnpChallenge.Domain.Model.ClienteModel;
using CnpChallenge.IntegrationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;

namespace CnpChallenge.IntegrationTests.ClienteTests;

public partial class ClienteTests
{
    [Fact]
    public async Task Get_EndpointReturnsValidData()
    {
        await SeedDatabase("clientes_dataset");

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

    [Theory]
    [InlineData("/api/v1/cliente/0")]
    [InlineData("/api/v1/cliente/16")]
    [InlineData("/api/v1/cliente/1001")]
    public async Task Get_EndpointReturnsErrorForInvalidId(string url)
    {
        await SeedDatabase("clientes_dataset_skim");

        var response = await _client.GetAsync(url);

        response.Should().NotBeNull();
        response.Content.Headers.ContentType?.ToString().Should().Contain(MediaTypeNames.Text.Plain);
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Theory]
    [InlineData("/api/v1/cliente/a")]
    [InlineData("/api/v1/cliente/@")]
    public async Task Get_EndpointReturnsErrorForBadIdParameter(string url)
    {
        await SeedDatabase("clientes_dataset_skim");

        var response = await _client.GetAsync(url);

        response.Should().NotBeNull();
        response.Content.Headers.ContentType?.ToString().Should().Contain(MediaTypeNames.Application.Json);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}