using System.Net;
using System.Net.Mime;
using System.Text;
using CnpChallenge.API.DTO.Cliente;
using CnpChallenge.Domain.Model.ClienteModel;
using CnpChallenge.IntegrationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;

namespace CnpChallenge.IntegrationTests.ClienteTests;

public partial class ClienteTestsSqlServer
{
    [Fact]
    public async Task Update_EndpointUpdatesEntryWhenValidInput()
    {
        await SeedDatabase("clientes_dataset_update");

        var getRequest = await _client.GetAsync("api/v1/cliente");
        var subject =
            JsonConvert.DeserializeObject<List<ClienteResponseDto>>(await getRequest.Content.ReadAsStringAsync())!.First();

        var requestBody = await AssetsHelper.LoadJsonAssetAsString("cliente_data");
        var requestContent = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);

        var putRequest = await _client.PutAsync($"/api/v1/cliente/{subject.Id}", requestContent);
        putRequest.Should().NotBeNull();
        putRequest.EnsureSuccessStatusCode();

        var content = JsonConvert.DeserializeObject<ClienteResponseDto>(await putRequest.Content.ReadAsStringAsync());

        content.Should().NotBeEquivalentTo(subject);
    }

    [Fact]
    public async Task Update_EndpointUpdatesEntryWhenValidPartialInput()
    {
        await SeedDatabase("clientes_dataset_update");

        var getRequest = await _client.GetAsync("api/v1/cliente");
        var subject =
            JsonConvert.DeserializeObject<List<ClienteResponseDto>>(await getRequest.Content.ReadAsStringAsync())!.First();

        var updateObject = await AssetsHelper.LoadJsonAsset<Cliente>("cliente_data_partial");
        for (var enderecoIndex = 0; enderecoIndex < subject.Enderecos.Count(); enderecoIndex++)
        {
            updateObject.Enderecos.ElementAt(enderecoIndex).Id = subject.Enderecos.ElementAt(enderecoIndex).Id;
        }

        var requestBody = JsonConvert.SerializeObject(updateObject, Formatting.None, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
        });
        var requestContent = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);

        var putRequest = await _client.PutAsync($"/api/v1/cliente/{subject.Id}", requestContent);
        putRequest.Should().NotBeNull();
        putRequest.EnsureSuccessStatusCode();

        var content = JsonConvert.DeserializeObject<ClienteResponseDto>(await putRequest.Content.ReadAsStringAsync());

        content.Should().NotBeEquivalentTo(subject);
    }

    [Fact]
    public async Task Update_EnpointReturnsErrorWhenInvalidData()
    {
        var requestBody = await AssetsHelper.LoadJsonAssetAsString("cliente_data_invalid");
        var requestContent = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);

        var request = await _client.PutAsync("/api/v1/cliente/5", requestContent);
        request.Should().NotBeNull();
        request.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
