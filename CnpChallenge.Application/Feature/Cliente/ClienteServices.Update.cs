using CnpChallenge.Application.Contracts.Common.ClienteTypes;
using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Domain.DTO.Manager;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteUpdateResponse> UpdateCliente(ClienteUpdateCommand command)
    {
        var request = new ClienteManagerUpdateRequest()
        {
            Nome = command.Name,
            DtNascimento = command.BirthDate,
            Enderecos = command.Addresses?.Select(e => new ClienteManagerUpdateRequestEndereco()
            {
                Bairro = e.District,
                Cep = e.ZipCode,
                Cidade = e.City,
                Logradouro = e.Address,
                Uf = e.State
            })
        };

        var createdObject = await _clienteManager.Update(request);
        var result = await _clienteRepository.Update(createdObject);
        
        return new ClienteUpdateResponse() {
            Id = result.Id,
            Name = result.Nome,
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
            Status = result.Status,
            BirthDate = result.DtNascimento,
        };
    }
}