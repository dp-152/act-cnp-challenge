using CnpChallenge.Domain.DTO.Manager;
using CnpChallenge.Domain.Model.ClienteModel;
using CnpChallenge.Domain.Shared.Enum;
using FluentValidation;

namespace CnpChallenge.Domain.Manager;

public partial class ClienteManager
{
    public async Task<Cliente> Update(ClienteManagerUpdateRequest request, Cliente source)
    {
        _updateRequestValidator.ValidateAndThrow(request);

        if (request.Nome is not null)
        {
            source.Nome = request.Nome;
        }

        if (request.DtNascimento.HasValue)
        {
            source.DtNascimento = request.DtNascimento.Value;
        }

        if (request.Enderecos is not null)
        {
            var resolvedAddressList = ResolveAddressMerge(request.Enderecos, source.Enderecos);
            source.Enderecos = resolvedAddressList;
        }

        return source;
    }

    private IEnumerable<ClienteEndereco> ResolveAddressMerge(IEnumerable<ClienteManagerUpdateRequestEndereco> input,
        IEnumerable<ClienteEndereco> source)
    {
        var result = new List<ClienteEndereco>();
        source = source.ToList();

        foreach (var element in input)
        {
            ClienteEndereco mergeResult;
            if (element.Id.HasValue)
            {
                mergeResult = source.FirstOrDefault(e => e.Id == element.Id) ?? throw new Exception();

                if (element.Bairro is not null)
                    mergeResult.Bairro = element.Bairro;

                if (element.Cep is not null)
                    mergeResult.Cep = element.Cep;

                if (element.Cidade is not null)
                    mergeResult.Cidade = element.Cidade;

                if (element.Logradouro is not null)
                    mergeResult.Logradouro = element.Logradouro;

                if (element.Uf is not null)
                    mergeResult.Uf = element.Uf;
            }
            else
            {
                mergeResult = new ClienteEndereco
                {
                    Bairro = element.Bairro!,
                    Cep = element.Cep!,
                    Cidade = element.Cidade!,
                    Logradouro = element.Logradouro!,
                    Uf = element.Uf!,
                    Status = EStatusCadastro.Ativo,
                };
            }

            result.Add(mergeResult);
        }
        
        return result;
    }
}
