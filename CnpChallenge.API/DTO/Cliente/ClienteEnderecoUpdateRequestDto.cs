using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.API.DTO.Cliente;

public class ClienteEnderecoUpdateRequestDto
{
    public int? Id { get; set; }
    public string? Logradouro { get; set; }
    public string? Cep { get; set; }
    public string? Uf { get; set; }
    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public EStatusCadastro? Status { get; set; }
}