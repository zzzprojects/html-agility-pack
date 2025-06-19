﻿// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

#region

using System;
using System.Diagnostics;

#endregion

// ReSharper disable InconsistentNaming

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents an HTML attribute.
    /// </summary>
    [DebuggerDisplay("Name: {OriginalName}, Value: {Value}")]
    public class HtmlAttribute : IComparable
    {
        #region Fields

        private int _line;
        internal int _lineposition;
        internal string? _name;
        internal int _namelength;
        internal int _namestartindex;
        internal HtmlDocument _ownerdocument; // attribute can exists without a node
        internal HtmlNode? _ownernode;
        private AttributeValueQuote? _quoteType;
        internal int _streamposition;
        internal string? _value;
        internal int _valuelength;
        internal int _valuestartindex; 
        private bool? _localUseOriginalName;

        #endregion

        #region Constructors

        internal HtmlAttribute(HtmlDocument ownerdocument)
        {
            _ownerdocument = ownerdocument;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the line number of this attribute in the document.
        /// </summary>
        public int Line
        {
            get { return _line; }
            internal set { _line = value; }
        }

        /// <summary>
        /// Gets the column number of this attribute in the document.
        /// </summary>
        public int LinePosition
        {
            get { return _lineposition; }
        }

        /// <summary>
        /// Gets the stream position of the value of this attribute in the document, relative to the start of the document.
        /// </summary>
        public int ValueStartIndex
        {
            get { return _valuestartindex; }
        }

        /// <summary>
        /// Gets the length of the value.
        /// </summary>
        public int ValueLength
        {
            get { return _valuelength; }
        }

        /// <summary>Gets or sets a value indicating whether the attribute should use the original name.</summary>
        /// <value>True if the attribute should use the original name, false if not.</value>
        public bool UseOriginalName
        {
            get
            {
                var useOriginalName = false;
                if (this._localUseOriginalName.HasValue)
				{
                    useOriginalName = this._localUseOriginalName.Value;
                }
                else if (this.OwnerDocument != null)
				{
                    useOriginalName = this.OwnerDocument.OptionDefaultUseOriginalName;
                }

                return useOriginalName;
            }
            set
            {
                this._localUseOriginalName = value;
            }
        }

        /// <summary>
        /// Gets the qualified name of the attribute.
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = _ownerdocument.Text.Substring(_namestartindex, _namelength);
                }

	            return UseOriginalName ? _name : _name.ToLowerInvariant();
			}
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                _name = value;
                if (_ownernode != null)
                {
                    _ownernode.SetChanged();
                }
            }
        }

        /// <summary>
        /// Name of attribute with original case
        /// </summary>
        public string? OriginalName
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the HTML document to which this attribute belongs.
        /// </summary>
        public HtmlDocument OwnerDocument
        {
            get { return _ownerdocument; }
        }

        /// <summary>
        /// Gets the HTML node to which this attribute belongs.
        /// </summary>
        public HtmlNode? OwnerNode
        {
            get { return _ownernode; }
        }

        /// <summary>
        /// Specifies what type of quote the data should be wrapped in
        /// </summary>
        public AttributeValueQuote QuoteType
        {
            get { return _quoteType ?? this.InternalQuoteType ?? this.OwnerDocument.GlobalAttributeValueQuote ?? AttributeValueQuote.DoubleQuote; }
            set { _quoteType = value != AttributeValueQuote.Initial ? (AttributeValueQuote?)value : null; }
        }

        /// <summary>
        /// Specifies what type of quote the data should be wrapped in (internal to keep backward compatibility)
        /// </summary>
        internal AttributeValueQuote? InternalQuoteType { get; set; }

        /// <summary>
        /// Gets the stream position of this attribute in the document, relative to the start of the document.
        /// </summary>
        public int StreamPosition
        {
            get { return _streamposition; }
        }

        /// <summary>
        /// Gets or sets the value of the attribute.
        /// </summary>
        public string? Value
        {
            get
            {
                // A null value has been provided, the attribute should be considered as "hidden"
                if (_value == null && _ownerdocument.Text == null && _valuestartindex == 0 && _valuelength == 0)
                {
                    return null;
                }

                if (_value == null)
                {
                    _value = _ownerdocument.Text.Substring(_valuestartindex, _valuelength);

                    if (!_ownerdocument.BackwardCompatibility)
                    {
                        _value = HtmlEntity.DeEntitize(_value);
                    }
                }

                return _value;
            }
            set
            {
                _value = value;
                if (!string.IsNullOrEmpty(_value) && (this.QuoteType == AttributeValueQuote.WithoutValue || this.QuoteType == AttributeValueQuote.None))
                {
                    this.InternalQuoteType = this.OwnerDocument.GlobalAttributeValueQuote != AttributeValueQuote.Initial ?
                        (this.OwnerDocument.GlobalAttributeValueQuote ?? AttributeValueQuote.DoubleQuote)
                        : AttributeValueQuote.DoubleQuote;
                }

                if (_ownernode != null)
                {
                    _ownernode.SetChanged();
                }
            }
        }

        /// <summary>
        /// Gets the DeEntitized value of the attribute.
        /// </summary>
        public string? DeEntitizeValue
        {
            get { return HtmlEntity.DeEntitize(Value); }
        }

        internal string XmlName
        {
            get { return HtmlDocument.GetXmlName(Name, true, OwnerDocument.OptionPreserveXmlNamespaces); }
        }

        internal string? XmlValue
        {
            get { return Value; }
        }

        /// <summary>
        /// Gets a valid XPath string that points to this Attribute
        /// </summary>
        public string XPath
        {
            get
            {
                string basePath = (OwnerNode == null) ? "/" : OwnerNode.XPath + "/";
                return basePath + GetRelativeXpath();
            }
        }

        #endregion

        #region IComparable Members

        /// <summary>
        /// Compares the current instance with another attribute. Comparison is based on attributes' name.
        /// </summary>
        /// <param name="obj">An attribute to compare with this instance.</param>
        /// <returns>A 32-bit signed integer that indicates the relative order of the names comparison.</returns>
        public int CompareTo(object? obj)
        {
            HtmlAttribute? att = obj as HtmlAttribute;
            if (att == null)
            {
                throw new ArgumentException("obj");
            }

            return Name.CompareTo(att.Name);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a duplicate of this attribute.
        /// </summary>
        /// <returns>The cloned attribute.</returns>
        public HtmlAttribute Clone()
        {
            HtmlAttribute att = new HtmlAttribute(_ownerdocument);
            att.Name = OriginalName;
            att.Value = Value;
            att._quoteType = _quoteType;
            att.InternalQuoteType = InternalQuoteType;

            return att;
        }

        /// <summary>
        /// Removes this attribute from it's parents collection
        /// </summary>
        public void Remove()
        {
            _ownernode.Attributes.Remove(this);
        }

        #endregion

        #region Private Methods

        private string GetRelativeXpath()
        {
            if (OwnerNode == null)
                return Name;

            int i = 1;
            foreach (HtmlAttribute node in OwnerNode.Attributes)
            {
                if (node.Name != Name) continue;

                if (node == this)
                    break;

                i++;
            }

            return "@" + Name + "[" + i + "]";
        }

        #endregion
    }

    /// <summary>
    /// An Enum representing different types of Quotes used for surrounding attribute values
    /// </summary>
    public enum AttributeValueQuote
    {
        /// <summary>
        /// A single quote mark '
        /// </summary>
        SingleQuote,

        /// <summary>
        /// A double quote mark "
        /// </summary>
        DoubleQuote,

        /// <summary>
        /// No quote mark
        /// </summary>
        None,


        /// <summary>Without the value such as '&lt;span readonly&gt;'</summary>
        WithoutValue,

        /// <summary>
        /// The initial value (current value)
        /// </summary>
        Initial,

        /// <summary>
        /// The initial value (current value). However tag without value will have a double quote by default
        /// </summary>
        InitialExceptWithoutValue
    }
}