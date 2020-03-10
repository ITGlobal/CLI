using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using ITGlobal.CommandLine.Parsing.Impl.ValueParsers;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Built-in value parsers
    /// </summary>
    [PublicAPI]
    public static class ValueParser
    {
        /// <summary>
        ///     Value parser for boolean values
        /// </summary>
        [NotNull]
        public static IValueParser<bool> Bool { get; } = new BooleanValueParserImpl();

        /// <summary>
        ///     Value parser for byte values
        /// </summary>
        [NotNull]
        public static IValueParser<byte> Byte { get; } = new PrimitiveValueParserImpl<byte>(byte.Parse);

        /// <summary>
        ///     Value parser for signed byte values
        /// </summary>
        [NotNull]
        public static IValueParser<sbyte> SByte { get; } = new PrimitiveValueParserImpl<sbyte>(sbyte.Parse);

        /// <summary>
        ///     Value parser for int16values
        /// </summary>
        [NotNull]
        public static IValueParser<short> Short { get; } = new PrimitiveValueParserImpl<short>(short.Parse);

        /// <summary>
        ///     Value parser for unsigned int16 values
        /// </summary>
        [NotNull]
        public static IValueParser<ushort> Ushort { get; } = new PrimitiveValueParserImpl<ushort>(ushort.Parse);

        /// <summary>
        ///     Value parser for int32 values
        /// </summary>
        [NotNull]
        public static IValueParser<int> Int { get; } = new PrimitiveValueParserImpl<int>(int.Parse);

        /// <summary>
        ///     Value parser for unsigned int32 values
        /// </summary>
        [NotNull]
        public static IValueParser<uint> UInt { get; } = new PrimitiveValueParserImpl<uint>(uint.Parse);

        /// <summary>
        ///     Value parser for int64 values
        /// </summary>
        [NotNull]
        public static IValueParser<long> Long { get; } = new PrimitiveValueParserImpl<long>(long.Parse);

        /// <summary>
        ///     Value parser for unsigned int64 values
        /// </summary>
        [NotNull]
        public static IValueParser<ulong> Ulong { get; } = new PrimitiveValueParserImpl<ulong>(ulong.Parse);

        /// <summary>
        ///     Value parser for float values
        /// </summary>
        [NotNull]
        public static IValueParser<float> Float { get; } = new PrimitiveValueParserImpl<float>(float.Parse);

        /// <summary>
        ///     Value parser for double values
        /// </summary>
        [NotNull]
        public static IValueParser<double> Double { get; } = new PrimitiveValueParserImpl<double>(double.Parse);

        /// <summary>
        ///     Value parser for decimal values
        /// </summary>
        [NotNull]
        public static IValueParser<decimal> Decimal { get; } = new PrimitiveValueParserImpl<decimal>(decimal.Parse);

        /// <summary>
        ///     Value parser for char values
        /// </summary>
        [NotNull]
        public static IValueParser<char> Char { get; } = new CharValueParserImpl();

        /// <summary>
        ///     Value parser for string values
        /// </summary>
        [NotNull]
        public static IValueParser<string> String { get; } = new StringValueParserImpl();

        /// <summary>
        ///     Value parser for <see cref="FileInfo"/> values
        /// </summary>
        [NotNull]
        public static IValueParser<FileInfo> FileInfo { get; } = new FileInfoValueParserImpl();

        /// <summary>
        ///     Value parser for <see cref="DirectoryInfo"/> values
        /// </summary>
        [NotNull]
        public static IValueParser<DirectoryInfo> DirectoryInfo { get; } = new DirectoryInfoValueParserImpl();

        /// <summary>
        ///     Value parser for DateTime values
        /// </summary>
        [NotNull]
        public static IValueParser<DateTime> DateTime { get; }
            = new PrimitiveValueParserImpl<DateTime>(
                str => System.DateTime.Parse(str, CultureInfo.InvariantCulture),
                datetime => datetime.ToString("s", CultureInfo.InvariantCulture)
            );

        /// <summary>
        ///     Get a built-in value parser for specified type
        /// </summary>
        [CanBeNull]
        public static IValueParser<T> Get<T>() => (IValueParser<T>)Get(typeof(T));

        /// <summary>
        ///     Get a built-in value parser for enumtype
        /// </summary>
        [NotNull]
        public static IValueParser<T> Enum<T>()
            where T : struct, Enum
            => EnumValueParser<T>.Instance;

        /// <summary>
        ///     Get a built-in value parser for enumtype
        /// </summary>
        [CanBeNull]
        public static IValueParser<T[]> Array<T>()
        {
            var parser = Get<T>();
            if (parser == null)
            {
                return null;
            }

            return new ArrayValueParserImpl<T>(parser);
        }

        private static object Get(Type type)
        {
            if (type == typeof(FileInfo))
            {
                return FileInfo;
            }

            if (type == typeof(DirectoryInfo))
            {
                return DirectoryInfo;
            }

            if (type.IsEnum)
            {
                var method = typeof(ValueParser)
                    .GetMethod(nameof(Enum), BindingFlags.Static | BindingFlags.Public);
                if (method == null)
                {
                    return null;
                }

                method = method.MakeGenericMethod(type);
                var result = method.Invoke(null, new object[0]);
                return result;
            }

            if (type.IsArray)
            {
                var itemType = type.GetElementType();
                return typeof(ValueParser)
                    .GetMethod(nameof(Array), BindingFlags.Static | BindingFlags.Public)
                    ?.MakeGenericMethod(itemType)
                    .Invoke(null, new object[0]);
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return Bool;

                case TypeCode.Byte:
                    return Byte;
                case TypeCode.SByte:
                    return SByte;

                case TypeCode.Int16:
                    return Short;
                case TypeCode.UInt16:
                    return Ushort;

                case TypeCode.Int32:
                    return Int;
                case TypeCode.UInt32:
                    return UInt;

                case TypeCode.Int64:
                    return Long;
                case TypeCode.UInt64:
                    return Ulong;

                case TypeCode.Single:
                    return Float;
                case TypeCode.Double:
                    return Double;

                case TypeCode.Decimal:
                    return Decimal;

                case TypeCode.Char:
                    return Char;
                case TypeCode.String:
                    return String;

                case TypeCode.DateTime:
                    return DateTime;

                default:
                    return null;
            }
        }
    }
}