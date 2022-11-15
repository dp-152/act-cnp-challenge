using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteDeleteResponse> DeleteCliente(ClienteDeleteCommand command)
    {
        var result = await _clienteRepository.Delete(command.Id);

        return new ClienteDeleteResponse
        {
            IsDeleted = result,
        };
    }
}
