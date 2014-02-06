using System;
using System.Collections.Generic;
using System.Linq;

namespace TomKamphuis.Helper.Helpers
{
    /// <summary>
    /// Class for extra boolean functionality.
    /// </summary>
    public static class BoolHelper
    {
        /// <summary>
        /// Indicates if the value called upon is in a specified list.
        /// </summary>
        public static bool In<T>(this T value, List<T> list)
        {
            Type currentType = typeof(T);

            if (!currentType.IsPrimitive && !currentType.Equals(typeof(string)))
            {
                throw new NotImplementedException("Only primitive types are supported by this method!");
            }

            if(currentType.Equals(typeof(string)))
            {
                return list.Any(v => string.Equals(v.ToString(), value.ToString(), StringComparison.OrdinalIgnoreCase));
            }

            return list.Any(v => Convert.Equals(v, value));
        }
    }
}