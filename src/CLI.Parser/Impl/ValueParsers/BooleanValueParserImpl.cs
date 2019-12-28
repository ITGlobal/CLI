namespace ITGlobal.CommandLine.Parsing.Impl.ValueParsers
{
    internal sealed class BooleanValueParserImpl : IValueParser<bool>
    {
        public string Format(bool value) => value ? "true" : "false";

        public CliTypeInfo TypeInfo { get; } = CliTypeInfo.Enum("bool", new[] { "t[rue]", "f[alse]", "y[es]", "n[o]" });

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
}