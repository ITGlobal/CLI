using System.IO;
using ITGlobal.CommandLine.Parsing.Help;

namespace ITGlobal.CommandLine.Parsing.Impl.ValueParsers
{
    internal sealed class FileInfoValueParserImpl : IValueParser<FileInfo>
    {
        public CliTypeInfo TypeInfo { get; } = CliTypeInfo.String;

        public ValueParserResult<FileInfo> Parse(string str)
        {
            try
            {
                var info = new FileInfo(str);
                return ValueParserResult.Success(info);
            }
            catch
            {
                return ValueParserResult.Error<FileInfo>($"\"{str}\" is not a valid path");
            }
        }

        public string Format(FileInfo value)
        {
            return value.FullName;
        }
    }
}