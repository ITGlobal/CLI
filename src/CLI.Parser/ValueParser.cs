using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
            new StringValueParserImpl();

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
        public static IValueParser<T> Get<T>() => (IValueParser<T>)Get(typeof(T));

        /// <summary>
        ///     Get a built-in value parser for enumtype
        /// </summary>
        private static IValueParser<T> GetEnumParser<T>()
        {
            return new EnumValueParser<T>();
        }

        /// <summary>
        ///     Get a built-in value parser for enumtype
        /// </summary>
        private static IValueParser<T[]> GetArrayParser<T>()
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
#if NETSTANDARD1_6
            if (type.GetTypeInfo().IsEnum)
#else
            if (type.IsEnum)
#endif
            {
                return typeof(ValueParser)
#if NETSTANDARD1_6
                    .GetTypeInfo()
#endif
                    .GetMethod(nameof(GetEnumParser), BindingFlags.Static | BindingFlags.NonPublic)
                    ?.MakeGenericMethod(type)
                    .Invoke(null, new object[0]);
            }

#if NETSTANDARD1_6
            if (type.GetTypeInfo().IsEnum)
#else
            if (type.IsArray)
#endif
            {
                var itemType = type.GetElementType();
                return typeof(ValueParser)
#if NETSTANDARD1_6
                    .GetTypeInfo()
#endif
                    .GetMethod(nameof(GetArrayParser), BindingFlags.Static | BindingFlags.NonPublic)
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

        private sealed class StringValueParserImpl : IValueParser<string>
        {
            public string Format(string value) => value;

            public CliTypeInfo TypeInfo { get; } = CliTypeInfo.String;

            public ValueParserResult<string> Parse(string str) => ValueParserResult.Success(str);
        }

        private sealed class BooleanValueParserImpl : IValueParser<bool>
        {
            public string Format(bool value) => value ? "true" : "false";

            public CliTypeInfo TypeInfo { get; } = CliTypeInfo.Enum("bool", "t[rue]", "f[alse]", "y[es]", "n[o]");

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

                TypeInfo = CliTypeInfo.Primitive(typeof(T));
            }

            public CliTypeInfo TypeInfo { get; }

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

        private sealed class ArrayValueParserImpl<T> : IValueParser<T[]>
        {
            private readonly IValueParser<T> _parser;

            public ArrayValueParserImpl(IValueParser<T> parser)
            {
                _parser = parser;
                TypeInfo = CliTypeInfo.Array(parser.TypeInfo);
            }

            public CliTypeInfo TypeInfo { get; }

            public string Format(T[] values) => string.Join(", ", values.Select(_parser.Format));

            public ValueParserResult<T[]> Parse(string str)
            {
                try
                {
                    var values = str.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(_parser.Parse)
                        .ToArray();
                    var error = values.FirstOrDefault(_ => !_.IsSuccess);
                    if (error.ErrorMessage != null)
                    {
                        return ValueParserResult.Error<T[]>(error.ErrorMessage);
                    }

                    return ValueParserResult.Success(values.Select(_ => _.Value).ToArray());
                }
                catch (Exception e)
                {
                    return ValueParserResult.Error<T[]>(e.Message);
                }
            }
        }

        internal sealed class EnumInfo
        {
            public EnumInfo(Type type)
            {
                KnownValues = Enum.GetNames(type)
                    .Select(_ => new
                    {
                        Name = _.ToLowerInvariant(),
                        Value = Convert.ToInt32(Enum.Parse(type, _, false))
                    })
                    .GroupBy(_ => _.Value)
                    .Select(_ => _.First().Name)
                    .ToArray();
            }

            public string[] KnownValues { get; }
        }

        private static readonly object EnumValuesDictLock = new object();
        private static readonly Dictionary<Type, EnumInfo> EnumValuesDict = new Dictionary<Type, EnumInfo>();

        internal static EnumInfo GetEnumInfo(Type type)
        {
            lock (EnumValuesDictLock)
            {
                if (!EnumValuesDict.TryGetValue(type, out var info))
                {
                    info = new EnumInfo(type);
                    EnumValuesDict.Add(type, info);
                }

                return info;
            }
        }

        internal sealed class EnumValueParser<T> : IValueParser<T>
        {
            private readonly EnumInfo _info;

            public EnumValueParser()
            {
                _info = GetEnumInfo(typeof(T));
                TypeInfo = CliTypeInfo.Enum(typeof(T));
            }

            public CliTypeInfo TypeInfo { get; }

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
                    return ValueParserResult.Error<T>(
                        $"Invalid value \"{str}\". Valid values are: {string.Join(", ", _info.KnownValues)}"
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