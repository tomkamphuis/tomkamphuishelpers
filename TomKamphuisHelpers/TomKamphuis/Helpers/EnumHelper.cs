using System;
using System.ComponentModel;
using System.Reflection;

namespace TomKamphuis.Helpers
{
    /// <summary>
    /// Class for enabling more enumeration functionality.
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// Returns the data anotated description from an enumeration value.
        /// </summary>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }
    }
}
