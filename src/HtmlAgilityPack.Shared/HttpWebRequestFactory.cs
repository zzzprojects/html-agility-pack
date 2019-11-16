// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.

#if !(NETSTANDARD1_3 || NETSTANDARD1_6 || METRO)

using System;
using System.Net;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Implement the initialization of HttpWebRequest.
    /// </summary>
    internal class HttpWebRequestFactory : IHttpWebRequestFactory
    {
        public HttpWebRequestFactory()
        {
        }

        public IHttpWebRequest Create(Uri uri)
        {
            return new HttpWebRequestWrapper((HttpWebRequest)HttpWebRequest.Create(uri));
        }
    }
}

#endif
