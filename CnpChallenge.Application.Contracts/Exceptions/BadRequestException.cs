namespace CnpChallenge.Application.Contracts.Exceptions;

public class BadRequestException : ApplicationException
{
    public IEnumerable<string>? ErrorMessages { get; }

    public BadRequestException(IEnumerable<string>? errorMessages, Exception? innerException = null) : base(
        "One or more fields has failed validation", innerException)
    {
        ErrorMessages = errorMessages;
    }

    public BadRequestException(IEnumerable<string>? errorMessages, string? message = null,
        Exception? innerException = null) : base(message, innerException)
    {
        ErrorMessages = errorMessages;
    }
}
