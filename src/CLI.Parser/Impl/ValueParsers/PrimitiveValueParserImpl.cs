using System;
using System.Globalization;

namespace ITGlobal.CommandLine.Parsing.Impl.ValueParsers
{
    internal sealed class PrimitiveValueParserImpl<T> : IValueParser<T>
        where T : struct, IFormattable
    {
        private readonly Func<string, T> _parse;
        private readonly Func<T, string> _format;

        public PrimitiveValueParserImpl(Func<string, T> parse, Func<T, string> format = null)
        {
            format ??= DefaultFormat;

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
            return value.ToString(null, CultureInfo.InvariantCulture);
        }
    }
}