using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.Application.Contracts.Common.ClienteTypes;

public class ClienteEnderecoResponseBase : ClienteEnderecoBase
{
    public int Id { get; set; }
    public EStatusCadastro Status { get; set; }
}
