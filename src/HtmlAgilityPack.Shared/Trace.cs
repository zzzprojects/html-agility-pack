// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

namespace HtmlAgilityPack
{
    internal partial class Trace
    {
#if NET8_0_OR_GREATER
        internal static Trace? _current;
#else
        internal static Trace _current;
#endif


        internal static Trace Current
        {
            get
            {
                if (_current == null)
                    _current = new Trace();
                return _current;
            }
        }

#if NET8_0_OR_GREATER
        partial void WriteLineIntern(string? message, string? category);
#else
        partial void WriteLineIntern(string message, string category);
#endif

#if NET8_0_OR_GREATER
        public static void WriteLine(string? message, string? category)
#else
        public static void WriteLine(string message, string category)
#endif
        {
            Current.WriteLineIntern(message, category);
        }
    }
}