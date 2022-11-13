using CnpChallenge.Domain.Enum;

namespace CnpChallenge.Domain.Model.ClienteModel;

public class Cliente : _ModelBase
{
    public string Nome { get; set; }
    public DateTime DtNascimento { get; set; }
    public EStatusCadastro Status { get; set; }
    
    public virtual IEnumerable<ClienteEndereco> Enderecos { get; set; }
}
