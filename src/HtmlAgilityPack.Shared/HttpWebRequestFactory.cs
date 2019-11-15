using System;
using System.Net;

namespace HtmlAgilityPack
{
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
