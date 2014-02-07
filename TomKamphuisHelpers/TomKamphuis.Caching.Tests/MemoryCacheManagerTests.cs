using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Caching;
using TomKamphuis.Caching.Implementations;
using TomKamphuis.Caching.Interfaces;

namespace TomKamphuis.Caching.Tests
{
    [TestClass]
    public class MemoryCacheManagerTests
    {
        [TestCleanup]
        public void CleanUp()
        {
            ICacheManager cacheManager = new MemoryCacheManager();
            cacheManager.Clear();
        }

        [TestMethod]
        public void MemoryCacheManager_Should_Return_Null_When_Key_Not_Available()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            string value = cacheManager.Get<string>("Test");

            Assert.IsNull(value);
        }

        [TestMethod]
        public void MemoryCacheManager_Should_Return_Value_When_Key_Available()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Add("Test", "Dit is de waarde...", new CacheItemPolicy());

            string value = cacheManager.Get<string>("Test");

            Assert.IsNotNull(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MemoryCacheManager_Should_Return_Throw_Exception_When_Key_In_Cache()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Add("Test", "Dit is de waarde...", new CacheItemPolicy());
            cacheManager.Add("Test", "Dit is de tweede waarde...", new CacheItemPolicy());
        }

        [TestMethod]
        public void MemoryCacheManager_Should_Return_Null_When_Item_From_Cache_Was_Removed_And_Afterwards_Added()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Add("Test", "Dit is de waarde...", new CacheItemPolicy());

            cacheManager.Remove("Test");

            Assert.IsFalse(cacheManager.Contains("Test"));
        }
    }
}
