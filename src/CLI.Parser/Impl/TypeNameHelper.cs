using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal static class TypeNameHelper
    {
        public static string GetTypeName(Type type)
        {
            switch (Type.GetTypeCode(type))
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
                    return type.Name;
            }
        }
    }
}