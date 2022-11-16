namespace CnpChallenge.API.DTO.Cliente;

public class ClienteUpdateRequestDto
{
    public string? Nome { get; set; }
    public DateTime? DtNascimento { get; set; }
    public IEnumerable<ClienteEnderecoUpdateRequestDto>? Enderecos { get; set; }
}