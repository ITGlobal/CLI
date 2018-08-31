using System;

#if NETSTANDARD1_6
using System.Reflection;
#endif

namespace ITGlobal.CommandLine.Parsing
{
    internal static class TypeNameHelper
    {
        public static string GetTypeName<T>()
        {
#if NETSTANDARD1_6
            if (typeof(T).GetTypeInfo().IsEnum)
#else
            if (typeof(T).IsEnum)
#endif
            {
                var parser = (ValueParser.EnumValueParser<T>)ValueParser.Get<T>();
                return string.Join(", ", parser.KnownValues);
            }

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Boolean:
                    return "boolean";

                case TypeCode.Byte:
                case TypeCode.SByte:

                case TypeCode.Int16:
                case TypeCode.UInt16:

                case TypeCode.Int32:
                case TypeCode.UInt32:

                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return "int";


                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return "float";

                case TypeCode.Char:
                    return "char";

                case TypeCode.String:
                    return "string";

                case TypeCode.DateTime:
                    return "datetime";

                default:
                    return typeof(T).Name;
            }
        }
    }
}