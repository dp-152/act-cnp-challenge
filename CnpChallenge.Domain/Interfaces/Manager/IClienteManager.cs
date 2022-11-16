using CnpChallenge.Domain.DTO.Manager;
using CnpChallenge.Domain.Manager;
using CnpChallenge.Domain.Model.ClienteModel;

namespace CnpChallenge.Domain.Interfaces.Manager;

public interface IClienteManager
{
    Task<Cliente> Create(ClienteManagerCreateRequest request);
    Task Update(ClienteManagerUpdateRequest request, Cliente source);
}
