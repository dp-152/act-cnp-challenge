using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

public class ClienteResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DtNascimento { get; set; }
    public IEnumerable<ClienteEnderecoResponse> Enderecos { get; set; }
    public EStatusCadastro Status { get; set; }
}

public class ClienteEnderecoResponse
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Cep { get; set; }
    public string Uf { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public EStatusCadastro Status { get; set; }
    
}
