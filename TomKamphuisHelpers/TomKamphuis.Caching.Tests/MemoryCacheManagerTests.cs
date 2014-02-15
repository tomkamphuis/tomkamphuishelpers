using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        public void MemoryCacheManager_Should_Return_Value_And_Be_Able_To_Change_Existing_Value()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Add("Test", "Dit is de waarde...", new CacheItemPolicy());
            cacheManager.AddOrOverwrite("Test", "Dit is de echte waarde...", new CacheItemPolicy());

            string value = cacheManager.Get<string>("Test");

            Assert.AreSame("Dit is de echte waarde...", value);
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
        public void MemoryCacheManager_Should_Return_Null_When_Item_From_Cache_Was_Removed_And_Afterwards_Requested()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Add("Test", "Dit is de waarde...", new CacheItemPolicy());

            cacheManager.Remove("Test");

            Assert.IsFalse(cacheManager.Contains("Test"));
        }

        [TestMethod]
        public void MemoryCacheManager_Should_Not_Throw_Exception_When_Trying_To_Remove_A_Non_Excisting_Key()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Remove("Test");

            Assert.IsFalse(cacheManager.Contains("Test"));
        }

        [TestMethod]
        public void MemoryCacheManager_Should_Contain_Only_Values_That_Where_Not_To_Be_Deleted()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Add("Test", "Dit is de waarde...", new CacheItemPolicy());
            cacheManager.Add("Test2", "Dit is de tweede waarde...", new CacheItemPolicy());
            cacheManager.Add("Test3", "Dit is de derde waarde...", new CacheItemPolicy());

            IList<string> collection = new List<string> {
                "Test",
                "Test3"
            };

            cacheManager.Remove(collection);

            Assert.AreEqual(1, cacheManager.Count());
        }

        [TestMethod]
        public void MemoryCacheManager_Should_Return_Count_When_Asked_So()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Add("Test", "Dit is de waarde...", new CacheItemPolicy());
            cacheManager.Add("Test2", "Dit is de tweede waarde...", new CacheItemPolicy());
            cacheManager.Add("Test3", "Dit is de derde waarde...", new CacheItemPolicy());

            Assert.AreEqual(3, cacheManager.Count());
        }

        [TestMethod]
        public void MemoryCacheManager_Should_Contain_No_Values_When_Cleared()
        {
            ICacheManager cacheManager = new MemoryCacheManager();

            cacheManager.Add("Test", "Dit is de waarde...", new CacheItemPolicy());
            cacheManager.Add("Test2", "Dit is de tweede waarde...", new CacheItemPolicy());
            cacheManager.Add("Test3", "Dit is de derde waarde...", new CacheItemPolicy());

            cacheManager.Clear();

            Assert.AreEqual(0, cacheManager.Count());
        }
    }
}
