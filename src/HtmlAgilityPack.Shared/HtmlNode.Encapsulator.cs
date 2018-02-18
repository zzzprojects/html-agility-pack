// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.

#if !METRO && !NETSTANDARD1_3

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace HtmlAgilityPack
{
    public partial class HtmlNode
    {
        /// <summary>
        /// Fill an object and go through it's properties and fill them too.
        /// </summary>
        /// <typeparam name="T">Type of object to want to fill. It should have atleast one property that defined XPath.</typeparam>
        /// <param name="htmlDocument">If htmlDocument includes data , leave this parameter null. Else pass your specific htmldocument.</param>
        /// <returns>Returns an object of type T including Encapsulated data.</returns>
        public T GetEncapsulatedData<T>(HtmlDocument htmlDocument = null)
        {
            HtmlDocument source = null;

            if (htmlDocument == null)
            {
                source = OwnerDocument;
            }
            else
            {
                source = htmlDocument;
            }

            T targetObject = Activator.CreateInstance<T>();

            #region targetObject_Defined_XPath
            if (Tools.IsDefinedAttr(typeof(T), (typeof(HasXPathAttribute))) == true) // Object has xpath attribute (Defined HasXPath)
            {
                // Store list of properties that defined xpath attribute
                IEnumerable<PropertyInfo> validProperties = Tools.GetPropertiesDefinedXPath(typeof(T));

                foreach (PropertyInfo propertyInfo in validProperties)
                {
                    XPathAttribute xPathAttribute = (propertyInfo.GetCustomAttributes(typeof(XPathAttribute), false) as IList)[0] as XPathAttribute; // Get xpath attribute from valid properties

                    #region Property_IsNOT_IEnumerable
                    if (Tools.IsIEnumerable(propertyInfo) == false) // Property is None-IEnumerable
                    {
                        HtmlNode htmlNode = source.DocumentNode.SelectSingleNode(xPathAttribute.XPath);

                        #region Property_Is_HasXPath_UserDefinedClass
                        if (Tools.IsDefinedAttr(propertyInfo.PropertyType, (typeof(HasXPathAttribute))) == true) // Property is None-IEnumerable HasXPath-user-defined class
                        {
                            HtmlDocument innerHtmlDocument = new HtmlDocument();
                            innerHtmlDocument.LoadHtml(htmlNode.InnerHtml);

                            MethodInfo getEncapsulatedData = Tools.GetMethodByItsName(typeof(HtmlNode), "GetEncapsulatedData").MakeGenericMethod(propertyInfo.PropertyType);
                            object o = getEncapsulatedData.Invoke(innerHtmlDocument.DocumentNode, new object[] { innerHtmlDocument });

                            propertyInfo.SetValue(targetObject, o, null);
                        }
                        #endregion Property_Is_HasXPath_UserDefinedClass

                        #region Property_Is_SimpleType
                        // Property is None-IEnumerable value-type or .Net class or user-defined class (does not deifned xpath and shouldn't have property that defined xpath )
                        else
                        {
                            string result = string.Empty;

                            if (xPathAttribute.AttributeName == null) // It target None-IEnumerable value of HTMLTag 
                            {
                                result = Tools.GetNodeValueBasedOnXPathReturnType<string>(htmlNode, xPathAttribute);
                            }
                            else // It target None-IEnumerable attribute of HTMLTag
                            {
                                result = htmlNode.GetAttributeValue(xPathAttribute.AttributeName, "Html Tag Attribute Not Specified");
                            }

                            propertyInfo.SetValue(targetObject, Convert.ChangeType(result, propertyInfo.PropertyType), null);
                        }
                        #endregion Property_Is_SimpleType
                    }
                    #endregion Property_IsNOT_IEnumerable

                    #region Property_Is_IEnumerable
                    else // Property is IEnumerable<T>
                    {
                        IList<Type> T_Types = Tools.GetGenericTypes(propertyInfo) as IList<Type>; // Get T type

                        if (T_Types == null || T_Types.Count == 0)
                        {
                            throw new NotImplementedException();
                        }

                        else if (T_Types.Count > 1)
                        {
                            throw new NotImplementedException();
                        }

                        else if (T_Types.Count == 1) // It is NOT something like Dictionary<Tkey , Tvalue>
                        {
                            HtmlNodeCollection nodeCollection = source.DocumentNode.SelectNodes(xPathAttribute.XPath);

                            IList result = Tools.CreateIListOfType(T_Types[0]);

                            #region Property_Is_IEnumerable<HasXPath-UserDefinedClass>
                            if (Tools.IsDefinedAttr(T_Types[0], typeof(HasXPathAttribute)) == true) // T is IEnumerable HasXPath-user-defined class (T type Defined XPath properties)
                            {
                                foreach (HtmlNode node in nodeCollection)
                                {
                                    HtmlDocument innerHtmlDocument = new HtmlDocument();
                                    innerHtmlDocument.LoadHtml(node.InnerHtml);

                                    MethodInfo getEncapsulatedData = Tools.GetMethodByItsName(typeof(HtmlNode), "GetEncapsulatedData").MakeGenericMethod(T_Types[0]);
                                    object o = getEncapsulatedData.Invoke(innerHtmlDocument.DocumentNode, new object[] { innerHtmlDocument });

                                    result.Add(o);
                                }
                            }
                            #endregion Property_Is_IEnumerable<HasXPath-UserDefinedClass>

                            #region Property_Is_IEnumerable<SimpleClass>
                            else // T is value-type or .Net class or user-defined class ( without xpath )
                            {
                                if (xPathAttribute.AttributeName == null) // It target value
                                {
                                    result = Tools.GetNodesValuesBasedOnXPathReturnType(nodeCollection, xPathAttribute, T_Types[0]);
                                }
                                else // It target attribute
                                {
                                    foreach (HtmlNode node in nodeCollection)
                                    {
                                        result.Add(Convert.ChangeType(node.GetAttributeValue(xPathAttribute.AttributeName, "Html Tag Attribute Not Specified"), T_Types[0]));
                                    }
                                }
                            }
                            #endregion Property_Is_IEnumerable<SimpleClass>

                            propertyInfo.SetValue(targetObject, result, null);
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

    /// <summary>
    /// Includes tools that GetEncapsulatedData method uses them.
    /// </summary>
    public static class Tools
    {



        /// <summary>
        /// Determine if a type define an attribute or not , supporting both .NetStandard and .NetFramework2.0
        /// </summary>
        /// <param name="type">Type you want to test it.</param>
        /// <param name="attributeType">Attribute that type must have or not.</param>
        /// <returns>If true , The type parameter define attributeType parameter.</returns>
        public static bool IsDefinedAttr(Type type, Type attributeType)
        {

#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            if (type.IsDefined(typeof(HasXPathAttribute),false) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
#endif


#if NETSTANDARD1_3 || NETSTANDARD1_6
            if (type.GetTypeInfo().IsDefined(typeof(HasXPathAttribute)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
#endif

            throw new NotImplementedException("Can't Target any platform.");
        }


        /// <summary>
        /// Find property infos that defined specific attribute.
        /// </summary>
        /// <param name="properties">Array of property infos that should examin.</param>
        /// <param name="attributeType">The type of attribute that property infos should have.</param>
        /// <returns>IEnumerable of property infos that defined specific attribute.</returns>
        public static IEnumerable<PropertyInfo> LinqWherePropertyInfoDefinedAttribute(PropertyInfo[] properties, Type attributeType)
        {
            foreach (PropertyInfo property in properties)
            {
                if (property.IsDefined(attributeType, false))
                {
                    yield return property;
                }
            }
        }


        /// <summary>
        /// Retrive properties of type that defined <see cref="XPathAttribute"/>.
        /// </summary>
        /// <param name="type">Type that you want to find it's XPath-Defined properties.</param>
        /// <returns>IEnumerable of property infos of a type , that defined specific attribute.</returns>
        public static IEnumerable<PropertyInfo> GetPropertiesDefinedXPath(Type type)
        {
            PropertyInfo[] properties = null;

#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            properties = type.GetProperties();
#endif


#if NETSTANDARD1_3 || NETSTANDARD1_6
            properties = type.GetTypeInfo().GetProperties();
#endif


            return LinqWherePropertyInfoDefinedAttribute(properties, typeof(XPathAttribute));
            //throw new NotImplementedException("Can't Target any platform.");
        }






        /// <summary>
        /// Determine if a <see cref="PropertyInfo"/> has implemented <see cref="IEnumerable"/> BUT <see cref="string"/> is considered as NONE-IEnumerable !
        /// </summary>
        /// <param name="propertyInfo">The property info you want to test.</param>
        /// <returns>True if property info is IEnumerable.</returns>
        public static bool IsIEnumerable(PropertyInfo propertyInfo)
        {
            //return propertyInfo.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null;
            if (propertyInfo.PropertyType == typeof(string))
            {
                return false;
            }
            else
            {
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
                return typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);
#endif


#if NETSTANDARD1_3 || NETSTANDARD1_6
                return typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(propertyInfo.PropertyType);
#endif

                throw new NotImplementedException("Can't Target any platform.");
            }
        }


        /// <summary>
        /// Returns T type(first generic type) of <see cref="IEnumerable{T}"/> or <see cref="List{T}"/>.
        /// </summary>
        /// <param name="propertyInfo">IEnumerable-Implemented property</param>
        /// <returns>List of generic types.</returns>
        public static IEnumerable<Type> GetGenericTypes(PropertyInfo propertyInfo)
        {

#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            return propertyInfo.PropertyType.GetGenericArguments();
#endif


#if NETSTANDARD1_3 || NETSTANDARD1_6
            return propertyInfo.PropertyType.GetTypeInfo().GetGenericArguments();
#endif

            throw new NotImplementedException("Can't Target any platform.");
        }


        /// <summary>
        /// Find and Return a mehtod that defined in a class by it's name.
        /// </summary>
        /// <param name="type">Type of class include requested method.</param>
        /// <param name="methodName">Name of requested method as string.</param>
        /// <returns>Method info of requested method.</returns>
        public static MethodInfo GetMethodByItsName(Type type, string methodName)
        {
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            return type.GetMethod(methodName);
#endif


#if NETSTANDARD1_3 || NETSTANDARD1_6
            return type.GetTypeInfo().GetMethod(methodName);
#endif

            throw new NotImplementedException("Can't Target any platform.");
        }


        /// <summary>
        /// Create <see cref="IList"/> of given type.
        /// </summary>
        /// <param name="type">Type that you want to make a List of it.</param>
        /// <returns>Returns IList of given type.</returns>
        public static IList CreateIListOfType(Type type)
        {
            Type listType = typeof(List<>);
            Type constructedListType = listType.MakeGenericType(type);
            return Activator.CreateInstance(constructedListType) as IList;
        }




        /// <summary>
        /// Returns the part of value of <see cref="HtmlNode"/> you want as .
        /// </summary>
        /// <param name="htmlNode">A htmlNode instance.</param>
        /// <param name="xPathAttribute">Attribute that includes ReturnType</param>
        /// <returns>String that choosen from HtmlNode as result.</returns>
        public static T GetNodeValueBasedOnXPathReturnType<T>(HtmlNode htmlNode, XPathAttribute xPathAttribute)
        {
            switch (xPathAttribute.NodeReturnType)
            {
                case ReturnType.InnerHtml:
                    return (T)Convert.ChangeType(htmlNode.InnerHtml, typeof(T));

                case ReturnType.InnerText:
                    return (T)Convert.ChangeType(htmlNode.InnerText, typeof(T));

                case ReturnType.OuterHtml:
                    return (T)Convert.ChangeType(htmlNode.OuterHtml, typeof(T));

                default: throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Returns parts of values of <see cref="HtmlNode"/> you want as <see cref="IList{T}"/>.
        /// </summary>
        /// <param name="htmlNodeCollection"><see cref="HtmlNodeCollection"/> that you want to retrive each <see cref="HtmlNode"/> value.</param>
        /// <param name="xPathAttribute">A <see cref="XPathAttribute"/> instnce incules <see cref="ReturnType"/>.</param>
        /// <param name="listGenericType">Type of IList generic you want.</param>
        /// <returns></returns>
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


    /// <summary>
    /// Specify which part of <see cref="HtmlNode"/> is requested.
    /// </summary>
    public enum ReturnType
    {
        InnerText,
        InnerHtml,
        OuterHtml
    }


    /// <summary>
    /// Just mark and flag classes to show they have properties that defined <see cref="XPathAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class HasXPathAttribute : Attribute
    {

    }



    /// <summary>
    /// Includes XPath and <see cref="NodeReturnType"/>. XPath for finding html tags and <see cref="NodeReturnType"/> for specify which part of <see cref="HtmlNode"/> you want to return.
    /// </summary>
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

#endif