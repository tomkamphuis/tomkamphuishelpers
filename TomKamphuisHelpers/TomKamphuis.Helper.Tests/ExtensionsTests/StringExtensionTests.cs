﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TomKamphuis.Helper.Extensions;

namespace TomKamphuis.Helper.ExtensionsTests.Tests
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
        public void IsEmail_Should_Return_True_When_Email_Is_Correct_Containing_Dots()
        {
            Assert.IsTrue(ValidEmailOne.IsEmail());
        }

        [TestMethod]
        public void IsEmail_Should_Return_True_When_Email_Is_Correct_Two_Characters_Top_Domain()
        {
            Assert.IsTrue(ValidEmailTwo.IsEmail());
        }

        [TestMethod]
        public void IsEmail_Should_Return_True_When_Email_Is_Correct_Three_Characters_Top_Domain()
        {
            Assert.IsTrue(ValidEmailThree.IsEmail());
        }

        [TestMethod]
        public void IsEmail_Should_Return_False_When_Email_Is_With_Email_Space()
        {
            Assert.IsFalse(InvalidEmailContainingSpaces.IsEmail());
        }

        [TestMethod]
        public void IsEmail_Should_Return_False_When_Email_Is_Without_Top_Domain()
        {
            Assert.IsFalse(InvalidEmailNoTopDomain.IsEmail());
        }

        [TestMethod]
        public void IsEmail_Should_Return_False_When_Email_Is_With_One_Letter_Top_Domain()
        {
            Assert.IsFalse(InvalidEmailOneLetterTopDomain.IsEmail());
        }

        [TestMethod]
        public void IsEmail_Should_Return_False_When_Email_Is_Without_At()
        {
            Assert.IsFalse(InvalidEmailNoAtSymbol.IsEmail());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsEmail_Should_Throw_Exception_When_Email_Is_Empty()
        {
            bool isEmail = string.Empty.IsEmail();
        }

        [TestMethod]
        public void FirstCharToUpper_Should_Return_Uppercased_String()
        {
            string text = "this is a test";

            Assert.AreEqual("This is a test", text.FirstCharToUpper());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstCharToUpper_Should_Throw_Exception_When_String_Is_Empty()
        {
            string text = string.Empty.FirstCharToUpper();
        }

        [TestMethod]
        public void ToUrlSafeString_Should_Return_URL_Safe_String()
        {
            string text = "Bogotá City Center";

            Assert.AreEqual("Bogota_City_Center", text.ToUrlSafeString());
        }

        [TestMethod]
        public void ToUrlSafeString_Should_Remove_All_Characters()
        {
            string text = "áúéóí àùèòì ãõñ äüëöï âûêôî a.u,e;o'i a&u:e^oi";

            Assert.AreEqual("aueoi_aueoi_aon_aueoi_aueoi_aueoi_aueoi", text.ToUrlSafeString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToUrlSafeString_Should_Throw_Exception_When_String_Is_Empty()
        {
            string text = string.Empty.ToUrlSafeString();
        }

        [TestMethod]
        public void RemoveHTML_Should_Remove_All_HTML_Characters()
        {
            string text = "<p>Lorem <b>ipsum dol&egrave;r <i>sit</i></b> amet!</p>";

            Assert.AreEqual("Lorem ipsum doler sit amet!", text.RemoveHTML());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveHTML_Should_Throw_Exception_When_String_Is_Empty()
        {
            string text = string.Empty.RemoveHTML();
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstChar_Uppercased_String()
        {
            string text = "ASSEN";

            Assert.AreEqual("Assen", text.ToDutchCityName());
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstChar_Uppercased_String_For_Every_Part()
        {
            string text = "DEN BOSCH";

            Assert.AreEqual("Den Bosch", text.ToDutchCityName());
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstChar_Uppercased_String_For_Funny_Name()
        {
            string text = "'S GRAVENHAGE";

            Assert.AreEqual("'s Gravenhage", text.ToDutchCityName());
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstChar_Uppercased_String_For_Funny_Names()
        {
            string text = "'S DEN BOSCH";

            Assert.AreEqual("'s Den Bosch", text.ToDutchCityName());
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstChar_Uppercased_String_For_Saint_Names()
        {
            string text = "ST. ANNAGESTEL";

            Assert.AreEqual("St. Annagestel", text.ToDutchCityName());
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstChar_Uppercased_String_For_Names_With_A_Line()
        {
            string text = "BERKEL-ENSCHOT";

            Assert.AreEqual("Berkel-Enschot", text.ToDutchCityName());
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstTwoChar_Uppercased_String_When_IJ_In_Name()
        {
            string text = "IJSSELSTEIN";

            Assert.AreEqual("IJsselstein", text.ToDutchCityName());
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstChar_Uppercased_With_Province_Abbreviations_Uppercased()
        {
            string text = "OOSTERHOUT NB";
            Assert.AreEqual("Oosterhout NB", text.ToDutchCityName());

            text = "OOSTERHOUT NH";
            Assert.AreEqual("Oosterhout NH", text.ToDutchCityName());

            text = "OOSTERHOUT ZH";
            Assert.AreEqual("Oosterhout ZH", text.ToDutchCityName());

            text = "NIJKERK GLD";
            Assert.AreEqual("Nijkerk Gld", text.ToDutchCityName());
        }

        [TestMethod]
        public void ToDutchCityName_Should_Return_FirstChar_Uppercased_With_Couple_Words_Lowercased()
        {
            string text = "CAPELLE AAN DEN IJSSEL";
            Assert.AreEqual("Capelle aan den IJssel", text.ToDutchCityName());

            text = "BERKEL EN RODENRIJS";
            Assert.AreEqual("Berkel en Rodenrijs", text.ToDutchCityName());

            text = "BERGEN OP ZOOM";
            Assert.AreEqual("Bergen op Zoom", text.ToDutchCityName());

            text = "HORST AAN DE MAAS";
            Assert.AreEqual("Horst aan de Maas", text.ToDutchCityName());

            text = "WIJK BIJ DUURSTEDE";
            Assert.AreEqual("Wijk bij Duurstede", text.ToDutchCityName());

            text = "DE RONDE VENEN";
            Assert.AreEqual("De Ronde Venen", text.ToDutchCityName());
        }
    }
}