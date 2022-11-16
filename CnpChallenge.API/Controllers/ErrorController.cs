using CnpChallenge.Application.Contracts.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CnpChallenge.API.Controllers;

[ApiController]
public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult HandleError([FromServices] IHostEnvironment hostEnvironment)
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        try
        {
            throw exceptionHandlerFeature?.Error ?? new Exception("unknown");
        }
        catch (BadRequestException ex)
        {
            var type = typeof(BadRequestException);
            var message = ex.Message;
            var errorMessages = ex.ErrorMessages.Aggregate((prev, msg) => prev + "\n" + msg);
            _logger.LogError("{Type} -> {Message}: \n{ErrorMessages}", type, message, errorMessages);

            return BadRequest(ex.Message);
        }
        catch (ResourceNotFoundException ex)
        {
            var type = typeof(ResourceNotFoundException);
            var message = ex.Message;
            var resource = ex.Resource;
            _logger.LogError("{Type} -> {Message}: Resource {Resource}", type, message, resource);

            return NotFound(ex.Message);
        }
        catch (InternalException ex)
        {
            var type = typeof(InternalException);
            var message = ex.Message;
            var isClientSafe = ex.IsClientSafe.ToString();
            _logger.LogError("{Type} -> {Message}: IsClientSafe = {IsClientSafe}", type, message, isClientSafe);
            
            return StatusCode(StatusCodes.Status500InternalServerError, ex.IsClientSafe ? ex.Message : null);
        }
        catch (Exception ex)
        {
            var type = typeof(InternalException);
            var message = ex.Message;
            _logger.LogError("{Type} -> {Message}", type, message);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}