namespace ITGlobal.CommandLine.Parsing.Help
{
    public sealed class EnumCliTypeInfo : CliTypeInfo
    {
        public EnumCliTypeInfo(string typeName, params string[] validValues)
            : base(typeName)
        {
            ValidValues = validValues ?? new string[0];
        }

        public string[] ValidValues { get; }
    }
}