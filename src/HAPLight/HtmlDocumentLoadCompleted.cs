using System;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Happens when a document has been loaded
    /// </summary>
    public class HtmlDocumentLoadCompleted : EventArgs
    {
        #region Fields
        /// <summary>
        /// The document that has been loaded
        /// </summary>
        public HtmlDocument Document{get;set;}
        /// <summary>
        /// If an error occured when loading the document, null if not
        /// </summary>
        public Exception Error;

        #endregion

        #region C'tors

        internal HtmlDocumentLoadCompleted(HtmlDocument doc)
        {
            Document = doc;
        }

        internal HtmlDocumentLoadCompleted(Exception err)
        {
            Error = err;
        }

        #endregion
    }
}