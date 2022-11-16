using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Application.Contracts.Exceptions;
using CnpChallenge.Domain.DTO.Manager;
using FluentValidation;

namespace CnpChallenge.Application.Feature.Cliente;

public partial class ClienteServices
{
    public async Task<ClienteResponse> UpdateCliente(ClienteUpdateCommand command)
    {
        try
        {
            var source = await _clienteRepository.Get(command.Id);
            if (source is null) throw new ResourceNotFoundException($"ID = {command.Id}");

            var request = _mapper.Map<ClienteManagerUpdateRequest>(command);

            _clienteManager.Update(request, source);
            var result = await _clienteRepository.Update(source);

            return _mapper.Map<ClienteResponse>(result);
        }
        catch (ValidationException valEx)
        {
            throw new BadRequestException(
                valEx.Errors.Select(el => el.ErrorMessage.ToString()),
                valEx.Message, valEx);
        }
        catch (ResourceNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalException(false, innerException: ex);
        }
    }
}