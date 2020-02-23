// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.

#if !METRO

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

#pragma warning disable 0649
namespace HtmlAgilityPack
{
	/// <summary>
	/// Represents an HTML navigator on an HTML document seen as a data store.
	/// </summary>
	public class HtmlNodeNavigator : XPathNavigator
	{
		#region Fields

		private int _attindex;
		private HtmlNode _currentnode;
		private readonly HtmlDocument _doc;
		private readonly HtmlNameTable _nametable;

		internal bool Trace;

		#endregion

		#region Constructors

		internal HtmlNodeNavigator()
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			Reset();
		}

		internal HtmlNodeNavigator(HtmlDocument doc, HtmlNode currentNode)
		{
			if (currentNode == null)
			{
				throw new ArgumentNullException("currentNode");
			}

			if (currentNode.OwnerDocument != doc)
			{
				throw new ArgumentException(HtmlDocument.HtmlExceptionRefNotChild);
			}

			if (doc == null)
			{
				// keep in message, currentNode.OwnerDocument also null.
				throw new Exception("Oops! The HtmlDocument cannot be null.");
			}

#if TRACE_NAVIGATOR
            InternalTrace(null);
#endif

			_doc = doc;
			_nametable = new HtmlNameTable();
			Reset();
			_currentnode = currentNode;
		}

		private HtmlNodeNavigator(HtmlNodeNavigator nav)
		{
			if (nav == null)
			{
				throw new ArgumentNullException("nav");
			}
#if TRACE_NAVIGATOR
            InternalTrace(null);
#endif
			_doc = nav._doc;
			_currentnode = nav._currentnode;
			_attindex = nav._attindex;
			_nametable = nav._nametable; // REVIEW: should we do this?
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public HtmlNodeNavigator(Stream stream)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(stream);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		/// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the stream.</param>
		public HtmlNodeNavigator(Stream stream, bool detectEncodingFromByteOrderMarks)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(stream, detectEncodingFromByteOrderMarks);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		/// <param name="encoding">The character encoding to use.</param>
		public HtmlNodeNavigator(Stream stream, Encoding encoding)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(stream, encoding);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the stream.</param>
		public HtmlNodeNavigator(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(stream, encoding, detectEncodingFromByteOrderMarks);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the stream.</param>
		/// <param name="buffersize">The minimum buffer size.</param>
		public HtmlNodeNavigator(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(stream, encoding, detectEncodingFromByteOrderMarks, buffersize);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a TextReader.
		/// </summary>
		/// <param name="reader">The TextReader used to feed the HTML data into the document.</param>
		public HtmlNodeNavigator(TextReader reader)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(reader);
			Reset();
		}

#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a file.
		/// </summary>
		/// <param name="path">The complete file path to be read.</param>
		public HtmlNodeNavigator(string path)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(path);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a file.
		/// </summary>
		/// <param name="path">The complete file path to be read.</param>
		/// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
		public HtmlNodeNavigator(string path, bool detectEncodingFromByteOrderMarks)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(path, detectEncodingFromByteOrderMarks);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a file.
		/// </summary>
		/// <param name="path">The complete file path to be read.</param>
		/// <param name="encoding">The character encoding to use.</param>
		public HtmlNodeNavigator(string path, Encoding encoding)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(path, encoding);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a file.
		/// </summary>
		/// <param name="path">The complete file path to be read.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
		public HtmlNodeNavigator(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(path, encoding, detectEncodingFromByteOrderMarks);
			Reset();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlNavigator and loads an HTML document from a file.
		/// </summary>
		/// <param name="path">The complete file path to be read.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
		/// <param name="buffersize">The minimum buffer size.</param>
		public HtmlNodeNavigator(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
		{
			_doc = new HtmlDocument();
			_nametable = new HtmlNameTable();
			_doc.Load(path, encoding, detectEncodingFromByteOrderMarks, buffersize);
			Reset();
		}
#endif

		#endregion

		#region Properties

		/// <summary>
		/// Gets the base URI for the current node.
		/// Always returns string.Empty in the case of HtmlNavigator implementation.
		/// </summary>
		public override string BaseURI
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(">");
#endif
				return _nametable.GetOrAdd(string.Empty);
			}
		}

		/// <summary>
		/// Gets the current HTML document.
		/// </summary>
		public HtmlDocument CurrentDocument
		{
			get { return _doc; }
		}

		/// <summary>
		/// Gets the current HTML node.
		/// </summary>
		public HtmlNode CurrentNode
		{
			get { return _currentnode; }
		}

		/// <summary>
		/// Gets a value indicating whether the current node has child nodes.
		/// </summary>
		public override bool HasAttributes
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(">" + (_currentnode.Attributes.Count > 0));
#endif
				return (_currentnode.Attributes.Count > 0);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the current node has child nodes.
		/// </summary>
		public override bool HasChildren
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(">" + (_currentnode.ChildNodes.Count > 0));
#endif
				return (_currentnode.ChildNodes.Count > 0);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the current node is an empty element.
		/// </summary>
		public override bool IsEmptyElement
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(">" + !HasChildren);
#endif
				// REVIEW: is this ok?
				return !HasChildren;
			}
		}

