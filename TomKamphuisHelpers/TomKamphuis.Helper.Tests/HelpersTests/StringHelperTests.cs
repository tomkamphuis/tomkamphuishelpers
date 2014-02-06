using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TomKamphuis.Helper.Helpers;

namespace TomKamphuis.Helper.Tests.HelpersTests
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void RemoveSpecialCharactersFromString_Should_Remove_All_Characters()
        {
            string text = "áúéóí àùèòì ãõñ äüëöï âûêôî a.u,e;o'i a&u:e^oi";

            Assert.AreEqual("aueoi aueoi aon aueoi aueoi a.u,e;o'i a&u:e^oi", StringHelper.RemoveSpecialCharactersFromString(text));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToUrlSafeString_Should_Throw_Exception_When_String_Is_Empty()
        {
            string text = StringHelper.RemoveSpecialCharactersFromString(string.Empty);
        }
    }
}