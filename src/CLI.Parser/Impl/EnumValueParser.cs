using System;
using ITGlobal.CommandLine.Parsing.Help;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class EnumValueParser<T> : IValueParser<T>
        where T: struct, Enum
    {
        private readonly EnumMetadata<T> _metadata = EnumMetadata<T>.Instance;

        public static EnumValueParser<T> Instance { get; } = new EnumValueParser<T>();

        private EnumValueParser()
        {
            TypeInfo = CliTypeInfo.Enum(_metadata.Values);
        }

        public CliTypeInfo TypeInfo { get; }

        public ValueParserResult<T> Parse(string str)
        {
            try
            {
                if (!_metadata.TryParse(str, out var result))
                {
                    return ValueParserError(str);
                }

                return ValueParserResult.Success(result);
            }
            catch
            {
                return ValueParserError(str);
            }
        }

        private ValueParserResult<T> ValueParserError(string str)
        {
            return ValueParserResult.Error<T>(
                $"Invalid value \"{str}\". Valid values are: {string.Join(", ", _metadata.Values)}"
            );
        }

        public string Format(T value)
        {
            return _metadata.Format(value);
        }
    }
}
