// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

using System;
using System.Text;

namespace HtmlAgilityPack
{
    internal class EncodingFoundException : Exception
    {
        #region Fields

#if NET8_0_OR_GREATER
        private Encoding? _encoding;
#else
        private Encoding _encoding;
#endif



        #endregion

        #region Constructors

#if NET8_0_OR_GREATER
        internal EncodingFoundException(Encoding? encoding)
#else
        internal EncodingFoundException(Encoding encoding)
#endif
        {
            _encoding = encoding;
        }

        #endregion

        #region Properties

#if NET8_0_OR_GREATER
        internal Encoding? Encoding
#else
        internal Encoding Encoding
#endif
        {
            get { return _encoding; }
        }

        #endregion
    }
}