using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Domain.DTO.Manager;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> UpdateCliente(ClienteUpdateCommand command)
    {
        var request = _mapper.Map<ClienteManagerUpdateRequest>(command);

        var createdObject = await _clienteManager.Update(request);
        var result = await _clienteRepository.Update(createdObject);

        return _mapper.Map<ClienteResponse>(result);
    }
}