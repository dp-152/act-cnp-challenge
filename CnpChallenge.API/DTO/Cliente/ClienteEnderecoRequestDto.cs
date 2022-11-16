namespace CnpChallenge.API.DTO.Cliente;

public class ClienteEnderecoRequestDto
{
    public string Logradouro { get; set; }
    public string Cep { get; set; }
    public string Uf { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
}
