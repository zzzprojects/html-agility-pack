using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HtmlAgilityPack
{
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Enum |
        AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class DebuggerDisplayAttribute : Attribute
    {
        #region C'tors

        public DebuggerDisplayAttribute(string value)
        {
            Value = value;
        }

        #endregion

        #region Instance Properties

        public string Name { get; set; }
        public Type Target { get; set; }
        public string TargetTypeName { get; set; }
        public string Type { get; set; }
        public string Value { get; private set; }

        #endregion
    }
}
