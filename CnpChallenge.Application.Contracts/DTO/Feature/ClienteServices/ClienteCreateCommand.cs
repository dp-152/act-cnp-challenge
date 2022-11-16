namespace CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

public class ClienteCreateCommand
{
    public string Nome { get; set; }
    public DateTime DtNascimento { get; set; }
    public IEnumerable<ClienteCreateCommandEndereco> Enderecos { get; set; }
}

public class ClienteCreateCommandEndereco
{
    public string Logradouro { get; set; }
    public string Cep { get; set; }
    public string Uf { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
}