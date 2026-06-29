// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

#if !METRO

using System;
using System.Xml.XPath;

namespace HtmlAgilityPack
{
    public partial class HtmlNode : IXPathNavigable
    {
        /// <summary>
        /// Creates a new XPathNavigator object for navigating this HTML node.
        /// </summary>
        /// <returns>An XPathNavigator object. The XPathNavigator is positioned on the node from which the method was called. It is not positioned on the root of the document.</returns>
        public XPathNavigator CreateNavigator()
        {
            return new HtmlNodeNavigator(OwnerDocument, this);
        }

        /// <summary>
        /// Creates an XPathNavigator using the root of this document.
        /// </summary>
        /// <returns></returns>
        public XPathNavigator CreateRootNavigator()
        {
            return new HtmlNodeNavigator(OwnerDocument, OwnerDocument.DocumentNode);
        }

        /// <summary>
        /// Selects a list of nodes matching the <see cref="XPath"/> expression.
        /// </summary>
        /// <param name="xpath">The XPath expression.</param>
        /// <returns>An <see cref="HtmlNodeCollection"/> containing a collection of nodes matching the <see cref="XPath"/> query, or <c>null</c> if no node matched the XPath expression.</returns>

#if NET8_0_OR_GREATER
        public HtmlNodeCollection? SelectNodes(string xpath)
#else
        public HtmlNodeCollection SelectNodes(string xpath)
#endif
        {
            HtmlNodeCollection list = new HtmlNodeCollection(null);

            HtmlNodeNavigator nav = new HtmlNodeNavigator(OwnerDocument, this);
            XPathNodeIterator it = nav.Select(xpath);
            while (it.MoveNext())
            {
#if NET8_0_OR_GREATER
                HtmlNodeNavigator n = (HtmlNodeNavigator)it.Current!;
#else
                HtmlNodeNavigator n = (HtmlNodeNavigator) it.Current;
#endif

                list.Add(n.CurrentNode, false);
            }

            if (list.Count == 0 && !OwnerDocument.OptionEmptyCollection)
            {
                return null;
            }

            return list;
        }

        /// <summary>
        /// Selects a list of nodes matching the <see cref="XPath"/> expression.
        /// </summary>
        /// <param name="xpath">The XPath expression.</param>
        /// <returns>An <see cref="HtmlNodeCollection"/> containing a collection of nodes matching the <see cref="XPath"/> query, or <c>null</c> if no node matched the XPath expression.</returns>

#if NET8_0_OR_GREATER
        public HtmlNodeCollection? SelectNodes(XPathExpression xpath)
#else
        public HtmlNodeCollection SelectNodes(XPathExpression xpath)
#endif
        {
            HtmlNodeCollection list = new HtmlNodeCollection(null);

            HtmlNodeNavigator nav = new HtmlNodeNavigator(OwnerDocument, this);
            XPathNodeIterator it = nav.Select(xpath);
            while (it.MoveNext())
            {
#if NET8_0_OR_GREATER
                HtmlNodeNavigator n = (HtmlNodeNavigator)it.Current!;
#else
                HtmlNodeNavigator n = (HtmlNodeNavigator) it.Current;
#endif

                list.Add(n.CurrentNode, false);
            }

            if (list.Count == 0 && !OwnerDocument.OptionEmptyCollection)
            {
                return null;
            }

            return list;
        }

        /// <summary>
        /// Selects the first XmlNode that matches the <see cref="XPath"/> expression.
        /// </summary>
        /// <param name="xpath">The XPath expression. May not be null.</param>
        /// <returns>The first <see cref="HtmlNode"/> that matches the XPath query or a null reference if no matching node was found.</returns>
#if NET8_0_OR_GREATER
        public HtmlNode? SelectSingleNode(string xpath)
#else
        public HtmlNode SelectSingleNode(string xpath)
#endif
        {
            if (xpath == null)
            {
                throw new ArgumentNullException("xpath");
            }

            HtmlNodeNavigator nav = new HtmlNodeNavigator(OwnerDocument, this);
            XPathNodeIterator it = nav.Select(xpath);
            if (!it.MoveNext())
            {
                return null;
            }

#if NET8_0_OR_GREATER
            HtmlNodeNavigator node = (HtmlNodeNavigator)it.Current!;
#else
            HtmlNodeNavigator node = (HtmlNodeNavigator) it.Current;
#endif

            return node.CurrentNode;
        }

        /// <summary>
        /// Selects the first XmlNode that matches the <see cref="XPath"/> expression.
        /// </summary>
        /// <param name="xpath">The XPath expression.</param>
        /// <returns>An <see cref="HtmlNodeCollection"/> containing a collection of nodes matching the <see cref="XPath"/> query, or <c>null</c> if no node matched the XPath expression.</returns>
#if NET8_0_OR_GREATER
        public HtmlNode? SelectSingleNode(XPathExpression xpath)
#else
        public HtmlNode SelectSingleNode(XPathExpression xpath)
#endif
        {
            if (xpath == null)
            {
                throw new ArgumentNullException("xpath");
            }

            HtmlNodeNavigator nav = new HtmlNodeNavigator(OwnerDocument, this);
            XPathNodeIterator it = nav.Select(xpath);
            if (!it.MoveNext())
            {
                return null;
            }

#if NET8_0_OR_GREATER
            HtmlNodeNavigator node = (HtmlNodeNavigator)it.Current!;
#else
            HtmlNodeNavigator node = (HtmlNodeNavigator)it.Current;
#endif

            return node.CurrentNode;
        }
    }
}
#endif