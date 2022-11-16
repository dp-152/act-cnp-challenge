using AutoMapper;
using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Domain.DTO.Manager;
using CnpChallenge.Domain.Model.ClienteModel;

namespace CnpChallenge.Application.MappingProfiles;

public class ClienteServiceProfile : Profile
{
    public ClienteServiceProfile()
    {
        CreateMap<ClienteCreateCommand, ClienteManagerCreateRequest>();
        CreateMap<ClienteCreateCommandEndereco, ClienteManagerCreateRequestEndereco>();
        CreateMap<ClienteUpdateCommand, ClienteManagerUpdateRequest>();
        CreateMap<ClienteUpdateCommandEndereco, ClienteManagerUpdateRequestEndereco>();
        CreateMap<Cliente, ClienteResponse>();
        CreateMap<ClienteEndereco, ClienteEnderecoResponse>();
    }
}
