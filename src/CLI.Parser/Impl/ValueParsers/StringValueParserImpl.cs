namespace ITGlobal.CommandLine.Parsing.Impl.ValueParsers
{
    internal sealed class StringValueParserImpl : IValueParser<string>
    {
        public string Format(string value) => value;

        public CliTypeInfo TypeInfo { get; } = CliTypeInfo.String;

        public ValueParserResult<string> Parse(string str) => ValueParserResult.Success(str);
    }
}
