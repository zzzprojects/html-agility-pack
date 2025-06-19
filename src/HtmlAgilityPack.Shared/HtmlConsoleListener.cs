﻿// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
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

        public override void Write(string? Message)
        {
            Write(Message, "");
        }

        public override void Write(string? Message, string? Category)
        {
            Console.Write("T:" + Category + ": " + Message);
        }

        public override void WriteLine(string? Message)
        {
            Write(Message + "\n");
        }

        public override void WriteLine(string? Message, string? Category)
        {
            Write(Message + "\n", Category);
        }

#endregion
    }
}
#endif