		/// <summary>
		/// Gets the name of the current HTML node without the namespace prefix.
		/// </summary>
		public override string LocalName
		{
			get
			{
				if (_attindex != -1)
				{
#if TRACE_NAVIGATOR
                    InternalTrace("att>" + _currentnode.Attributes[_attindex].Name);
#endif
					return _nametable.GetOrAdd(_currentnode.Attributes[_attindex].Name);
				}

#if TRACE_NAVIGATOR
                InternalTrace("node>" + _currentnode.Name);
#endif
				return _nametable.GetOrAdd(_currentnode.Name);
			}
		}

		/// <summary>
		/// Gets the qualified name of the current node.
		/// </summary>
		public override string Name
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(">" + _currentnode.Name);
#endif
				return _nametable.GetOrAdd(_currentnode.Name);
			}
		}

		/// <summary>
		/// Gets the namespace URI (as defined in the W3C Namespace Specification) of the current node.
		/// Always returns string.Empty in the case of HtmlNavigator implementation.
		/// </summary>
		public override string NamespaceURI
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(">");
#endif
				return _nametable.GetOrAdd(string.Empty);
			}
		}

		/// <summary>
		/// Gets the <see cref="XmlNameTable"/> associated with this implementation.
		/// </summary>
		public override XmlNameTable NameTable
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(null);
#endif
				return _nametable;
			}
		}

		/// <summary>
		/// Gets the type of the current node.
		/// </summary>
		public override XPathNodeType NodeType
		{
			get
			{
				switch (_currentnode.NodeType)
				{
					case HtmlNodeType.Comment:
#if TRACE_NAVIGATOR
                        InternalTrace(">" + XPathNodeType.Comment);
#endif
						return XPathNodeType.Comment;

					case HtmlNodeType.Document:
#if TRACE_NAVIGATOR
                        InternalTrace(">" + XPathNodeType.Root);
#endif
						return XPathNodeType.Root;

					case HtmlNodeType.Text:
#if TRACE_NAVIGATOR
                        InternalTrace(">" + XPathNodeType.Text);
#endif
						return XPathNodeType.Text;

					case HtmlNodeType.Element:
						{
							if (_attindex != -1)
							{
#if TRACE_NAVIGATOR
                            InternalTrace(">" + XPathNodeType.Attribute);
#endif
								return XPathNodeType.Attribute;
							}

#if TRACE_NAVIGATOR
                        InternalTrace(">" + XPathNodeType.Element);
#endif
							return XPathNodeType.Element;
						}

					default:
						throw new NotImplementedException("Internal error: Unhandled HtmlNodeType: " +
														  _currentnode.NodeType);
				}
			}
		}

		/// <summary>
		/// Gets the prefix associated with the current node.
		/// Always returns string.Empty in the case of HtmlNavigator implementation.
		/// </summary>
		public override string Prefix
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(null);
#endif
				return _nametable.GetOrAdd(string.Empty);
			}
		}

		/// <summary>
		/// Gets the text value of the current node.
		/// </summary>
		public override string Value
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace("nt=" + _currentnode.NodeType);
#endif
				switch (_currentnode.NodeType)
				{
					case HtmlNodeType.Comment:
#if TRACE_NAVIGATOR
                        InternalTrace(">" + ((HtmlCommentNode) _currentnode).Comment);
#endif
						return ((HtmlCommentNode) _currentnode).Comment;

					case HtmlNodeType.Document:
#if TRACE_NAVIGATOR
                        InternalTrace(">");
#endif
						return "";

					case HtmlNodeType.Text:
#if TRACE_NAVIGATOR
                        InternalTrace(">" + ((HtmlTextNode) _currentnode).Text);
#endif
						return ((HtmlTextNode) _currentnode).Text;

					case HtmlNodeType.Element:
						{
							if (_attindex != -1)
							{
#if TRACE_NAVIGATOR
                            InternalTrace(">" + _currentnode.Attributes[_attindex].Value);
#endif
								return _currentnode.Attributes[_attindex].Value;
							}

							return _currentnode.InnerText;
						}

					default:
						throw new NotImplementedException("Internal error: Unhandled HtmlNodeType: " +
														  _currentnode.NodeType);
				}
			}
		}

		/// <summary>
		/// Gets the xml:lang scope for the current node.
		/// Always returns string.Empty in the case of HtmlNavigator implementation.
		/// </summary>
		public override string XmlLang
		{
			get
			{
#if TRACE_NAVIGATOR
                InternalTrace(null);
#endif
				return _nametable.GetOrAdd(string.Empty);
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Creates a new HtmlNavigator positioned at the same node as this HtmlNavigator.
		/// </summary>
		/// <returns>A new HtmlNavigator object positioned at the same node as the original HtmlNavigator.</returns>
		public override XPathNavigator Clone()
		{
#if TRACE_NAVIGATOR
            InternalTrace(null);
#endif
			return new HtmlNodeNavigator(this);
		}

		/// <summary>
		/// Gets the value of the HTML attribute with the specified LocalName and NamespaceURI.
		/// </summary>
		/// <param name="localName">The local name of the HTML attribute.</param>
		/// <param name="namespaceURI">The namespace URI of the attribute. Unsupported with the HtmlNavigator implementation.</param>
		/// <returns>The value of the specified HTML attribute. String.Empty or null if a matching attribute is not found or if the navigator is not positioned on an element node.</returns>
		public override string GetAttribute(string localName, string namespaceURI)
		{
#if TRACE_NAVIGATOR
            InternalTrace("localName=" + localName + ", namespaceURI=" + namespaceURI);
#endif
			HtmlAttribute att = _currentnode.Attributes[localName];
			if (att == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">null");
#endif
				return null;
			}

#if TRACE_NAVIGATOR
            InternalTrace(">" + att.Value);
#endif
			return att.Value;
		}

		/// <summary>
		/// Returns the value of the namespace node corresponding to the specified local name.
		/// Always returns string.Empty for the HtmlNavigator implementation.
		/// </summary>
		/// <param name="name">The local name of the namespace node.</param>
		/// <returns>Always returns string.Empty for the HtmlNavigator implementation.</returns>
		public override string GetNamespace(string name)
		{
#if TRACE_NAVIGATOR
            InternalTrace("name=" + name);
#endif
			return string.Empty;
		}

		/// <summary>
		/// Determines whether the current HtmlNavigator is at the same position as the specified HtmlNavigator.
		/// </summary>
		/// <param name="other">The HtmlNavigator that you want to compare against.</param>
		/// <returns>true if the two navigators have the same position, otherwise, false.</returns>
		public override bool IsSamePosition(XPathNavigator other)
		{
			HtmlNodeNavigator nav = other as HtmlNodeNavigator;
			if (nav == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

#if TRACE_NAVIGATOR
            InternalTrace(">" + (nav._currentnode == _currentnode));
#endif
			return (nav._currentnode == _currentnode);
		}

		/// <summary>
		/// Moves to the same position as the specified HtmlNavigator.
		/// </summary>
		/// <param name="other">The HtmlNavigator positioned on the node that you want to move to.</param>
		/// <returns>true if successful, otherwise false. If false, the position of the navigator is unchanged.</returns>
		public override bool MoveTo(XPathNavigator other)
		{
			HtmlNodeNavigator nav = other as HtmlNodeNavigator;
			if (nav == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false (nav is not an HtmlNodeNavigator)");
#endif
				return false;
			}

#if TRACE_NAVIGATOR
            InternalTrace("moveto oid=" + nav.GetHashCode()
                                        + ", n:" + nav._currentnode.Name
                                        + ", a:" + nav._attindex);
#endif

			if (nav._doc == _doc)
			{
				_currentnode = nav._currentnode;
				_attindex = nav._attindex;
#if TRACE_NAVIGATOR
                InternalTrace(">true");
#endif
				return true;
			}

			// we don't know how to handle that
#if TRACE_NAVIGATOR
            InternalTrace(">false (???)");
#endif
			return false;
		}

		/// <summary>
		/// Moves to the HTML attribute with matching LocalName and NamespaceURI.
		/// </summary>
		/// <param name="localName">The local name of the HTML attribute.</param>
		/// <param name="namespaceURI">The namespace URI of the attribute. Unsupported with the HtmlNavigator implementation.</param>
		/// <returns>true if the HTML attribute is found, otherwise, false. If false, the position of the navigator does not change.</returns>
		public override bool MoveToAttribute(string localName, string namespaceURI)
		{
#if TRACE_NAVIGATOR
            InternalTrace("localName=" + localName + ", namespaceURI=" + namespaceURI);
#endif
			int index = _currentnode.Attributes.GetAttributeIndex(localName);
			if (index == -1)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			_attindex = index;
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves to the first sibling of the current node.
		/// </summary>
		/// <returns>true if the navigator is successful moving to the first sibling node, false if there is no first sibling or if the navigator is currently positioned on an attribute node.</returns>
		public override bool MoveToFirst()
		{
			if (_currentnode.ParentNode == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			if (_currentnode.ParentNode.FirstChild == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			_currentnode = _currentnode.ParentNode.FirstChild;
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves to the first HTML attribute.
		/// </summary>
		/// <returns>true if the navigator is successful moving to the first HTML attribute, otherwise, false.</returns>
		public override bool MoveToFirstAttribute()
		{
			if (!HasAttributes)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			_attindex = 0;
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves to the first child of the current node.
		/// </summary>
		/// <returns>true if there is a first child node, otherwise false.</returns>
		public override bool MoveToFirstChild()
		{
			if (!_currentnode.HasChildNodes)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			_currentnode = _currentnode.ChildNodes[0];
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves the XPathNavigator to the first namespace node of the current element.
		/// Always returns false for the HtmlNavigator implementation.
		/// </summary>
		/// <param name="scope">An XPathNamespaceScope value describing the namespace scope.</param>
		/// <returns>Always returns false for the HtmlNavigator implementation.</returns>
		public override bool MoveToFirstNamespace(XPathNamespaceScope scope)
		{
#if TRACE_NAVIGATOR
            InternalTrace(null);
#endif
			return false;
		}

		/// <summary>
		/// Moves to the node that has an attribute of type ID whose value matches the specified string.
		/// </summary>
		/// <param name="id">A string representing the ID value of the node to which you want to move. This argument does not need to be atomized.</param>
		/// <returns>true if the move was successful, otherwise false. If false, the position of the navigator is unchanged.</returns>
		public override bool MoveToId(string id)
		{
#if TRACE_NAVIGATOR
            InternalTrace("id=" + id);
#endif
			HtmlNode node = _doc.GetElementbyId(id);
			if (node == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			_currentnode = node;
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves the XPathNavigator to the namespace node with the specified local name. 
		/// Always returns false for the HtmlNavigator implementation.
		/// </summary>
		/// <param name="name">The local name of the namespace node.</param>
		/// <returns>Always returns false for the HtmlNavigator implementation.</returns>
		public override bool MoveToNamespace(string name)
		{
#if TRACE_NAVIGATOR
            InternalTrace("name=" + name);
#endif
			return false;
		}

		/// <summary>
		/// Moves to the next sibling of the current node.
		/// </summary>
		/// <returns>true if the navigator is successful moving to the next sibling node, false if there are no more siblings or if the navigator is currently positioned on an attribute node. If false, the position of the navigator is unchanged.</returns>
		public override bool MoveToNext()
		{
			if (_currentnode.NextSibling == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

#if TRACE_NAVIGATOR
            InternalTrace("_c=" + _currentnode.CloneNode(false).OuterHtml);
            InternalTrace("_n=" + _currentnode.NextSibling.CloneNode(false).OuterHtml);
#endif
			_currentnode = _currentnode.NextSibling;
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves to the next HTML attribute.
		/// </summary>
		/// <returns></returns>
		public override bool MoveToNextAttribute()
		{
#if TRACE_NAVIGATOR
            InternalTrace(null);
#endif
			if (_attindex >= (_currentnode.Attributes.Count - 1))
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			_attindex++;
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves the XPathNavigator to the next namespace node.
		/// Always returns falsefor the HtmlNavigator implementation.
		/// </summary>
		/// <param name="scope">An XPathNamespaceScope value describing the namespace scope.</param>
		/// <returns>Always returns false for the HtmlNavigator implementation.</returns>
		public override bool MoveToNextNamespace(XPathNamespaceScope scope)
		{
#if TRACE_NAVIGATOR
            InternalTrace(null);
#endif
			return false;
		}

		/// <summary>
		/// Moves to the parent of the current node.
		/// </summary>
		/// <returns>true if there is a parent node, otherwise false.</returns>
		public override bool MoveToParent()
		{
			if (_currentnode.ParentNode == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			_currentnode = _currentnode.ParentNode;
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves to the previous sibling of the current node.
		/// </summary>
		/// <returns>true if the navigator is successful moving to the previous sibling node, false if there is no previous sibling or if the navigator is currently positioned on an attribute node.</returns>
		public override bool MoveToPrevious()
		{
			if (_currentnode.PreviousSibling == null)
			{
#if TRACE_NAVIGATOR
                InternalTrace(">false");
#endif
				return false;
			}

			_currentnode = _currentnode.PreviousSibling;
#if TRACE_NAVIGATOR
            InternalTrace(">true");
#endif
			return true;
		}

		/// <summary>
		/// Moves to the root node to which the current node belongs.
		/// </summary>
		public override void MoveToRoot()
		{
			_currentnode = _doc.DocumentNode;
#if TRACE_NAVIGATOR
            InternalTrace(null);
#endif
		}

		#endregion

		#region Internal Methods
#if TRACE_NAVIGATOR
        [Conditional("TRACE")]
        internal void InternalTrace(object traceValue)
        {
            if (!Trace)
            {
                return;
            }

#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            StackFrame sf = new StackFrame(1);
            string name = sf.GetMethod().Name;
#else
            string name = "";
#endif
            string nodename = _currentnode == null ? "(null)" : _currentnode.Name;
            string nodevalue;
            if (_currentnode == null)
            {
                nodevalue = "(null)";
            }
            else
            {
                switch (_currentnode.NodeType)
                {
                    case HtmlNodeType.Comment:
                        nodevalue = ((HtmlCommentNode) _currentnode).Comment;
                        break;

                    case HtmlNodeType.Document:
                        nodevalue = "";
                        break;

                    case HtmlNodeType.Text:
                        nodevalue = ((HtmlTextNode) _currentnode).Text;
                        break;

                    default:
                        nodevalue = _currentnode.CloneNode(false).OuterHtml;
                        break;
                }
            }

            HtmlAgilityPack.Trace.WriteLine(string.Format("oid={0},n={1},a={2},v={3},{4}", GetHashCode(), nodename, _attindex, nodevalue, traceValue), "N!" + name);
        }
#endif
		#endregion

		#region Private Methods

		private void Reset()
		{
#if TRACE_NAVIGATOR
            InternalTrace(null);
#endif
			_currentnode = _doc.DocumentNode;
			_attindex = -1;
		}

		#endregion
	}
}
#endif