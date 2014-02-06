using System.Linq;
using System.Runtime.Caching;
using TomKamphuis.Caching.Interfaces;

namespace TomKamphuis.Caching.Implementations
{
    public class MemoryCacheManager : ICacheManager
    {
        private static ObjectCache _cache = MemoryCache.Default;

        public void Add(string key, object value, CacheItemPolicy policy)
        {
            _cache.Add(key, value, policy);
        }

        public bool Contains(string key)
        {
            return _cache.Get(key) != null;
        }

        public int Count()
        {
            return _cache.Count();
        }

        public T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public object this[string key]
        {
            get
            {
                return _cache[key];
            }
            set
            {
                _cache[key] = value;
            }
        }
    }
}
