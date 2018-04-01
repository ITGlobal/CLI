using System;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;

#if NETSTANDARD1_6
using System.Reflection;
#endif

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
        public static IValueParser<bool> Bool { get; } =
            new BooleanValueParserImpl();


        /// <summary>
        ///     Value parser for byte values
        /// </summary>
        [NotNull]
        public static IValueParser<byte> Byte { get; } =
            new ValueParserImpl<byte>(byte.Parse);

        /// <summary>
        ///     Value parser for signed byte values
        /// </summary>
        [NotNull]
        public static IValueParser<sbyte> SByte { get; } =
            new ValueParserImpl<sbyte>(sbyte.Parse);


        /// <summary>
        ///     Value parser for int16values
        /// </summary>
        [NotNull]
        public static IValueParser<short> Short { get; } =
            new ValueParserImpl<short>(short.Parse);

        /// <summary>
        ///     Value parser for unsigned int16 values
        /// </summary>
        [NotNull]
        public static IValueParser<ushort> Ushort { get; } =
            new ValueParserImpl<ushort>(ushort.Parse);


        /// <summary>
        ///     Value parser for int32 values
        /// </summary>
        [NotNull]
        public static IValueParser<int> Int { get; } =
            new ValueParserImpl<int>(int.Parse);

        /// <summary>
        ///     Value parser for unsigned int32 values
        /// </summary>
        [NotNull]
        public static IValueParser<uint> UInt { get; } =
            new ValueParserImpl<uint>(uint.Parse);


        /// <summary>
        ///     Value parser for int64 values
        /// </summary>
        [NotNull]
        public static IValueParser<long> Long { get; } =
            new ValueParserImpl<long>(long.Parse);

        /// <summary>
        ///     Value parser for unsigned int64 values
        /// </summary>
        [NotNull]
        public static IValueParser<ulong> Ulong { get; } =
            new ValueParserImpl<ulong>(ulong.Parse);

        /// <summary>
        ///     Value parser for float values
        /// </summary>
        [NotNull]
        public static IValueParser<float> Float { get; } =
            new ValueParserImpl<float>(float.Parse);

        /// <summary>
        ///     Value parser for double values
        /// </summary>
        [NotNull]
        public static IValueParser<double> Double { get; } =
            new ValueParserImpl<double>(double.Parse);

        /// <summary>
        ///     Value parser for decimal values
        /// </summary>
        [NotNull]
        public static IValueParser<decimal> Decimal { get; } =
            new ValueParserImpl<decimal>(decimal.Parse);

        /// <summary>
        ///     Value parser for char values
        /// </summary>
        [NotNull]
        public static IValueParser<char> Char { get; } =
            new ValueParserImpl<char>(ParseChar);

        /// <summary>
        ///     Value parser for string values
        /// </summary>
        [NotNull]
        public static IValueParser<string> String { get; } =
            new ValueParserImpl<string>(_ => _, _ => _);

        /// <summary>
        ///     Value parser for DateTime values
        /// </summary>
        [NotNull]
        public static IValueParser<DateTime> DateTime { get; } =
            new ValueParserImpl<DateTime>(ParseDateTime, FormatDateTime);

        /// <summary>
        ///     Get a built-in value parser for specified type
        /// </summary>
        [CanBeNull]
        public static IValueParser<T> Get<T>()
        {
#if NETSTANDARD1_6
            if (typeof(T).GetTypeInfo().IsEnum)
#else
            if (typeof(T).IsEnum)
#endif
            {
                return new EnumValueParser<T>();
            }

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Boolean:
                    return (IValueParser<T>)Bool;

                case TypeCode.Byte:
                    return (IValueParser<T>)Byte;
                case TypeCode.SByte:
                    return (IValueParser<T>)SByte;

                case TypeCode.Int16:
                    return (IValueParser<T>)Short;
                case TypeCode.UInt16:
                    return (IValueParser<T>)Ushort;

                case TypeCode.Int32:
                    return (IValueParser<T>)Int;
                case TypeCode.UInt32:
                    return (IValueParser<T>)UInt;

                case TypeCode.Int64:
                    return (IValueParser<T>)Long;
                case TypeCode.UInt64:
                    return (IValueParser<T>)Ulong;


                case TypeCode.Single:
                    return (IValueParser<T>)Float;
                case TypeCode.Double:
                    return (IValueParser<T>)Double;

                case TypeCode.Decimal:
                    return (IValueParser<T>)Decimal;

                case TypeCode.Char:
                    return (IValueParser<T>)Char;
                case TypeCode.String:
                    return (IValueParser<T>)String;

                case TypeCode.DateTime:
                    return (IValueParser<T>)DateTime;

                default:
                    return null;
            }
        }

        private static char ParseChar(string str)
        {
            if (str.Length == 0)
            {
                throw new FormatException("Value is empty");
            }

            if (str.Length > 1)
            {
                throw new FormatException("Value is too long");
            }

            return str[0];
        }

        private static DateTime ParseDateTime(string str)
        {
            return System.DateTime.Parse(str);
        }

        private static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("s");
        }

        private sealed class BooleanValueParserImpl : IValueParser<bool>
        {
            public string Format(bool value) => value ? "true" : "false";

            public ValueParserResult<bool> Parse(string str)
            {
                switch (str.ToLowerInvariant())
                {
                    case "t":
                    case "true":
                    case "y":
                    case "yes":
                    case "1":
                        return ValueParserResult.Success(true);

                    case "f":
                    case "false":
                    case "n":
                    case "no":
                    case "0":
                        return ValueParserResult.Success(false);

                    default:
                        return ValueParserResult.Error<bool>($"\"{str}\" is not a valid boolean value");
                }
            }
        }

        private sealed class ValueParserImpl<T> : IValueParser<T>
        {
            private readonly Func<string, T> _parse;
            private readonly Func<T, string> _format;

            public ValueParserImpl(Func<string, T> parse, Func<T, string> format = null)
            {
                format = format ?? DefaultFormat;

                _parse = parse;
                _format = format;
            }

            public string Format(T value) => _format(value);

            public ValueParserResult<T> Parse(string str)
            {
                try
                {
                    var value = _parse(str);
                    return ValueParserResult.Success(value);
                }
                catch (Exception e)
                {
                    return ValueParserResult.Error<T>(e.Message);
                }
            }

            private static string DefaultFormat(T value)
            {
                return (value as IFormattable)
                       ?.ToString(null, CultureInfo.InvariantCulture)
                       ?? value?.ToString()
                       ?? "";
            }
        }

        private sealed class EnumValueParser<T> : IValueParser<T>
        {
            public ValueParserResult<T> Parse(string str)
            {
                try
                {
                    return ValueParserResult.Success(
                        (T)Enum.Parse(typeof(T), str, true)
                    );
                }
                catch
                {
                    var validValues = Enum.GetNames(typeof(T)).Select(_ => _.ToLowerInvariant());
                    return ValueParserResult.Error<T>(
                        $"Invalid value. Valid values are: {string.Join(", ", validValues)}"
                    );
                }
            }

            public string Format(T value)
            {
                return Enum.GetName(typeof(T), value).ToLowerInvariant();
            }
        }
    }
}