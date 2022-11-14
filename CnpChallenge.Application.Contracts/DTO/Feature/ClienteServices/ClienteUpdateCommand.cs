using CnpChallenge.Application.Contracts.Common.ClienteTypes;

namespace CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

public class ClienteUpdateCommand : ClienteBase
{
    public int Id { get; set; }
    public IEnumerable<ClienteUpdateCommandEndereco> Addresses { get; set; }
}

public class ClienteUpdateCommandEndereco : ClienteEnderecoBase
{
    public int? Id { get; set; }
}
