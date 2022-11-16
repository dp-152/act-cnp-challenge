using CnpChallenge.Domain.DTO.Manager;
using CnpChallenge.Domain.Model.ClienteModel;
using CnpChallenge.Domain.Shared.Enum;
using FluentValidation;

namespace CnpChallenge.Domain.Manager;

public partial class ClienteManager
{
    public Cliente Create(ClienteManagerCreateRequest request)
    {
        _createRequestValidator.ValidateAndThrow(request);

        return new Cliente
        {
            Nome = request.Nome,
            DtNascimento = request.DtNascimento,
            Enderecos = request.Enderecos.Select(e => new ClienteEndereco
            {
                Bairro = e.Bairro,
                Cep = e.Cep,
                Cidade = e.Cidade,
                Logradouro = e.Logradouro,
                Uf = e.Uf,
                Status = EStatusCadastro.Ativo,
            }).ToList(),
            Status = EStatusCadastro.Ativo
        };
    }
}
