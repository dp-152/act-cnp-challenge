using System.Net;
using System.Net.Mime;
using System.Text;
using CnpChallenge.API.DTO.Cliente;
using CnpChallenge.IntegrationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;

namespace CnpChallenge.IntegrationTests.ClienteTests;

public partial class ClienteTestsSqlServer
{
    [Fact]
    public async Task Create_EndpointCreatesAValidEntry()
    {
        await SeedDatabase("empty");
        var requestBody = await AssetsHelper.LoadJsonAssetAsString("cliente_data");
        var content = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);

        var response = await _client.PostAsync("/api/v1/cliente", content);
        response.Should().NotBeNull();
        response.EnsureSuccessStatusCode();

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseData = JsonConvert.DeserializeObject<ClienteResponseDto>(await response.Content.ReadAsStringAsync());
        var requestData = JsonConvert.DeserializeObject<ClienteRequestDto>(requestBody);

        responseData.Should().BeEquivalentTo(requestData, options =>
            options
                .Excluding(o => o.Path.Contains("Id"))
                .Excluding(o => o.Path.Contains("DatInclusao"))
                .Excluding(o => o.Path.Contains("Status"))
        );
    }

    [Fact]
    public async Task Create_EndpointReturnsErrorForInvalidData()
    {
        var requestBody = await AssetsHelper.LoadJsonAssetAsString("cliente_data_invalid");
        var content = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);

        var response = await _client.PostAsync("/api/v1/cliente", content);
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Create_EndpointReturnsErrorForMissingFields()
    {
        var requestBody = await AssetsHelper.LoadJsonAssetAsString("cliente_data_partial");
        var content = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);

        var response = await _client.PostAsync("/api/v1/cliente", content);
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
