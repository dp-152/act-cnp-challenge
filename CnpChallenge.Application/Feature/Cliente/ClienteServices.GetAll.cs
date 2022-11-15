using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<IEnumerable<ClienteResponse>> GetAllClientes()
    {
        var result = await _clienteRepository.GetAll();

        return result.Select(c => new ClienteResponse
        {
            Id = c.Id,
            Enderecos = c.Enderecos.Select(e => new ClienteEnderecoResponse
            {
                Id = e.Id,
                Logradouro = e.Logradouro,
                Cidade = e.Cidade,
                Bairro = e.Bairro,
                Uf = e.Uf,
                Status = e.Status,
                Cep = e.Cep,
            }),
            DtNascimento = c.DtNascimento,
            Nome = c.Nome,
            Status = c.Status,
        });
    }
}