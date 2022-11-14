using CnpChallenge.Domain.DTO.Manager;
using CnpChallenge.Domain.Interfaces.Manager;
using FluentValidation;

namespace CnpChallenge.Domain.Manager;

public partial class ClienteManager : IClienteManager
{
    private readonly IValidator<ClienteManagerCreateRequest> _createRequestValidator;
    private readonly IValidator<ClienteManagerUpdateRequest> _updateRequestValidator;
    
    public ClienteManager(
        IValidator<ClienteManagerCreateRequest> createRequestValidator,
        IValidator<ClienteManagerUpdateRequest> updateRequestValidator
        )
    {
        _createRequestValidator =
            createRequestValidator ?? throw new ArgumentNullException(nameof(createRequestValidator));
        _updateRequestValidator =
            updateRequestValidator ?? throw new ArgumentNullException(nameof(updateRequestValidator));
    }
}
