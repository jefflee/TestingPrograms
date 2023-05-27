using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace TestingPrograms.TwoLayersCacheWithGeneric;

internal class TwoLayersCacheTest
{
    [Test]
    public async Task GetContentAsync_Success_WhenGiveAnObject()
    {
        // Arrange
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var distributedCache = new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));
        var sut = new TwoLayersCache(memoryCache, distributedCache);
        var targetObject = new MyDomainObj("Cindy", "Lee", 30);
        var key = "key";
        await sut.SetContentAsync(key, targetObject);

        // Action
        var result = await sut.GetContentAsync<MyDomainObj>(key);

        // Assert
        result.Should().Be(targetObject);
    }
}