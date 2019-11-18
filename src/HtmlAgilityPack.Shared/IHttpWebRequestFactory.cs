﻿// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.

#if !(NETSTANDARD1_3 || NETSTANDARD1_6 || METRO)

using System;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Abstracts the initialization of HttpWebRequest.
    /// </summary>
    internal interface IHttpWebRequestFactory
    {
        IHttpWebRequest Create(Uri uri);
    }
}

#endif
