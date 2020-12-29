using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FormulaChecker.Helpers
{
    public static class EnumValueAttributeHelper
    {
        public static string GetValue(this Enum enumValue)
        {
            Type type = enumValue.GetType();

            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());

            // no attributes found ?
            if (memInfo.Length == 0) return string.Empty;

            // cast to Array or List required 
            // an IEnumerable of DescriptionAttribute cannot be indexed !
            DescriptionAttribute[] attributes = memInfo[0].GetCustomAttributes<DescriptionAttribute>(false).ToArray();

            // handle value without description
            return (attributes.Length == 0) ? string.Empty : attributes[0].Description;
        }
    }
}
