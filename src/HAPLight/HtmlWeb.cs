using System;
using System.Net;
using System.Text;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Used for downloading and parsing html from the internet
    /// </summary>
    public class HtmlWeb
    {
        #region Delegates

        /// <summary>
        /// Represents the method that will handle the PreHandleDocument event.
        /// </summary>
        public delegate void PreHandleDocumentHandler(HtmlDocument document);

        #endregion

        #region Fields

        /// <summary>
        /// Occurs before an HTML document is handled.
        /// </summary>
        public PreHandleDocumentHandler PreHandleDocument;

        #endregion

        #region Instance Methods

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        public void LoadAsync(string url)
        {
            LoadAsync(new Uri(url), null, null);
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="encoding">The encoding to use while downloading the document</param>
        public void LoadAsync(string url, Encoding encoding)
        {
            LoadAsync(new Uri(url), encoding, null);
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="encoding">The encoding to use while downloading the document</param>
        /// <param name="userName">Username to use for credentials in the web request</param>
        /// <param name="password">Password to use for credentials in the web request</param>
        public void LoadAsync(string url, Encoding encoding, string userName, string password)
        {
            LoadAsync(new Uri(url), encoding, new NetworkCredential(userName, password));
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="encoding">The encoding to use while downloading the document</param>
        /// <param name="userName">Username to use for credentials in the web request</param>
        /// <param name="password">Password to use for credentials in the web request</param>
        /// <param name="domain">Domain to use for credentials in the web request</param>
        public void LoadAsync(string url, Encoding encoding, string userName, string password, string domain)
        {
            LoadAsync(new Uri(url), encoding, new NetworkCredential(userName, password, domain));
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="userName">Username to use for credentials in the web request</param>
        /// <param name="password">Password to use for credentials in the web request</param>
        /// <param name="domain">Domain to use for credentials in the web request</param>
        public void LoadAsync(string url, string userName, string password, string domain)
        {
            LoadAsync(new Uri(url), null, new NetworkCredential(userName, password, domain));
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="userName">Username to use for credentials in the web request</param>
        /// <param name="password">Password to use for credentials in the web request</param>
        public void LoadAsync(string url, string userName, string password)
        {
            LoadAsync(new Uri(url), null, new NetworkCredential(userName, password));
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="url">Url to the html document</param>
        /// <param name="credentials">The credentials to use for authenticating the web request</param>
        public void LoadAsync(string url, NetworkCredential credentials)
        {
            LoadAsync(new Uri(url), null, credentials);
        }

        /// <summary>
        /// Begins the process of downloading an internet resource
        /// </summary>
        /// <param name="uri">Url to the html document</param>
        /// <param name="encoding">The encoding to use while downloading the document</param>
        /// <param name="credentials">The credentials to use for authenticating the web request</param>
        public void LoadAsync(Uri uri, Encoding encoding, NetworkCredential credentials)
        {
            var client = new WebClient();
            if (credentials == null)
                client.UseDefaultCredentials = true;
            else
                client.Credentials = credentials;

            if (encoding != null)
                client.Encoding = encoding;

            client.DownloadStringCompleted += ClientDownloadStringCompleted;
            client.DownloadStringAsync(uri);
        }

        private void OnLoadCompleted(HtmlDocumentLoadCompleted htmlDocumentLoadCompleted)
        {
            if (LoadCompleted != null)
                LoadCompleted(this, htmlDocumentLoadCompleted);
        }

        #endregion

        #region Event Handling

        private void ClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                OnLoadCompleted(new HtmlDocumentLoadCompleted(e.Error));
            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(e.Result);
                if (PreHandleDocument != null)
                    PreHandleDocument(doc);

                OnLoadCompleted(new HtmlDocumentLoadCompleted(doc));
            }
            catch (Exception err)
            {
                OnLoadCompleted(new HtmlDocumentLoadCompleted(err));
            }
        }

        #endregion

        #region Event Declarations
        /// <summary>
        /// Fired when a web request has finished
        /// </summary>
        public event EventHandler<HtmlDocumentLoadCompleted> LoadCompleted;

        #endregion

        #region Public Static Methods
        /// <summary>
        /// Retrieves an HtmlDocument using the provided url
        /// </summary>
        /// <param name="url">The address to load</param>
        /// <param name="callback"></param>
        public static void LoadAsync(string url, EventHandler<HtmlDocumentLoadCompleted> callback)
        {
            var web = new HtmlWeb();
            web.LoadCompleted += callback;
            web.LoadAsync(url);
        }

        #endregion
    }
}