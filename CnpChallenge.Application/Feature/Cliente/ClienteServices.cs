using CnpChallenge.Application.Contracts.Interfaces.Feature;
using CnpChallenge.Domain.Interfaces.Repository;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices : IClienteServices
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteServices(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
    }
}
