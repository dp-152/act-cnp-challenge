using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<IEnumerable<ClienteResponse>> GetAllClientes()
    {
        var result = await _clienteRepository.GetAll();

        return _mapper.Map<IEnumerable<ClienteResponse>>(result);
    }
}