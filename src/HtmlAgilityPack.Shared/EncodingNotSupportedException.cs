// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.

using System;
using System.Text;

namespace HtmlAgilityPack
{
    public class EncodingNotSupportedException : Exception
    {
        #region Fields

        private string _encoding;

        #endregion

        #region Constructors

        internal EncodingNotSupportedException(string encoding)
        {
            _encoding = encoding;
        }

        #endregion

        #region Properties

        public string Encoding
        {
            get { return _encoding; }
        }

        #endregion
    }
}