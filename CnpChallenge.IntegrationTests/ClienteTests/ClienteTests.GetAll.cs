using CnpChallenge.API.DTO.Cliente;
using CnpChallenge.Domain.Model.ClienteModel;
using CnpChallenge.IntegrationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;

namespace CnpChallenge.IntegrationTests.ClienteTests;

public partial class ClienteTests
{
    [Fact]
    public async Task GetAll_EndpointReturnsAllItems()
    {
        await SeedDatabase("clientes_dataset");

        var response = await _client.GetAsync("api/v1/cliente");

        response.EnsureSuccessStatusCode();

        var content =
            JsonConvert.DeserializeObject<List<ClienteResponseDto>>(await response.Content.ReadAsStringAsync());

        content.Should().NotBeNull();
        content!.Count.Should().Be(1000);

        var comparisonSubject = await AssetsHelper.LoadJsonAsset<Cliente>("clienteid_15_data");

        var selectedCliente = content.First(c => c.Id == 15);

        selectedCliente!.Id.Should().Be(15);
        selectedCliente.Should().BeEquivalentTo(comparisonSubject, config =>
            config
                .Excluding(c => c.Path.EndsWith("ClienteId"))
                .Excluding(c => c.Path.EndsWith("Cliente"))
            );

    }
}