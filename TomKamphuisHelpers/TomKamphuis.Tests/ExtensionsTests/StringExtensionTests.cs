using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TomKamphuis.Extensions;

namespace TomKamphuis.ExtensionsTests.Tests
{
    [TestClass]
    public class StringExtensionTests
    {
        private static string ValidEmailOne = "t.van.der.veer@tomkamphuis.nl";
        private static string ValidEmailTwo = "t.van.der.veer@tomkamphuis.nl";
        private static string ValidEmailThree = "john@doe.com";
        private static string InvalidEmailOneLetterTopDomain = "tom@tomkamphuis.n";
        private static string InvalidEmailContainingSpaces = "tom kamphuis@tomkamphuis.nl";
        private static string InvalidEmailNoTopDomain = "tom@tomkamphuis";
        private static string InvalidEmailNoAtSymbol = "tom.kamphuis.nl";

        [TestMethod]
        public void Method_Should_Return_True_When_Email_Is_Correct_Containing_Dots()
        {
            Assert.IsTrue(ValidEmailOne.IsEmail());
        }

        [TestMethod]
        public void Method_Should_Return_True_When_Email_Is_Correct_Two_Characters_Top_Domain()
        {
            Assert.IsTrue(ValidEmailTwo.IsEmail());
        }

        [TestMethod]
        public void Method_Should_Return_True_When_Email_Is_Correct_Three_Characters_Top_Domain()
        {
            Assert.IsTrue(ValidEmailThree.IsEmail());
        }

        [TestMethod]
        public void Method_Should_Return_False_When_Email_Is_With_Email_Space()
        {
            Assert.IsFalse(InvalidEmailContainingSpaces.IsEmail());
        }

        [TestMethod]
        public void Method_Should_Return_False_When_Email_Is_Without_Top_Domain()
        {
            Assert.IsFalse(InvalidEmailNoTopDomain.IsEmail());
        }

        [TestMethod]
        public void Method_Should_Return_False_When_Email_Is_With_One_Letter_Top_Domain()
        {
            Assert.IsFalse(InvalidEmailOneLetterTopDomain.IsEmail());
        }

        [TestMethod]
        public void Method_Should_Return_False_When_Email_Is_Without_At()
        {
            Assert.IsFalse(InvalidEmailNoAtSymbol.IsEmail());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Method_Should_Throw_Exception_When_Email_Is_Empty()
        {
            bool isEmail = string.Empty.IsEmail();
        }

        [TestMethod]
        public void Method_Should_Return_Uppercased_String()
        {
            string text = "this is a test";

            Assert.AreEqual("This is a test", text.FirstCharToUpper());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Method_Should_Throw_Exception_When_String_Is_Empty()
        {
            string text = string.Empty.FirstCharToUpper();
        }
    }
}