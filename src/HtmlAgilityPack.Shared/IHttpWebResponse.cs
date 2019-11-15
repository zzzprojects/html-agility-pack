using System;
using System.IO;
using System.Net;

namespace HtmlAgilityPack
{
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
