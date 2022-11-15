using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.Domain.DTO.Manager;

public class ClienteManagerUpdateRequest
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public DateTime? DtNascimento { get; set; }
    public IEnumerable<ClienteManagerUpdateRequestEndereco>? Enderecos { get; set; }
}

public class ClienteManagerUpdateRequestEndereco
{
    public int? Id { get; set; }
    public string? Logradouro { get; set; }
    public string? Cep { get; set; }
    public string? Uf { get; set; }
    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
}