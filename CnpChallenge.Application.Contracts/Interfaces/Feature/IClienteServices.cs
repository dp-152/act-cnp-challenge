using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

namespace CnpChallenge.Application.Contracts.Interfaces.Feature;

public interface IClienteServices
{
    Task<ClienteCreateResponse> CreateCliente(ClienteCreateCommand command);
    Task<ClienteDeleteResponse> DeleteCliente(ClienteDeleteCommand command);
    Task<IEnumerable<ClienteGetAllResponse>> GetAllClientes();
    Task<ClienteGetResponse?> GetCliente(ClienteGetRequest request);
    Task<ClienteUpdateResponse> UpdateCliente(ClienteUpdateCommand command);
}
