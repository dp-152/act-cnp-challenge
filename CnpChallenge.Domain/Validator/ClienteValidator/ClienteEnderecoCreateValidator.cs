using CnpChallenge.Domain.DTO.Manager;
using FluentValidation;

namespace CnpChallenge.Domain.Validator.ClienteValidator;

public class ClienteEnderecoCreateValidator : AbstractValidator<ClienteManagerCreateRequestEndereco>
{
    public ClienteEnderecoCreateValidator()
    {
        RuleFor(e => e.Logradouro).NotEmpty().MaximumLength(100);
        RuleFor(e => e.Bairro).NotEmpty().MaximumLength(60);
        RuleFor(e => e.Cidade).NotEmpty().MaximumLength(100);
        RuleFor(e => e.Uf).NotEmpty().Length(2);
        RuleFor(e => e.Cep).NotEmpty().Length(8);
    }
}
