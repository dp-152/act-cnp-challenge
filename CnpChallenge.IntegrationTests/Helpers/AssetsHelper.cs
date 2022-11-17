using System.Reflection;
using Newtonsoft.Json;

namespace CnpChallenge.IntegrationTests.Helpers;

public static class AssetsHelper
{
    private static string ResolveAssetPath (string assetName) => Path.Join(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
        "Assets", $"{assetName}.json"
    );
    public static async Task<TData> LoadJsonAsset<TData>(string assetName)
    {
        var stringContent = await LoadJsonAssetAsString(assetName);
        var deserializedObject = JsonConvert.DeserializeObject<TData>(stringContent) ??
                                 throw new Exception($"Cannot deserialize contents of asset {assetName}.json");

        return deserializedObject;
    }

    public static async Task<string> LoadJsonAssetAsString(string assetName)
    {
        using var reader = new StreamReader(ResolveAssetPath(assetName));
        return await reader.ReadToEndAsync() ??
                            throw new Exception($"Cannot read contents of asset file {assetName}.json");
    }
}