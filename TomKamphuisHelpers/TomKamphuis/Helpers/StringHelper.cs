using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TomKamphuis.Helpers
{
    /// <summary>
    /// Class for enabling more string functionality.
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Removes all special characters from a string like áëòñî.
        /// </summary>
        public static string RemoveSpecialCharactersFromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            string decomposed = input.Normalize(NormalizationForm.FormD);
            char[] filtered = decomposed
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new String(filtered);
        }
    }
}
