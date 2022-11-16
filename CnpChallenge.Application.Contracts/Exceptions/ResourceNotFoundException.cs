namespace CnpChallenge.Application.Contracts.Exceptions;

public class ResourceNotFoundException : ApplicationException
{
    public string? Resource { get; }
    public string? SearchParam { get; }

    public ResourceNotFoundException(string? resource, string? searchParam, Exception? innerException = null) : base(
        $"Resource at {resource} was not found with params {searchParam}.", innerException)
    {
        Resource = resource;
        SearchParam = searchParam;
    }

    public ResourceNotFoundException(string? resource, Exception? innerException = null) : base(
        $"Resource at {resource} was not found", innerException)
    {
        Resource = resource;
    }
}
