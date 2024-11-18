/* First released in Dawnx library, it is now available to HAP under the MIT License */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace HtmlAgilityPack
{
    public abstract partial class XPathContext : XsltContext
    {
        private class ContextFunction
        {
            public string Namespace { get; set; }
            public string Name { get; set; }
            public Type[] ArgTypes { get; set; }
            public Type[] RealArgTypes { get; set; }
            public MethodInfo Method { get; set; }
        }

        private HashSet<ContextFunction> CustomFunctions = new HashSet<ContextFunction>();

        public XPathContext(string prefix) : this()
        {
            AddNamespace(prefix, DefaultNamespace);
        }
        public XPathContext()
        {
            var contextMethods = GetType().GetMethods();
            foreach (var method in contextMethods)
            {
                var attr = method
                    .GetCustomAttributes(typeof(XPathFunctionAttribute), true)
                    .FirstOrDefault() as XPathFunctionAttribute;
                if (attr != null)
                {
                    CustomFunctions.Add(new ContextFunction
                    {
                        Namespace = attr.Namespace ?? DefaultNamespace,
                        Name = attr.Name ?? method.Name,
                        ArgTypes = method.GetParameters()
                            .Where(x => x.ParameterType != typeof(XPathNavigator))
                            .Select(x => x.ParameterType)
                            .ToArray(),
                        RealArgTypes = method.GetParameters().Select(x => x.ParameterType).ToArray(),
                        Method = method,
                    });
                }
            }
        }

        /// <summary>
        /// Gets all the defined argumennts in the context.
        /// </summary>
        public XsltArgumentList ArgList { get; private set; } = new XsltArgumentList();

        /// <summary>
        /// Evaluates whether to preserve white space nodes or strip them for the given context.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public override bool PreserveWhitespace(XPathNavigator node) => false;

        /// <summary>
        /// Compares the base Uniform Resource Identifiers
        ///     (URIs) of two documents based upon the order the documents were loaded by the
        ///     XSLT processor (that is, the System.Xml.Xsl.XslTransform class)
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="nextbaseUri"></param>
        /// <returns></returns>
        public override int CompareDocument(string baseUri, string nextbaseUri) => 0;

        /// <summary>
        /// Gets a value indicating whether to include white space nodes in the output.
        /// </summary>
        public override bool Whitespace => true;

        /// <summary>
        /// Resolves a function reference and returns
        ///     an <see cref="IXsltContextFunction"/> representing the function. The <see cref="IXsltContextFunction"/> 
        ///     is used at execution time to get the return value of the function.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="name"></param>
        /// <param name="argTypes"></param>
        /// <returns></returns>
        public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] argTypes)
            => new XPathFunctionAgent(LookupNamespace(prefix), name);

        /// <summary>
        /// Resolves a variable reference and returns
        ///     an System.Xml.Xsl.IXsltContextVariable representing the variable.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public override IXsltContextVariable ResolveVariable(string prefix, string name)
            => new XPathVariable(prefix, name);

        /// <summary>
        /// Adds a argument to <see cref="ArgList"/> and associates it with the namespace qualified name. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="namespaceUri"></param>
        /// <param name="parameter"></param>
        public void AddParam(string name, string namespaceUri, object parameter)
            => ArgList.AddParam(name, namespaceUri, parameter);

        /// <summary>
        /// Adds a argument to <see cref="ArgList"/> and associates it with empty namespace.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameter"></param>
        public void AddParam(string name, object parameter)
            => ArgList.AddParam(name, "", parameter);

        /// <summary>
        /// Compiles the XPath expression specified and returns an System.Xml.XPath.XPathExpression
        ///     object representing the XPath expression.
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public XPathExpression Compile(string xpath)
        {
            var xExp = XPathExpression.Compile(xpath);
            xExp.SetContext(this);
            return xExp;
        }
        public XPathExpression this[string xpath] => Compile(xpath);

        public class XPathFunctionAgent : IXsltContextFunction
        {
            private string Namespace;
            private string Name;

            public XPathFunctionAgent(string @namespace, string name)
            {
                Namespace = @namespace;
                Name = name;
            }

            public int Minargs => throw new NotSupportedException();
            public int Maxargs => throw new NotSupportedException();
            public XPathResultType ReturnType => XPathResultType.Any;
            public XPathResultType[] ArgTypes => throw new NotSupportedException();

            public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext)
            {
                var context = xsltContext as XPathContext;
                var argTypes = args.Select(x =>
                {
                    switch (x.GetType().FullName)
                    {
                        case "MS.Internal.Xml.XPath.XPathSelectionIterator": return typeof(string);
                        default: return x.GetType();
                    }
                });
                var customFunc = context.CustomFunctions
                    .FirstOrDefault(x => x.Namespace == Namespace && x.Name == Name
                                      && Enumerable.SequenceEqual(argTypes, x.ArgTypes));

                if (customFunc != null)
                {
                    var methodParameterLength = customFunc.Method.GetParameters().Count();
                    var funcArgs = args.Select<object, object>((arg, i) =>
                    {
                        switch (arg.GetType().FullName)
                        {
                            case "MS.Internal.Xml.XPath.XPathSelectionIterator": return GetAttributeValue(args[i]);
                            default: return args[i].ToString();
                        }
                    }).ToArray();

                    int argIndex = 0;
                    var invokeParameters = new List<object>();
                    foreach (var realArgType in customFunc.RealArgTypes)
                    {
                        switch (realArgType)
                        {
                            case Type _ when realArgType == typeof(XPathNavigator):
                                invokeParameters.Add(docContext);
                                break;

                            default:
                                invokeParameters.Add(funcArgs[argIndex++]);
                                break;
                        }
                    }
                    return customFunc.Method.Invoke(context, invokeParameters.ToArray());
                }
                else throw new KeyNotFoundException($"No function found. ({Namespace}.{Name})");
            }

            private string GetAttributeValue(object arg)
            {
                // The type of arg is MS.Internal.Xml.XPath.XPathSelectionIterator.
                var currentProp = arg.GetType().GetProperty("Current");
                var current = currentProp.GetValue(arg, null) as XPathNavigator;

                switch (current.NodeType)
                {
                    case XPathNodeType.Element:
                        foreach (XPathNavigator item in arg as IEnumerable)
                            return item.InnerXml;
                        goto default;

                    default:
                        return string.Empty;
                }
            }

        }

    }
}
