using System;
using TomKamphuis.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TomKamphuis.Tests.HelpersTests
{
    internal class MyCustomClass
    {
        public int Counter { get; set; }
        public string Name { get; set; }
    }

    [TestClass]
    public class BoolHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void In_Method_Should_Throw_Exception_When_Object_Is_Not_Primitive_Or_String()
        {
            MyCustomClass customClass = new MyCustomClass();

            customClass.In(new List<MyCustomClass>());
        }

        [TestMethod]
        public void In_Method_Should_Return_True_When_Int_Value_In_List()
        {
            int currentNumber = 5;
            List<int> allNumbers = new List<int> {
                1,
                2,
                3,
                4,
                5,
                6
            };

            Assert.IsTrue(currentNumber.In(allNumbers));
        }

        [TestMethod]
        public void In_Method_Should_Return_False_When_Int_Value_Not_In_List()
        {
            int currentNumber = 7;
            List<int> allNumbers = new List<int> {
                1,
                2,
                3,
                4,
                5,
                6
            };

            Assert.IsFalse(currentNumber.In(allNumbers));
        }

        [TestMethod]
        public void In_Method_Should_Return_True_When_String_Value_In_List()
        {
            string currentString = "good";
            List<string> allStrings = new List<string> {
                "good",
                "bad",
                "neutral"
            };

            Assert.IsTrue(currentString.In(allStrings));
        }

        [TestMethod]
        public void In_Method_Should_Return_False_When_String_Value_Not_In_List()
        {
            string currentString = "unknown";
            List<string> allStrings = new List<string> {
                "good",
                "bad",
                "neutral"
            };

            Assert.IsFalse(currentString.In(allStrings));
        }

        [TestMethod]
        public void In_Method_Should_Return_True_When_String_Value_Different_Casing_Not_In_List()
        {
            string currentString = "GOOD";
            List<string> allStrings = new List<string> {
                "good",
                "bad",
                "neutral"
            };

            Assert.IsTrue(currentString.In(allStrings));
        }

        [TestMethod]
        public void In_Method_Should_Return_True_When_Double_Value_In_List()
        {
            double currentNumber = 5.12;
            List<double> allNumbers = new List<double> {
                1.34,
                2.00,
                3.98,
                4.45,
                5.12,
                6.354
            };

            Assert.IsTrue(currentNumber.In(allNumbers));
        }

        [TestMethod]
        public void In_Method_Should_Return_False_When_Double_Value_Not_In_List()
        {
            double currentNumber = 5.11;
            List<double> allNumbers = new List<double> {
                1.34,
                2.00,
                3.98,
                4.45,
                5.12,
                6.354
            };

            Assert.IsFalse(currentNumber.In(allNumbers));
        }

        [TestMethod]
        public void In_Method_Should_Return_True_When_Float_Value_In_List()
        {
            float currentNumber = 5.12F;
            List<float> allNumbers = new List<float> {
                1.34F,
                2.00F,
                3.98F,
                4.45F,
                5.12F,
                6.354F
            };

            Assert.IsTrue(currentNumber.In(allNumbers));
        }

        [TestMethod]
        public void In_Method_Should_Return_False_When_Float_Value_Not_In_List()
        {
            float currentNumber = 5.11F;
            List<float> allNumbers = new List<float> {
                1.34F,
                2.00F,
                3.98F,
                4.45F,
                5.12F,
                6.354F
            };

            Assert.IsFalse(currentNumber.In(allNumbers));
        }

        [TestMethod]
        public void In_Method_Should_Return_True_When_Char_Value_In_List()
        {
            char currentChar = 'A';
            List<char> allChars = new List<char> {
                'A',
                'B',
                'C'
            };

            Assert.IsTrue(currentChar.In(allChars));
        }

        [TestMethod]
        public void In_Method_Should_Return_False_When_Char_Value_Not_In_List()
        {
            char currentChar = 'D';
            List<char> allChars = new List<char> {
                'A',
                'B',
                'C'
            };

            Assert.IsFalse(currentChar.In(allChars));
        }
    }
}
