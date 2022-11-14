using CnpChallenge.Application.Contracts.Common.ClienteTypes;
using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<IEnumerable<ClienteGetAllResponse>> GetAllClientes()
    {
        var result = await _clienteRepository.GetAll();

        return result.Select(c => new ClienteGetAllResponse
        {
            Id = c.Id,
            Addresses = c.Enderecos.Select(e => new ClienteEnderecoResponseBase
            {
                Id = e.Id,
                Address = e.Logradouro,
                City = e.Cidade,
                District = e.Bairro,
                State = e.Uf,
                Status = e.Status,
                ZipCode = e.Cep,
            }),
            BirthDate = c.DtNascimento,
            Name = c.Nome,
            Status = c.Status,
        });
    }
}