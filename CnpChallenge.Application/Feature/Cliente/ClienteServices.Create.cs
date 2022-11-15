using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Domain.DTO.Manager;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> CreateCliente(ClienteCreateCommand command)
    {
        var request = new ClienteManagerCreateRequest
        {
            Nome = command.Nome,
            DtNascimento = command.DtNascimento,
            Enderecos = command.Enderecos.Select(e => new ClienteManagerCreateRequestEndereco
            {
                Bairro = e.Bairro,
                Cep = e.Cep,
                Cidade = e.Cidade,
                Logradouro = e.Logradouro,
                Uf = e.Uf
            })
        };

        var createdObject = await _clienteManager.Create(request);
        var result = await _clienteRepository.Create(createdObject);
        
        return new ClienteResponse {
            Id = result.Id,
            Nome = result.Nome,
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
            Status = result.Status,
            DtNascimento = result.DtNascimento,
        };
    }
}