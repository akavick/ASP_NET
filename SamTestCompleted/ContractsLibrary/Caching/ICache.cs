using Microsoft.Extensions.Caching.Memory;

namespace ContractsLibrary.Caching
{



    public interface ICache
    {
       void Dispose();

       bool TryGetValue(object key, out object value);

       ICacheEntry CreateEntry(object key);

       void Remove(object key);

       object Get(object key);

       //TItem Get<TItem>(object key);

       //bool TryGetValue<TItem>(object key, out TItem value);

       //TItem Set<TItem>(object key, TItem value);

       //TItem Set<TItem>(object key, TItem value, DateTimeOffset absoluteExpiration);

       //TItem Set<TItem>(object key, TItem value, TimeSpan absoluteExpirationRelativeToNow);

       //TItem Set<TItem>(object key, TItem value, IChangeToken expirationToken);

       //TItem Set<TItem>(object key, TItem value, MemoryCacheEntryOptions options);

       //TItem GetOrCreate<TItem>(object key, Func<ICacheEntry, TItem> factory);

       //Task<TItem> GetOrCreateAsync<TItem>(object key, Func<ICacheEntry, Task<TItem>> factory);
    }



}