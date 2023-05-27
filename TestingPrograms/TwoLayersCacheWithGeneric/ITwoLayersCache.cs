namespace TestingPrograms.TwoLayersCacheWithGeneric;

internal interface ITwoLayersCache
{
    Task<T?> GetContentAsync<T>(string key);

    Task SetContentAsync<T>(string key, T content);
}