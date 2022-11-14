using CnpChallenge.Application.Contracts.Common.ClienteTypes;
using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteGetResponse?> GetCliente(ClienteGetRequest request)
    {
        var result = await _clienteRepository.Get(request.Id);
        if (result is null) return null;

        return new ClienteGetResponse
        {
            Id = result.Id,
            Addresses = result.Enderecos.Select(e => new ClienteEnderecoResponseBase
            {
                Id = e.Id,
                Address = e.Logradouro,
                City = e.Cidade,
                District = e.Bairro,
                State = e.Uf,
                Status = e.Status,
                ZipCode = e.Cep,
            }),
            BirthDate = result.DtNascimento,
            Name = result.Nome,
            Status = result.Status,
        };
    }
}