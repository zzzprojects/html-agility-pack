// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HtmlAgilityPack
{
    internal static class Utilities
    {
#if NET8_0_OR_GREATER
        public static TValue? GetDictionaryValueOrDefault<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, TValue? defaultValue = default(TValue)) where TKey : class
#else
        public static TValue GetDictionaryValueOrDefault<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue)) where TKey : class
#endif
        {
#if NET8_0_OR_GREATER
            TValue? value;
#else
            TValue value;
#endif

            if (!dict.TryGetValue(key, out value))
                return defaultValue;
            return value;
        }

#if !(METRO || NETSTANDARD1_3 || NETSTANDARD1_6)
#if NET8_0_OR_GREATER
        internal static object? To(this Object? @this, Type type)
#else
        internal static object To(this Object @this, Type type)
#endif
        {
            if (@this != null)
            {
                Type targetType = type;

                if (@this.GetType() == targetType)
                {
                    return @this;
                }

                TypeConverter converter = TypeDescriptor.GetConverter(@this);
                if (converter != null)
                {
                    if (converter.CanConvertTo(targetType))
                    {
                        return converter.ConvertTo(@this, targetType);
                    }
                }

                converter = TypeDescriptor.GetConverter(targetType);
                if (converter != null)
                {
                    if (converter.CanConvertFrom(@this.GetType()))
                    {
                        return converter.ConvertFrom(@this);
                    }
                }

                if (@this == DBNull.Value)
                {
                    return null;
                }
            }

            return @this;
        }
#endif
    }
}