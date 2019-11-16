// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.

using System;
using System.Net;

namespace HtmlAgilityPack
{
    internal interface IHttpWebRequest
    /// <summary>
    /// Abstracts HttpWebRequest.
    /// </summary>
    {
        HttpWebRequest Request { get; }
        string Method { get; set; }
        string UserAgent { get; set; }
        bool AllowAutoRedirect { get; set; }
        ICredentials Credentials { get; set; }
        IWebProxy Proxy { get; set; }
        Uri RequestUri { get; }
        DateTime IfModifiedSince { get; set; }
        CookieContainer CookieContainer { get; set; }

        IHttpWebResponse GetResponse();
    }
}
