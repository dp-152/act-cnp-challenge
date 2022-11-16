using System.Reflection;
using Newtonsoft.Json;

namespace CnpChallenge.IntegrationTests.Helpers;

public static class AssetsHelper
{
    public static async Task<TData> LoadJsonAsset<TData>(string assetName)
    {
        var assetPath = Path.Join(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets", $"{assetName}.json"
        );

        using var reader = new StreamReader(assetPath);
        var stringContent = await reader.ReadToEndAsync() ??
                            throw new Exception($"Cannot read contents of asset file {assetName}.json");

        var deserializedObject = JsonConvert.DeserializeObject<TData>(stringContent) ??
                                 throw new Exception($"Cannot deserialize contents of asset {assetName}.json");

        return deserializedObject;
    }
}