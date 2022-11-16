using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Application.Contracts.Exceptions;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task DeleteCliente(ClienteDeleteCommand command)
    {
        var result = await _clienteRepository.Delete(command.Id);

        if (!result) throw new ResourceNotFoundException($"ID = {command.Id}");
    }
}
