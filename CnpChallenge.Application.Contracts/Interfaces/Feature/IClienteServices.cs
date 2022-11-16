using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

namespace CnpChallenge.Application.Contracts.Interfaces.Feature;

public interface IClienteServices
{
    Task<ClienteResponse> CreateCliente(ClienteCreateCommand command);
    Task DeleteCliente(ClienteDeleteCommand command);
    Task<IEnumerable<ClienteResponse>> GetAllClientes();
    Task<ClienteResponse> GetCliente(ClienteGetRequest request);
    Task<ClienteResponse> UpdateCliente(ClienteUpdateCommand command);
}
