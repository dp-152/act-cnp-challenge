using CnpChallenge.Application.Contracts.Common.ClienteTypes;

namespace CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

public class ClienteCreateCommand : ClienteBase
{
    public IEnumerable<ClienteCreateCommandEndereco> Addresses { get; set; }
}

public class ClienteCreateCommandEndereco : ClienteEnderecoBase
{
}