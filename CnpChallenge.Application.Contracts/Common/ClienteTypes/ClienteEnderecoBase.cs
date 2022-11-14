using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.Application.Contracts.Common.ClienteTypes;

public class ClienteEnderecoBase
{
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public EStatusCadastro Status { get; set; }
}