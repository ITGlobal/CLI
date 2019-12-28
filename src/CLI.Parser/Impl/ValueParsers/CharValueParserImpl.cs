using System;

namespace ITGlobal.CommandLine.Parsing.Impl.ValueParsers
{
    internal sealed class CharValueParserImpl : IValueParser<char>
    {
        public CliTypeInfo TypeInfo { get; } = CliTypeInfo.String;

        public string Format(char value) => value.ToString();

        public ValueParserResult<char> Parse(string str)
        {
            if (str.Length == 0)
            {
                throw new FormatException("Value is empty");
            }

            if (str.Length > 1)
            {
                throw new FormatException("Value is too long");
            }

            return ValueParserResult.Success(str[0]);
        }
    }
}