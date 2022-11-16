using CnpChallenge.Domain.DTO.Manager;
using FluentValidation;

namespace CnpChallenge.Domain.Validator.ClienteValidator;

public class ClienteEnderecoUpdateValidator : AbstractValidator<ClienteManagerUpdateRequestEndereco>
{
    public ClienteEnderecoUpdateValidator()
    {
        When(e => e.Id is null, () =>
        {
            RuleFor(e => e.Logradouro).NotEmpty();
            RuleFor(e => e.Bairro).NotEmpty();
            RuleFor(e => e.Cidade).NotEmpty();
            RuleFor(e => e.Uf).NotEmpty();
            RuleFor(e => e.Cep).NotEmpty();
        });

        RuleFor(e => e.Logradouro).MaximumLength(100);
        RuleFor(e => e.Bairro).MaximumLength(60);
        RuleFor(e => e.Cidade).MaximumLength(100);
        RuleFor(e => e.Uf).Length(2);
        RuleFor(e => e.Cep).Length(8);
    }
}
