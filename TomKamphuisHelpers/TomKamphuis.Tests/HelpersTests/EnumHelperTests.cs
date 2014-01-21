using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TomKamphuis.Helpers;

namespace TomKamphuis.Tests.HelpersTests
{
    [TestClass]
    public class EnumHelperTests
    {
        private enum TestEnum
        {
            [System.ComponentModel.Description("OptionOne description")]
            OptionOne,
            OptionTwo
        }

        [TestMethod]
        public void Method_Should_Return_Description_When_Enum_Contains_Description()
        {
            object currentEnum = Enum.GetValues(typeof(TestEnum)).GetValue(0);
            string enumDescription = EnumHelper.GetEnumDescription((TestEnum)currentEnum);

            Assert.IsTrue(!string.IsNullOrEmpty(enumDescription));
            Assert.AreEqual("OptionOne description", enumDescription);
        }

        [TestMethod]
        public void Method_Should_Return_Enum_Value_When_Enum_Contains_No_Description()
        {
            object currentEnum = Enum.GetValues(typeof(TestEnum)).GetValue(1);
            string enumDescription = EnumHelper.GetEnumDescription((TestEnum)currentEnum);

            Assert.IsTrue(!string.IsNullOrEmpty(enumDescription));
            Assert.AreEqual("OptionTwo", enumDescription);
        }
    }
}
