namespace CnpChallenge.Application.Contracts.Exceptions;

public class BadRequestException : ApplicationException
{
    public IEnumerable<Dictionary<string, string>>? InvalidFields { get; }

    public BadRequestException(IEnumerable<Dictionary<string, string>>? invalidFields, Exception? innerException = null) : base(
        "One or more fields has failed validation", innerException)
    {
        InvalidFields = invalidFields;
    }

    public BadRequestException(IEnumerable<Dictionary<string, string>>? invalidFields, string? message = null,
        Exception? innerException = null) : base(message, innerException)
    {
        InvalidFields = invalidFields;
    }
}
