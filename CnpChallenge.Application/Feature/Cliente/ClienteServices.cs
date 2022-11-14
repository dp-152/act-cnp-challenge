using CnpChallenge.Application.Contracts.Interfaces.Feature;
using CnpChallenge.Domain.Interfaces.Manager;
using CnpChallenge.Domain.Interfaces.Repository;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices : IClienteServices
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IClienteManager _clienteManager;

    public ClienteServices(IClienteRepository clienteRepository, IClienteManager clienteManager)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _clienteManager = clienteManager ?? throw new ArgumentNullException(nameof(clienteManager));
    }
}
