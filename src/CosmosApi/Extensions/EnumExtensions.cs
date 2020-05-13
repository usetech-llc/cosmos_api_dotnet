using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;

namespace CosmosApi.Extensions
{
    public static class EnumExtensions
    {
        public static string EnumMember<TEnum>(this TEnum value) where TEnum : Enum
        {
            var enumType = typeof (TEnum);
            var name = Enum.GetName(enumType, value);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name!)!.GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }
    }
}