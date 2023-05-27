namespace TestingPrograms.TwoLayersCacheWithGeneric;

internal class CacheWrapper<T>
{
    public CacheWrapper(T cacheObject, DateTime absoluteExpirationTime)
    {
        CacheObject = cacheObject;
        AbsoluteExpirationTime = absoluteExpirationTime;
    }

    public T CacheObject { get; set; }

    public DateTime AbsoluteExpirationTime { get; set; }
}