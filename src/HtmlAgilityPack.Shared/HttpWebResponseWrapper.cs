using System;
using System.IO;
using System.Net;

namespace HtmlAgilityPack
{
    internal class HttpWebResponseWrapper : IHttpWebResponse
    {
        HttpWebResponse _response;
        public HttpWebResponse Response { get { return _response; } }

        public HttpWebResponseWrapper(HttpWebResponse response)
        {
            _response = response;
        }

        public Uri ResponseUri { get { return _response.ResponseUri; } }
        public HttpStatusCode StatusCode { get { return _response.StatusCode; } }
        public string ContentType { get { return _response.ContentType; } }
        public string ContentEncoding { get { return _response.ContentEncoding; } }
        public WebHeaderCollection Headers { get { return _response.Headers; } }
        public DateTime LastModified { get { return _response.LastModified; } }

        public void Close()
        {
            _response.Close();
        }

        public void Dispose()
        {
#if NET20 || NET35 || NET40
			_response.Dispose();
#endif
        }

        public Stream GetResponseStream()
        {
            return _response.GetResponseStream();
        }
    }
}
