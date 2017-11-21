// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.



namespace HtmlAgilityPack
{
    public partial class HtmlNode
    {
    }


    public static class HtmlDocumentExtensions
    {
        public static T GetEncapsulatedData<T>(this HtmlDocument htmlDocument)
        {
            T targetObject = Activator.CreateInstance<T>();

            #region targetObject_Defined_XPath
            if (typeof(T).IsDefined(typeof(HasXPathAttribute))) // Object has xpath attribute (Defined HasXPath)
            {
                // Store list of properties that defined xpath attribute
                List<PropertyInfo> validProperties = Tools.GetPropertiesDefinedXPath(typeof(T)).ToList();

                foreach (PropertyInfo propertyInfo in validProperties)
                {
                    XPathAttribute xPathAttribute = propertyInfo.GetCustomAttribute<XPathAttribute>(); // Get xpath attribute from valid properties

                    #region Property_IsNOT_IEnumerable
                    if (Tools.IsIEnumerable(propertyInfo) == false) // Property is None-IEnumerable
                    {
                        HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(xPathAttribute.XPath);

                        #region Property_Is_HasXPath_UserDefinedClass
                        if (propertyInfo.PropertyType.IsDefined(typeof(HasXPathAttribute))) // Property is None-IEnumerable HasXPath-user-defined class
                        {
                            HtmlDocument innerHtmlDocument = new HtmlDocument();
                            innerHtmlDocument.LoadHtml(htmlNode.InnerHtml);

                            MethodInfo getEncapsulatedData = typeof(HtmlDocumentExtensions).GetMethod("GetEncapsulatedData", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(propertyInfo.PropertyType);
                            object o = getEncapsulatedData.Invoke(null, new object[] { innerHtmlDocument });

                            propertyInfo.SetValue(targetObject, o);
                        }
                        #endregion Property_Is_HasXPath_UserDefinedClass

                        #region Property_Is_SimpleType
                        // Property is None-IEnumerable value-type or .Net class or user-defined class (does not deifned xpath and shouldn't have property that defined xpath )
                        else
                        {
                            string result = string.Empty;

                            if (xPathAttribute.AttributeName == null) // It target None-IEnumerable value of HTMLTag 
                            {
                                result = Tools.GetNodeValueBasedOnXPathReturnType(htmlNode, xPathAttribute);
                            }
                            else // It target None-IEnumerable attribute of HTMLTag
                            {
                                result = htmlNode.GetAttributeValue(xPathAttribute.AttributeName, "Html Tag Attribute Not Specified");
                            }

                            propertyInfo.SetValue(targetObject, Convert.ChangeType(result, propertyInfo.PropertyType));
                        }
                        #endregion Property_Is_SimpleType
                    }
                    #endregion Property_IsNOT_IEnumerable

                    #region Property_Is_IEnumerable
                    else // Property is IEnumerable<T>
                    {
                        IEnumerable<Type> T_Types = Tools.GetGenericTypes(propertyInfo); // Get T type

                        if (T_Types == null || T_Types.Count() == 0)
                        {
                            throw new NotImplementedException();
                        }

                        else if (T_Types.Count() > 1)
                        {
                            throw new NotImplementedException();
                        }

                        else if (T_Types.Count() == 1) // It is NOT something like Dictionary<Tkey , Tvalue>
                        {
                            HtmlNodeCollection nodeCollection = htmlDocument.DocumentNode.SelectNodes(xPathAttribute.XPath);

                            IList result = Tools.CreateIListOfType(T_Types.First());

                            #region Property_Is_IEnumerable<HasXPath-UserDefinedClass>
                            if (T_Types.First().IsDefined(typeof(HasXPathAttribute))) // T is IEnumerable HasXPath-user-defined class (T type Defined XPath properties)
                            {
                                foreach (HtmlNode node in nodeCollection)
                                {
                                    HtmlDocument innerHtmlDocument = new HtmlDocument();
                                    innerHtmlDocument.LoadHtml(node.InnerHtml);

                                    MethodInfo getEncapsulatedData = typeof(HtmlDocumentExtensions).GetMethod("GetEncapsulatedData", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(T_Types.First());
                                    object o = getEncapsulatedData.Invoke(null, new object[] { innerHtmlDocument });

                                    result.Add(o);
                                }
                            }
                            #endregion Property_Is_IEnumerable<HasXPath-UserDefinedClass>

                            #region Property_Is_IEnumerable<SimpleClass>
                            else // T is value-type or .Net class or user-defined class ( without xpath )
                            {
                                if (xPathAttribute.AttributeName == null) // It target value
                                {
                                    result = Tools.GetNodesValuesBasedOnXPathReturnType(nodeCollection, xPathAttribute, T_Types.First()) as IList;
                                }
                                else // It target attribute
                                {
                                    foreach (HtmlNode node in nodeCollection)
                                    {
                                        result.Add(Convert.ChangeType(node.GetAttributeValue(xPathAttribute.AttributeName, "Html Tag Attribute Not Specified"), T_Types.First()));
                                    }
                                }
                            }
                            #endregion Property_Is_IEnumerable<SimpleClass>

                            propertyInfo.SetValue(targetObject, result);
                        }
                    }
                    #endregion Property_IsNOT_IEnumerable
                }

                return targetObject;
            }
            #endregion targetObject_Defined_XPath

            #region targetObject_NOTDefined_XPath
            else // Object doesen't have xpath attribute
            {
                throw new NotImplementedException();
            }
            #endregion targetObject_NOTDefined_XPath
        }
    }

    internal class Tools
    {
        public static IEnumerable<PropertyInfo> GetPropertiesDefinedXPath(Type t)
        {
            return t.GetProperties().Where(property => property.IsDefined(typeof(XPathAttribute)));
        }

        public static bool IsIEnumerable(PropertyInfo propertyInfo)
        {
            //return propertyInfo.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null;
            if (propertyInfo.PropertyType == typeof(string))
            {
                return false;
            }
            else
            {
                return typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);
            }
        }

        public static IEnumerable<Type> GetGenericTypes(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.GetGenericArguments();
        }

        public static bool DoesHaveXPathProperty(Type t)
        {
            return GetPropertiesDefinedXPath(t).Count() != 0;
        }

        public static string GetNodeValueBasedOnXPathReturnType(HtmlNode htmlNode, XPathAttribute xPathAttribute)
        {
            switch (xPathAttribute.NodeReturnType)
            {
                case ReturnType.InnerHtml:
                    return htmlNode.InnerHtml;

                case ReturnType.InnerText:
                    return htmlNode.InnerText;

                case ReturnType.OuterHtml:
                    return htmlNode.OuterHtml;

                default: throw new NotImplementedException();
            }
        }

        public static IList CreateIListOfType(Type type)
        {
            Type listType = typeof(List<>);
            Type constructedListType = listType.MakeGenericType(type);
            return Activator.CreateInstance(constructedListType) as IList;
        }

        public static IList GetNodesValuesBasedOnXPathReturnType(HtmlNodeCollection htmlNodeCollection, XPathAttribute xPathAttribute, Type listGenericType)
        {
            IList result = CreateIListOfType(listGenericType);

            switch (xPathAttribute.NodeReturnType)
            {
                case ReturnType.InnerHtml:
                    {
                        foreach (HtmlNode node in htmlNodeCollection)
                        {
                            result.Add(Convert.ChangeType(node.InnerHtml, listGenericType));
                        }
                    }
                    break;
                case ReturnType.InnerText:
                    {
                        foreach (HtmlNode node in htmlNodeCollection)
                        {
                            result.Add(Convert.ChangeType(node.InnerText, listGenericType));
                        }
                    }
                    break;
                case ReturnType.OuterHtml:
                    {
                        foreach (HtmlNode node in htmlNodeCollection)
                        {
                            result.Add(Convert.ChangeType(node.OuterHtml, listGenericType));
                        }
                    }
                    break;
            }

            return result;
        }
    }


    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class HasXPathAttribute : Attribute
    {

    }


    public enum ReturnType
    {
        InnerText,
        InnerHtml,
        OuterHtml
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class XPathAttribute : Attribute
    {
        public string XPath { get; }
        public string AttributeName { get; set; }
        public ReturnType NodeReturnType { get; set; }

        public XPathAttribute(string xpathString, ReturnType nodeReturnType = ReturnType.InnerText)
        {
            XPath = xpathString;
            NodeReturnType = nodeReturnType;
        }

        public XPathAttribute(string xpathString, string attributeName)
        {
            XPath = xpathString;
            AttributeName = attributeName;
        }
    }
}
