using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Application.Contracts.Exceptions;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> GetCliente(ClienteGetRequest request)
    {
        var result = await _clienteRepository.Get(request.Id);
        if (result is null) throw new ResourceNotFoundException($"ID = {request.Id}");

        return new ClienteResponse
        {
            Id = result.Id,
            Enderecos = result.Enderecos.Select(e => new ClienteEnderecoResponse
            {
                Id = e.Id,
                Logradouro = e.Logradouro,
                Cidade = e.Cidade,
                Bairro = e.Bairro,
                Uf = e.Uf,
                Status = e.Status,
                Cep = e.Cep,
            }),
            DtNascimento = result.DtNascimento,
            Nome = result.Nome,
            Status = result.Status,
        };
    }
}