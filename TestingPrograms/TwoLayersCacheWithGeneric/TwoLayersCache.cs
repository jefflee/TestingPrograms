using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace TestingPrograms.TwoLayersCacheWithGeneric;

internal class TwoLayersCache
{
    private readonly IDistributedCache _distributedCache;
    private readonly IMemoryCache _memoryCache;

    public TwoLayersCache(IMemoryCache memoryCache, IDistributedCache distributedCache)
    {
        _memoryCache = memoryCache;
        _distributedCache = distributedCache;
    }

    public async Task SetContentAsync<T>(string key, T content)
    {
        var absoluteExpirationTime = DateTime.Now.AddHours(1);
        var cacheWrapper = new CacheWrapper<T>(content, absoluteExpirationTime);

        var memoryCacheEntryOptions = new MemoryCacheEntryOptions();
        memoryCacheEntryOptions.SetAbsoluteExpiration(absoluteExpirationTime);
        _memoryCache.Set(key, cacheWrapper, memoryCacheEntryOptions);

        var distributedCacheEntryOptions = new DistributedCacheEntryOptions();
        distributedCacheEntryOptions.SetAbsoluteExpiration(absoluteExpirationTime);
        await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(cacheWrapper),
            distributedCacheEntryOptions);
    }

    public async Task<T?> GetContentAsync<T>(string key)
    {
        var isMemoryCacheExist = _memoryCache.TryGetValue(key, out CacheWrapper<T>? content);
        if (!isMemoryCacheExist)
        {
            var distributedCacheData = await _distributedCache.GetStringAsync(key).ConfigureAwait(false);
            if (distributedCacheData != null)
            {
                content = JsonSerializer.Deserialize<CacheWrapper<T>>(distributedCacheData);
                if (content != null)
                {
                    var memoryCacheEntryOptions = new MemoryCacheEntryOptions();
                    memoryCacheEntryOptions.SetAbsoluteExpiration(content.AbsoluteExpirationTime);
                    _memoryCache.Set(key, content, memoryCacheEntryOptions);
                }
            }
        }

        return content!.CacheObject == null ? default : content!.CacheObject;
    }
}