/* First released in 'Dawnx', it is now available to HAP under the MIT protocol */

using System;
using System.Xml.XPath;

namespace HtmlAgilityPack
{
    [AttributeUsage(AttributeTargets.Method)]
    public class XPathFunctionAttribute : Attribute
    {
        public string Namespace { get; private set; }
        public string Name { get; private set; }

        /// <summary>
        /// Defines a function named '{DefaultNamespace}:{$name}' in the context.
        ///     Project each <see cref="XPathResultType"/> into the function's arguments.
        ///     (If you need the 'docContext', you must use a <see cref="XPathNavigator"/> parameter to receive it.)
        /// </summary>
        /// <param name="name"></param>
        public XPathFunctionAttribute(string name) : this(null, name) { }

        /// <summary>
        /// Defines a function named '{$namespace}:{$name}' in the context.
        ///     Project each <see cref="XPathResultType"/> into the function's arguments.
        ///     (If you need the 'docContext', you must use a <see cref="XPathNavigator"/> parameter to receive it.)
        /// </summary>
        /// <param name="namespaceUri"></param>
        /// <param name="name"></param>
        public XPathFunctionAttribute(string namespaceUri, string name)
        {
            Namespace = namespaceUri;
            Name = name;
        }

    }
}