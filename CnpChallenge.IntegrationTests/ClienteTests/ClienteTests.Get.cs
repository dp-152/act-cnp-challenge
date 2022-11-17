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
}