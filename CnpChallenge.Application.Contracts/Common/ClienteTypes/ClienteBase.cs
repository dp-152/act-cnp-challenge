using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.Application.Contracts.Common.ClienteTypes;

public class ClienteBase
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public EStatusCadastro Status { get; set; }
}