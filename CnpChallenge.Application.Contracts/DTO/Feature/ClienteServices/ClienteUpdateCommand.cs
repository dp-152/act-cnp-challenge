namespace CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

public class ClienteUpdateCommand
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public DateTime? DtNascimento { get; set; }
    public IEnumerable<ClienteUpdateCommandEndereco>? Enderecos { get; set; }
}

public class ClienteUpdateCommandEndereco
{
    public int? Id { get; set; }
    public string? Logradouro { get; set; }
    public string? Cep { get; set; }
    public string? Uf { get; set; }
    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
}
