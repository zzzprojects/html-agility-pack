// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

#if METRO
namespace HtmlAgilityPack
{
    internal class NameValuePair
    {
#region Fields

        internal readonly string Name;
        internal string Value;

#endregion

#region Constructors

        internal NameValuePair()
        {
        }

        internal NameValuePair(string name)
            :
            this()
        {
            Name = name;
        }

        internal NameValuePair(string name, string value)
            :
            this(name)
        {
            Value = value;
        }

#endregion
    }
}
#endif