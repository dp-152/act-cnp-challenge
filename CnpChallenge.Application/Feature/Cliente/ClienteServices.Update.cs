using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Application.Contracts.Exceptions;
using CnpChallenge.Domain.DTO.Manager;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> UpdateCliente(ClienteUpdateCommand command)
    {
        var source = await _clienteRepository.Get(command.Id);
        if (source is null) throw new ResourceNotFoundException($"ID = {command.Id}");
        
        var request = _mapper.Map<ClienteManagerUpdateRequest>(command);

        _clienteManager.Update(request, source);
        var result = await _clienteRepository.Update(source);

        return _mapper.Map<ClienteResponse>(result);
    }
}