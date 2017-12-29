#if METRO
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Used for downloading and parsing html from the internet
    /// </summary>
    public class HtmlWeb
    {
        /// <summary>
        /// Allows for setting document defaults before loading
        /// </summary>
        public Action<HtmlDocument> PreHandleDocument { get; set; }

        #region Instance Methods

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        public async Task<HtmlDocument> LoadFromWebAsync(string url)
        {
            return await LoadFromWebAsync(new Uri(url), null, null);
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="encoding">The encoding to use while downloading the document</param>
        public async Task<HtmlDocument> LoadFromWebAsync(string url, Encoding encoding)
        {
            return await LoadFromWebAsync(new Uri(url), encoding, null);
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="encoding">The encoding to use while downloading the document</param>
        /// <param name="userName">Username to use for credentials in the web request</param>
        /// <param name="password">Password to use for credentials in the web request</param>
        public async Task<HtmlDocument> LoadFromWebAsync(string url, Encoding encoding, string userName, string password)
        {
            return await LoadFromWebAsync(new Uri(url), encoding, new NetworkCredential(userName, password));
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="encoding">The encoding to use while downloading the document</param>
        /// <param name="userName">Username to use for credentials in the web request</param>
        /// <param name="password">Password to use for credentials in the web request</param>
        /// <param name="domain">Domain to use for credentials in the web request</param>
        public async Task<HtmlDocument> LoadFromWebAsync(string url, Encoding encoding, string userName, string password, string domain)
        {
            return await LoadFromWebAsync(new Uri(url), encoding, new NetworkCredential(userName, password, domain));
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="userName">Username to use for credentials in the web request</param>
        /// <param name="password">Password to use for credentials in the web request</param>
        /// <param name="domain">Domain to use for credentials in the web request</param>
        public async Task<HtmlDocument> LoadFromWebAsync(string url, string userName, string password, string domain)
        {
            return await LoadFromWebAsync(new Uri(url), null, new NetworkCredential(userName, password, domain));
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="userName">Username to use for credentials in the web request</param>
        /// <param name="password">Password to use for credentials in the web request</param>
        public async Task<HtmlDocument> LoadFromWebAsync(string url, string userName, string password)
        {
            return await LoadFromWebAsync(new Uri(url), null, new NetworkCredential(userName, password));
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="credentials">The credentials to use for authenticating the web request</param>
        public async Task<HtmlDocument> LoadFromWebAsync(string url, NetworkCredential credentials)
        {
            return await LoadFromWebAsync(new Uri(url), null, credentials);
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="uri">Url to the html document</param>
        /// <param name="encoding">The encoding to use while downloading the document</param>
        /// <param name="credentials">The credentials to use for authenticating the web request</param>
        public async Task<HtmlDocument> LoadFromWebAsync(Uri uri, Encoding encoding, NetworkCredential credentials)
        {
            var clientHandler = new HttpClientHandler();
            if (credentials == null)
                clientHandler.UseDefaultCredentials = true;
            else
                clientHandler.Credentials = credentials;

            var client = new HttpClient(clientHandler);

            var e = await client.GetAsync(uri);
            if (e.StatusCode == HttpStatusCode.OK)
            {
                var html = string.Empty;
                if (encoding != null)
                {
                    using (var sr = new StreamReader(await e.Content.ReadAsStreamAsync(), encoding))
                    {
                        html = sr.ReadToEnd();
                    }
                }
                else
                    html = await e.Content.ReadAsStringAsync();

                var doc = new HtmlDocument();
                if (PreHandleDocument != null)
                    PreHandleDocument(doc);
                doc.LoadHtml(html);
                return doc;
            }

            throw new Exception("Error downloading html");
        }

        #endregion
    }
}
#endif