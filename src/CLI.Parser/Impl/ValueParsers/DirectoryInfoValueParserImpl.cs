using System.IO;
using ITGlobal.CommandLine.Parsing.Help;

namespace ITGlobal.CommandLine.Parsing.Impl.ValueParsers
{
    internal sealed class DirectoryInfoValueParserImpl : IValueParser<DirectoryInfo>
    {
        public CliTypeInfo TypeInfo { get; } = CliTypeInfo.String;

        public ValueParserResult<DirectoryInfo> Parse(string str)
        {
            try
            {
                var info = new DirectoryInfo(str);
                return ValueParserResult.Success(info);
            }
            catch
            {
                return ValueParserResult.Error<DirectoryInfo>($"\"{str}\" is not a valid path");
            }
        }

        public string Format(DirectoryInfo value)
        {
            return value.FullName;
        }
    }
}