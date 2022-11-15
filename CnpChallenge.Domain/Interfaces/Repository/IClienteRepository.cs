using CnpChallenge.Domain.Model.ClienteModel;

namespace CnpChallenge.Domain.Interfaces.Repository;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> GetAll();
    Task<Cliente?> Get(int id);
    Task<Cliente> Create(Cliente data);
    Task<Cliente> Update(Cliente data);
    Task<bool> Delete(int id);
}
