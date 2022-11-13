using CnpChallenge.Domain.Enum;

namespace CnpChallenge.Domain.Model.ClienteModel;

public class ClienteEndereco : _ModelBase
{
    public int IdCliente { get; set; }
    public string Logradouro { get; set; }
    public string Cep { get; set; }
    public string Uf { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public EStatusCadastro Status { get; set; }
    
    public virtual Cliente Cliente { get; set; }
}