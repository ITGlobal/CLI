namespace ITGlobal.CommandLine.Parsing
{
    public sealed class ArrayCliTypeInfo : CliTypeInfo
    {
        public ArrayCliTypeInfo(string name, CliTypeInfo elementType)
            : base(name)
        {
            ElementType = elementType;
        }

        public CliTypeInfo ElementType { get; }
    }
}