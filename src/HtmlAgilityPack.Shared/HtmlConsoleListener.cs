// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

#if !NETSTANDARD1_3 && !NETSTANDARD1_6 && !METRO
using System;
using System.Diagnostics;

namespace HtmlAgilityPack
{
    internal class HtmlConsoleListener : TraceListener
    {
#region Public Methods

#if NET8_0_OR_GREATER
        public override void Write(string? message)
#else
        public override void Write(string message)
#endif
        {
            Write(message, "");
        }

#if NET8_0_OR_GREATER
        public override void Write(string? message, string? category)
#else
        public override void Write(string message, string category)
#endif
        {
            Console.Write("T:" + category + ": " + message);
        }

#if NET8_0_OR_GREATER
        public override void WriteLine(string? message)
#else
        public override void WriteLine(string message)
#endif
        {
            Write(message + "\n");
        }

#if NET8_0_OR_GREATER
        public override void WriteLine(string? message, string? category)
#else
        public override void WriteLine(string message, string category)
#endif
        {
            Write(message + "\n", category);
        }

#endregion
    }
}
#endif