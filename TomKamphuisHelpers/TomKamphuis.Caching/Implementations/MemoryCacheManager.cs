using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using TomKamphuis.Caching.Interfaces;

namespace TomKamphuis.Caching.Implementations
{
    public sealed class MemoryCacheManager : ICacheManager
    {
        private static readonly ObjectCache _cache = MemoryCache.Default;

        public void Add(string key, object value, CacheItemPolicy policy)
        {
            if(_cache.Contains(key))
            {
                throw new ArgumentException("Can't add a key that's already in cache!", key);
            }

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

        public void Clear()
        {
            IList<string> cacheKeys = _cache.Select(kvp => kvp.Key).ToList();

            foreach(string cacheKey in cacheKeys)
            {
                this.Remove(cacheKey);
            }
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