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

        public void AddOrOverwrite(string key, object value, CacheItemPolicy policy)
        {
            if(!_cache.Contains(key))
            {
                this.Add(key, value, policy);
                return;
            }

            _cache[key] = value;
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
            var currentObject = _cache.Get(key);

            if(currentObject == null)
            {
                return default(T);
            }

            return (T)currentObject;
        }

        public void Remove(string key)
        {
            if(!this.Contains(key))
            {
                throw new KeyNotFoundException();
            }

            _cache.Remove(key);
        }

        public void Remove(IList<string> keys)
        {
            foreach (string key in keys)
            {
                this.Remove(key);
            }
        }

        public void Clear()
        {
            this.Remove(_cache.Select(kvp => kvp.Key).ToList());
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