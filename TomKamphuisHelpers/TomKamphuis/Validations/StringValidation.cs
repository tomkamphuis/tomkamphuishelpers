using System;
using System.Text.RegularExpressions;
using TomKamphuis.Constants;

namespace TomKamphuis.Validations
{
    /// <summary>
    /// Class with all sorts of string validation methods.
    /// </summary>
    internal class StringValidation
    {
        /// <summary>
        /// Validates a given string against a regular expression to determine if it's a valid e-mail.
        /// </summary>
        internal static bool IsEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            Regex regex = new Regex(RegexString.EmailValidation, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }
    }
}