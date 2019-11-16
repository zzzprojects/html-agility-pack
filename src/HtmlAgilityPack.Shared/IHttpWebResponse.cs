// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.

using System.IO;
using System.Net;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Abstracts HttpWebResponse.
    /// </summary>
    internal interface IHttpWebResponse : IDisposable
    {
        HttpWebResponse Response { get; }
        Uri ResponseUri { get; }
        HttpStatusCode StatusCode { get; }
        string ContentType { get; }
        string ContentEncoding { get; }
        WebHeaderCollection Headers { get; }
        DateTime LastModified { get; }

        Stream GetResponseStream();
        void Close();
    }
}
