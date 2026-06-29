// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

namespace HtmlAgilityPack
{
    partial class Trace
    {
#if NET8_0_OR_GREATER
        partial void WriteLineIntern(string? message, string? category)
#else
        partial void WriteLineIntern(string message, string category)
#endif
        {
            System.Diagnostics.Debug.WriteLine(message, category);
        }
    }
}