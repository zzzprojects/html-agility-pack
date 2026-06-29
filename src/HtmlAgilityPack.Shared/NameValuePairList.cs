// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

using System;
using System.Collections.Generic;

namespace HtmlAgilityPack
{
    internal class NameValuePairList
    {
        #region Fields

#if NET8_0_OR_GREATER
        internal readonly string? Text;
#else
        internal readonly string Text;
#endif

        private List<KeyValuePair<string, string>> _allPairs;
        private Dictionary<string, List<KeyValuePair<string, string>>> _pairsWithName;

        #endregion

        #region Constructors

        internal NameValuePairList() :
            this(null)
        {
        }
#if NET8_0_OR_GREATER
        internal NameValuePairList(string? text)
#else
        internal NameValuePairList(string text)
#endif        
        {
            Text = text;
            _allPairs = new List<KeyValuePair<string, string>>();
            _pairsWithName = new Dictionary<string, List<KeyValuePair<string, string>>>();

            Parse(text);
        }

        #endregion

        #region Internal Methods

#if NET8_0_OR_GREATER
        internal static string GetNameValuePairsValue(string? text, string name)
#else
        internal static string GetNameValuePairsValue(string text, string name)
#endif
        {
            NameValuePairList l = new NameValuePairList(text);
            return l.GetNameValuePairValue(name);
        }

#if NET8_0_OR_GREATER
        internal List<KeyValuePair<string, string>> GetNameValuePairs(string? name)
#else
        internal List<KeyValuePair<string, string>> GetNameValuePairs(string name)
#endif
        {
            if (name == null)
                return _allPairs;

            return _pairsWithName.TryGetValue(name, out List<KeyValuePair<string, string>> value) 
                ? value 
                : new List<KeyValuePair<string, string>>();
        }

        internal string GetNameValuePairValue(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            List<KeyValuePair<string, string>> al = GetNameValuePairs(name);
            if (al.Count == 0)
                return string.Empty;

            // return first item
            return al[0].Value.Trim();
        }

        #endregion

        #region Private Methods
#if NET8_0_OR_GREATER
        private void Parse(string? text)
#else
        private void Parse(string text)
#endif        
        {
            _allPairs.Clear();
            _pairsWithName.Clear();
            if (text == null)
                return;

            string[] p = text.Split(';');
            foreach (string pv in p)
            {
                if (pv.Length == 0)
                    continue;
                string[] onep = pv.Split(new[] {'='}, 2);
                if (onep.Length == 0)
                    continue;
                KeyValuePair<string, string> nvp = new KeyValuePair<string, string>(onep[0].Trim().ToLowerInvariant(),
                    onep.Length < 2 ? "" : onep[1]);

                _allPairs.Add(nvp);

                // index by name
#if NET8_0_OR_GREATER
                List<KeyValuePair<string, string>>? al;
#else
                List<KeyValuePair<string, string>> al;
#endif
                if (!_pairsWithName.TryGetValue(nvp.Key, out al))
                {
                    al = new List<KeyValuePair<string, string>>();
                    _pairsWithName.Add(nvp.Key, al);
                }

                al.Add(nvp);
            }
        }

        #endregion
    }
}