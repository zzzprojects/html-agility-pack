using System;
using System.Net;

namespace HtmlAgilityPack
{
    internal interface IHttpWebRequest
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
