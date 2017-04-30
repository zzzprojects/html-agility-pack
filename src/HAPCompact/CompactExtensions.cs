using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HtmlAgilityPack
{
    public static class CompactExtensions
    {

        public static string[] Split(this string @this, char[] chars, int count)
        {
            var items = @this.Split(chars);
            return items.Length > 2 ? items.Take(2).ToArray() : items;
        }

        public static string[] Split(this string @this, string[] chars, int count)
        {
            var items = @this.Split(chars,count);
            items = items.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return items.Length > 2 ? items.Take(2).ToArray() : items;
        }
    }
}
