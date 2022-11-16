namespace CnpChallenge.Application.Contracts.Exceptions;

public class InternalException : ApplicationException
{
    public bool IsClientSafe { get; }

    public InternalException(bool isClientSafe, string? message = null, Exception? innerException = null) : base(
        message, innerException)
    {
        IsClientSafe = isClientSafe;
    }
}
