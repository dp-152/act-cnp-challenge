using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Application.Contracts.Exceptions;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<IEnumerable<ClienteResponse>> GetAllClientes()
    {
        try
        {
            var result = await _clienteRepository.GetAll();

            return _mapper.Map<IEnumerable<ClienteResponse>>(result);
        }
        catch (Exception ex)
        {
            throw new InternalException(false, innerException: ex);
        }
    }
}