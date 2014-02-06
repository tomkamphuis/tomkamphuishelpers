namespace TomKamphuis.Helper.Constants
{
    /// <summary>
    /// Class for storing regular expression constants.
    /// </summary>
    public class RegexString
    {
        /// <summary>
        /// String that can be used in a regular expression to determine the validaty as an email address.
        /// </summary>
        public const string EmailValidation = @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$";
    }
}