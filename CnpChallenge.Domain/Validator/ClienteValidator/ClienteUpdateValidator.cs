using CnpChallenge.Domain.DTO.Manager;
using FluentValidation;

namespace CnpChallenge.Domain.Validator.ClienteValidator;

public class ClienteUpdateValidator : AbstractValidator<ClienteManagerUpdateRequest>
{
    public ClienteUpdateValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().MaximumLength(200);
        RuleFor(c => c.DtNascimento).NotEmpty();
        RuleFor(c => c.Enderecos).NotEmpty();
        RuleForEach(c => c.Enderecos).SetValidator(new ClienteEnderecoUpdateValidator());
    }
}
