using System.Text.RegularExpressions;

namespace CnpChallenge.API.ServiceRegistration.Utility;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        return value?.ToString() is null ? null :
            Regex.Replace(value.ToString()!, "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}
