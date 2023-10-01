using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Utilities.IoC;

namespace Portfolio.Core.CrossCuttingConcerns.Caching.Microsoft;

public class MemoryCacheManager : ICacheManager
{
    private readonly IMemoryCache _memoryCache;
    private readonly List<string> _cacheKeys = new();

    public MemoryCacheManager()
    {
        _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
    }

    public void Add(string key, object value, int duration)
    {
        _cacheKeys.Add(key);
        _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }

    public object Get(string key)
    {
        return _memoryCache.Get(key);
    }

    public bool IsAdd(string key)
    {
        return _memoryCache.TryGetValue(key, out _); // _ => Değerin kullanılmayacağını veya kontrol edilmeyeceğini belirtmek için kullanılır
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    // Elimizdeki patterna uyan cacheleri bulup silmeye yarıyor
    public void RemoveByPattern(string pattern)
    {
        foreach (var key in _cacheKeys.ToArray())
        {
            if (key.Contains(pattern))
            {
                _cacheKeys.Remove(key); // Listeden kaldırın
                _memoryCache.Remove(key); // Önbellekten kaldırın
            }
        }

        #region Eski Yapı
        // var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
        // var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;


        // List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

        // foreach (var cacheItem in cacheEntriesCollection)
        // {
        //     ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
        //     cacheCollectionValues.Add(cacheItemValue);
        // }

        // var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        // var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

        // foreach (var key in keysToRemove)
        // {
        //     _memoryCache.Remove(key);
        // }
        #endregion
    }
}