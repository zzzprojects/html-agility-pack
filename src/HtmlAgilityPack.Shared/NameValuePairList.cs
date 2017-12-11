// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright � ZZZ Projects Inc. 2014 - 2017. All rights reserved.

using System;
using System.Collections.Generic;

namespace HtmlAgilityPack
{
    internal class NameValuePairList
    {
        #region Fields

        internal readonly string Text;
        private List<KeyValuePair<string, string>> _allPairs;
        private Dictionary<string,List<KeyValuePair<string,string>>> _pairsWithName;

        #endregion

        #region Constructors

        internal NameValuePairList() :
            this(null)
        {
        }

        internal NameValuePairList(string text)
        {
            Text = text;
            _allPairs = new List<KeyValuePair<string, string>>();
            _pairsWithName = new Dictionary<string, List<KeyValuePair<string, string>>>();

            Parse(text);
        }

        #endregion

        #region Internal Methods

        internal static string GetNameValuePairsValue(string text, string name)
        {
            NameValuePairList l = new NameValuePairList(text);
            return l.GetNameValuePairValue(name);
        }

        internal List<KeyValuePair<string,string>> GetNameValuePairs(string name)
        {
            if (name == null)
                return _allPairs;
            return Utilities.GetDictionaryValueOrDefault(_pairsWithName, name, new List<KeyValuePair<string,string>>());
        }

        internal string GetNameValuePairValue(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            List<KeyValuePair<string,string>> al = GetNameValuePairs(name);
            if (al.Count==0)
                return string.Empty;

            // return first item
             return al[0].Value.Trim();
        }

        #endregion

        #region Private Methods

        private void Parse(string text)
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
                if (onep.Length==0)
                    continue;
                KeyValuePair<string, string> nvp = new KeyValuePair<string, string>(onep[0].Trim().ToLower(),
                                                                                    onep.Length < 2 ? "" : onep[1]);

                _allPairs.Add(nvp);

                // index by name
                List<KeyValuePair<string, string>> al;
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