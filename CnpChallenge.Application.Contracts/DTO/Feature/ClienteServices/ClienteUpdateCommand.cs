namespace CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

public class ClienteUpdateCommand
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public IEnumerable<ClienteUpdateCommandEndereco>? Addresses { get; set; }
}

public class ClienteUpdateCommandEndereco
{
    public int? Id { get; set; }
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
}
