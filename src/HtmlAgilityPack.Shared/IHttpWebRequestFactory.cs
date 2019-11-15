using System;

namespace HtmlAgilityPack
{
    internal interface IHttpWebRequestFactory
    {
        IHttpWebRequest Create(Uri uri);
    }
}
