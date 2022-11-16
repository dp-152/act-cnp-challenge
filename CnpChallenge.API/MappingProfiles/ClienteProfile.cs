using AutoMapper;
using CnpChallenge.API.DTO.Cliente;
using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;

namespace CnpChallenge.API.MappingProfiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ClienteResponse, ClienteResponseDto>();
        CreateMap<ClienteEnderecoResponse, ClienteEnderecoResponseDto>();
        CreateMap<ClienteRequestDto, ClienteCreateCommand>();
        CreateMap<ClienteEnderecoRequestDto, ClienteCreateCommandEndereco>();
        CreateMap<ClienteUpdateRequestDto, ClienteUpdateCommand>();
        CreateMap<ClienteEnderecoUpdateRequestDto, ClienteUpdateCommandEndereco>();
    }
}
