using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TomKamphuis.Validations;

namespace TomKamphuis.Extensions
{
    public static class StringExtension
    {
        public static bool IsEmail(this string email)
        {
            return StringValidation.IsEmail(email);
        }

        public static string FirstCharToUpper(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            return text.First().ToString().ToUpper() + string.Join(string.Empty, text.Skip(1));
        }

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