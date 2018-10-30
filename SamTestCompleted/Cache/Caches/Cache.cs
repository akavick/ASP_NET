using Cache.Interfaces;

using Microsoft.Extensions.Caching.Memory;



namespace Cache.Caches
{



    public class Cache : ICache
    {
        private IMemoryCache _cache;



        public Cache(IMemoryCache cache)
        {
            _cache = cache;
        }



        public void Dispose()
        {
            _cache.Dispose();
        }



        public bool TryGetValue(object key, out object value)
        {
            return _cache.TryGetValue(key, out value);
        }



        public ICacheEntry CreateEntry(object key)
        {
            return _cache.CreateEntry(key);
        }



        public void Remove(object key)
        {
            _cache.Remove(key);
        }



        public object Get(object key)
        {
            return _cache.Get(key);
        }



        //public TItem Get<TItem>(object key)
        //{
        //    return _cache.Get<TItem>(key);
        //}



        //public bool TryGetValue<TItem>(object key, out TItem value)
        //{
        //    return _cache.TryGetValue<TItem>(key, out value);
        //}



        //public TItem Set<TItem>(object key, TItem value)
        //{
        //    return _cache.Set<TItem>(key, value);
        //}



        //public TItem Set<TItem>(object key, TItem value, DateTimeOffset absoluteExpiration)
        //{
        //    return _cache.Set<TItem>(key, value, absoluteExpiration);
        //}



        //public TItem Set<TItem>(object key, TItem value, TimeSpan absoluteExpirationRelativeToNow)
        //{
        //    return _cache.Set<TItem>(key, value, absoluteExpirationRelativeToNow);
        //}



        //public TItem Set<TItem>(object key, TItem value, IChangeToken expirationToken)
        //{
        //    return _cache.Set<TItem>(key, value, expirationToken);
        //}



        //public TItem Set<TItem>(object key, TItem value, MemoryCacheEntryOptions options)
        //{
        //    return _cache.Set<TItem>(key, value, options);
        //}



        //public TItem GetOrCreate<TItem>(object key, Func<ICacheEntry, TItem> factory)
        //{
        //    return _cache.GetOrCreate<TItem>(key, factory);
        //}



        //public async Task<TItem> GetOrCreateAsync<TItem>(object key, Func<ICacheEntry, Task<TItem>> factory)
        //{
        //    return await _cache.GetOrCreateAsync<TItem>(key, factory);
        //}

    }



}
