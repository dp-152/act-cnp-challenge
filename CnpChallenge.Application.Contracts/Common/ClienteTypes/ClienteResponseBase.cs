﻿using CnpChallenge.Domain.Shared.Enum;

namespace CnpChallenge.Application.Contracts.Common.ClienteTypes;

public class ClienteResponseBase : ClienteBase
{
    public int Id { get; set; }
    public IEnumerable<ClienteEnderecoResponseBase> Addresses { get; set; }
    public EStatusCadastro Status { get; set; }
}