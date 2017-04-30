using System;
using System.Linq;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Extensions used for Silverlight Compatibility
    /// </summary>
    public static class SilverlightExtensions
    {
        /// <summary>
        /// Splits a string on provided characters and returns an array up to the count provided
        /// </summary>
        /// <param name="this">The string to split</param>
        /// <param name="chars">The list of chars to split on</param>
        /// <param name="count">The number of items to retrieve</param>
        /// <returns></returns>
        public static string[] Split(this string @this, char[] chars, int count)
        {
            var items = @this.Split(chars);
            return items.Length > count ? items.Take(count).ToArray() : items;
        }        
    }
}
