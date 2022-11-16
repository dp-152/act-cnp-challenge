using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Application.Contracts.Exceptions;
using CnpChallenge.Domain.DTO.Manager;
using FluentValidation;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> CreateCliente(ClienteCreateCommand command)
    {
        try
        {
            var request = _mapper.Map<ClienteManagerCreateRequest>(command);

            var createdObject = _clienteManager.Create(request);
            var result = await _clienteRepository.Create(createdObject);

            return _mapper.Map<ClienteResponse>(result);
        }
        catch (ValidationException valEx)
        {
            throw new BadRequestException(
                valEx.Errors.Select(el => el.ErrorMessage.ToString()),
                valEx.Message, valEx);
        }
        catch (Exception ex)
        {
            throw new InternalException(false, innerException: ex);
        }
    }
}