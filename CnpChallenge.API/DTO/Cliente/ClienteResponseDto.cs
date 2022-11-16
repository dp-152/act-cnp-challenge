using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.API.DTO.Cliente;

public class ClienteResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DtNascimento { get; set; }
    public EStatusCadastro Status { get; set; }
    public IEnumerable<ClienteEnderecoResponseDto> Enderecos { get; set; }
}