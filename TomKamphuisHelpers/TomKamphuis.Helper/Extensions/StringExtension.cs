using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TomKamphuis.Helper.Helpers;
using TomKamphuis.Helper.Validations;

namespace TomKamphuis.Helper.Extensions
{
    /// <summary>
    /// Methods for extending the standard string functionality.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Validates a given string against a regular expression to determine if it's a valid e-mail.
        /// </summary>
        public static bool IsEmail(this string email)
        {
            return StringValidation.IsEmail(email);
        }

        /// <summary>
        /// The first character of your string will be upper-cased.
        /// </summary>
        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            return input.First().ToString().ToUpper() + string.Join(string.Empty, input.Skip(1));
        }

        /// <summary>
        /// The first characters of your city name will be upper-cased according to Dutch preferences.
        /// </summary>
        public static string ToDutchCityName(this string city)
        {
            city = city.ToLower();

            if (city.Contains(" "))
            {
                // BV Den Bosch

                string[] cityParts = city.Split(' ');
                city = string.Empty;

                foreach (string part in cityParts)
                {
                    city += part.FirstCharToUpper() + " ";
                }

                city = city.Trim();
            }

            if (city.StartsWith("'"))
            {
                // BV 's Gravenhage

                string cityPartOne = city.Substring(0, 3);
                string cityPartTwo = city.Substring(3, city.Length - 3);

                city = cityPartOne + cityPartTwo.FirstCharToUpper();
            }

            return city.FirstCharToUpper();
        }

        /// <summary>
        /// The string you supply will be entirely ready for URL usage with no special characters or spaces left in the string.
        /// </summary>
        public static string ToUrlSafeString(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            input = input.Replace(" ", "_");
            input = input.Replace("&", "");
            input = input.Replace("'", "");
            input = input.Replace(";", "");
            input = input.Replace(":", "");
            input = input.Replace(",", "");
            input = input.Replace(".", "");
            input = input.Replace("^", "");

            return StringHelper.RemoveSpecialCharactersFromString(input);
        }

        /// <summary>
        /// Removes all HTML-tags from a given string.
        /// </summary>
        public static string RemoveHTML(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            string output = Regex.Replace(input, "<[^>]*>", string.Empty);
            output = WebUtility.HtmlDecode(output);

            if(!string.IsNullOrEmpty(output))
            {
                output = StringHelper.RemoveSpecialCharactersFromString(output);
            }

            return output;
        }
    }
}