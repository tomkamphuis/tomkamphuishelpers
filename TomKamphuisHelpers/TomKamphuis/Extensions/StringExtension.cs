using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TomKamphuis.Validations;

namespace TomKamphuis.Extensions
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
        /// The string you supply will be entirely ready for URL usage with no special characters or spaces left in the string.
        /// </summary>
        public static string ToUrlSafeString(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            input = input.Replace(" ", "_");

            string decomposed = input.Normalize(NormalizationForm.FormD);
            char[] filtered = decomposed
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new String(filtered);
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

            return Regex.Replace(input, "<[^>]*>", string.Empty);
        }
    }
}