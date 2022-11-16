using CnpChallenge.Domain.DTO.Manager;
using CnpChallenge.Domain.Manager;
using CnpChallenge.Domain.Model.ClienteModel;

namespace CnpChallenge.Domain.Interfaces.Manager;

public interface IClienteManager
{
    Cliente Create(ClienteManagerCreateRequest request);
    void Update(ClienteManagerUpdateRequest request, Cliente source);
}
