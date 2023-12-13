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
        internal static Trace _current;

        internal static Trace Current
        {
            get
            {
                if (_current == null)
                    _current = new Trace();
                return _current;
            }
        }

        partial void WriteLineIntern(string message, string category);

        public static void WriteLine(string message, string category)
        {
            Current.WriteLineIntern(message, category);
        }
    }
}