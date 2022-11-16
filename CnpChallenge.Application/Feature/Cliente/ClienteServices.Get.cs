using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Application.Contracts.Exceptions;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> GetCliente(ClienteGetRequest request)
    {
        try
        {
            var result = await _clienteRepository.Get(request.Id);
            if (result is null) throw new ResourceNotFoundException($"ID = {request.Id}");

            return _mapper.Map<ClienteResponse>(result);
        }
        catch (ResourceNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalException(false, innerException: ex);
        }
    }
}