// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

#if !METRO
using System.IO;

namespace HtmlAgilityPack
{
    internal struct IOLibrary
    {
        #region Internal Methods

#if NET8_0_OR_GREATER
        internal static void CopyAlways(string? source, string target)
#else
        internal static void CopyAlways(string source, string target)
#endif
        {
            if (!File.Exists(source))
                return;
            Directory.CreateDirectory(Path.GetDirectoryName(target));
            MakeWritable(target);
            File.Copy(source, target, true);
        }
#if !PocketPC && !WINDOWS_PHONE
        internal static void MakeWritable(string path)
        {
            if (!File.Exists(path))
                return;
            File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.ReadOnly);
        }
#else
        internal static void MakeWritable(string path)
        {
        }
#endif
#endregion
    }
}

#endif