using CnpChallenge.Domain.DTO.Manager;
using FluentValidation;

namespace CnpChallenge.Domain.Validator.ClienteValidator;

public class ClienteUpdateValidator : AbstractValidator<ClienteManagerUpdateRequest>
{
    public ClienteUpdateValidator()
    {
        RuleFor(c => c.Nome).MaximumLength(200);
        RuleForEach(c => c.Enderecos).SetValidator(new ClienteEnderecoUpdateValidator());
    }
}
