namespace ITGlobal.CommandLine.Parsing
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