using System.Runtime.Caching;

namespace TomKamphuis.Caching.Interfaces
{
    public interface ICacheManager
    {
        /// <summary>
        /// Add a new object into the cache
        /// </summary>
        void Add(string key, object value, CacheItemPolicy policy);

        /// <summary>
        /// Check whether the key is contained by the cache
        /// </summary>
        bool Contains(string key);

        /// <summary>
        /// Returns the number of items in the cache
        /// </summary>
        int Count();

        /// <summary>
        /// Get the object that its key is given
        /// </summary>
        T Get<T>(string key);

        /// <summary>
        /// Removes the object that is referenced by the given key
        /// </summary>
        void Remove(string key);

        /// <summary>
        /// Clears the whole cache
        /// </summary>
        void Clear();

        /// <summary>
        /// Get/Set the the given key and object
        /// </summary>
        object this[string key]
        {
            get;
            set;
        }
    }
}