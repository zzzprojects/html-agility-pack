// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

using System;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents an exception thrown by the HtmlWeb utility class.
    /// </summary>
    public class HtmlWebException : Exception
    {
        #region Constructors

        /// <summary>
        /// Creates an instance of the HtmlWebException.
        /// </summary>
        /// <param name="message">The exception's message.</param>
        public HtmlWebException(string message)
            : base(message)
        {
        }

        #endregion
    }
}