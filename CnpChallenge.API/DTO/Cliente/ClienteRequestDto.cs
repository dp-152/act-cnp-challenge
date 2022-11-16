namespace CnpChallenge.API.DTO.Cliente;

public class ClienteRequestDto
{
    public string Nome { get; set; }
    public DateTime DtNascimento { get; set; }
    public IEnumerable<ClienteEnderecoRequestDto> Enderecos { get; set; }
}
