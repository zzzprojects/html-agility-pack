using System;
using System.Net;

namespace HtmlAgilityPack
{
    internal class HttpWebRequestWrapper : IHttpWebRequest
    {
        HttpWebRequest _request;
        public HttpWebRequest Request { get { return _request; } }

        public HttpWebRequestWrapper(HttpWebRequest request)
        {
            _request = request;
        }

        public string Method { get { return _request.Method; } set { _request.Method = value; } }
        public string UserAgent { get { return _request.UserAgent; } set { _request.UserAgent = value; } }
        public bool AllowAutoRedirect { get { return _request.AllowAutoRedirect; } set { _request.AllowAutoRedirect = value; } }
        public ICredentials Credentials { get { return _request.Credentials; } set { _request.Credentials = value; } }
        public IWebProxy Proxy { get { return _request.Proxy; } set { _request.Proxy = value; } }
        public Uri RequestUri { get { return _request.RequestUri; } }
        public DateTime IfModifiedSince { get { return _request.IfModifiedSince; } set { _request.IfModifiedSince = value; } }
        public CookieContainer CookieContainer { get { return _request.CookieContainer; } set { _request.CookieContainer = value; } }

        public IHttpWebResponse GetResponse()
        {
            return new HttpWebResponseWrapper((HttpWebResponse)_request.GetResponse());
        }
    }
}
