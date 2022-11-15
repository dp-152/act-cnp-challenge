using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Domain.DTO.Manager;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> UpdateCliente(ClienteUpdateCommand command)
    {
        var request = new ClienteManagerUpdateRequest()
        {
            Nome = command.Nome,
            DtNascimento = command.DtNascimento,
            Enderecos = command.Enderecos?.Select(e => new ClienteManagerUpdateRequestEndereco()
            {
                Bairro = e.Bairro,
                Cep = e.Cep,
                Cidade = e.Cidade,
                Logradouro = e.Endereco,
                Uf = e.Uf
            })
        };

        var createdObject = await _clienteManager.Update(request);
        var result = await _clienteRepository.Update(createdObject);
        
        return new ClienteResponse() {
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