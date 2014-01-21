using System;
using System.Text.RegularExpressions;
using TomKamphuis.Constants;

namespace TomKamphuis.Validations
{
    internal class StringValidation
    {
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