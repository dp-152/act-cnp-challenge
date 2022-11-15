using CnpChallenge.Domain.DTO.Manager;
using CnpChallenge.Domain.Interfaces.Manager;
using CnpChallenge.Domain.Interfaces.Repository;
using FluentValidation;

namespace CnpChallenge.Domain.Manager;

public partial class ClienteManager : IClienteManager
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IValidator<ClienteManagerCreateRequest> _createRequestValidator;
    private readonly IValidator<ClienteManagerUpdateRequest> _updateRequestValidator;
    
    public ClienteManager(
        IClienteRepository clienteRepository,
        IValidator<ClienteManagerCreateRequest> createRequestValidator,
        IValidator<ClienteManagerUpdateRequest> updateRequestValidator
        )
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _createRequestValidator =
            createRequestValidator ?? throw new ArgumentNullException(nameof(createRequestValidator));
        _updateRequestValidator =
            updateRequestValidator ?? throw new ArgumentNullException(nameof(updateRequestValidator));
    }
}
