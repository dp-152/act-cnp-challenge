using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Domain.DTO.Manager;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> CreateCliente(ClienteCreateCommand command)
    {
        var request = _mapper.Map<ClienteManagerCreateRequest>(command);

        var createdObject = await _clienteManager.Create(request);
        var result = await _clienteRepository.Create(createdObject);

        return _mapper.Map<ClienteResponse>(result);
    }
}