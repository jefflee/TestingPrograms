using System.Text;
using System.Text.Json;
using FluentAssertions.Execution;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;

namespace TestingPrograms.TwoLayersCacheWithGeneric;

internal class TwoLayersCacheTest
{
    [Test]
    public async Task GetContentAsync_Success_WhenBothCacheHasData()
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

    [Test]
    public async Task GetContentAsync_NullObject_IfBothCacheAreMissed()
    {
        // Arrange
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var distributedCache = new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));
        var sut = new TwoLayersCache(memoryCache, distributedCache);
        var key = "key";

        // Action
        var result = await sut.GetContentAsync<MyDomainObj>(key);

        // Assert
        result.Should().BeNull();
    }

    [Test]
    public async Task GetContentAsync_Success_IfMemoryCacheMissedButDistrubutedCacheHit()
    {
        // Arrange
        var memoryCache = new MemoryCache(new MemoryCacheOptions());

        var distributedCache = new Mock<IDistributedCache>();
        var targetObject = new MyDomainObj("Cindy", "Lee", 30);
        var cacheWrapper = new CacheWrapper<MyDomainObj>(targetObject, DateTime.Now.AddHours(1));
        var objectJsonstring = JsonSerializer.Serialize(cacheWrapper);
        var key = "key";
        distributedCache.Setup(
                p => p.GetAsync(key, default))
            .ReturnsAsync(Encoding.UTF8.GetBytes(objectJsonstring));
        var sut = new TwoLayersCache(memoryCache, distributedCache.Object);


        // Action
        var result = await sut.GetContentAsync<MyDomainObj>(key);

        // Assert
        using (new AssertionScope())
        {
            result.Should().BeEquivalentTo(targetObject);
            memoryCache.Count.Should().Be(1);
        }
    }
}