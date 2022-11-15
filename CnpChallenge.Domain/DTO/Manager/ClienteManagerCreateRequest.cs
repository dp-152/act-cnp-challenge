using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.Domain.DTO.Manager;

public class ClienteManagerCreateRequest
{
    public string Nome { get; set; }
    public DateTime DtNascimento { get; set; }
    public IEnumerable<ClienteManagerCreateRequestEndereco> Enderecos { get; set; }
}

public class ClienteManagerCreateRequestEndereco
{
    public string Logradouro { get; set; }
    public string Cep { get; set; }
    public string Uf { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
}
