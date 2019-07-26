using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Argument or option type information
    /// </summary>
    [PublicAPI]
    public abstract class CliTypeInfo
    {
        internal CliTypeInfo(string name)
        {
            Name = name;
        }

        [NotNull]
        public string Name { get; }

        [NotNull]
        public static PrimitiveCliTypeInfo Primitive(Type type)
            => new PrimitiveCliTypeInfo(TypeNameHelper.GetTypeName(type));

        [NotNull]
        public static StringCliTypeInfo String { get; } = new StringCliTypeInfo();

        [NotNull]
        public static EnumCliTypeInfo Enum(string typeName, params string[] validValues)
            => new EnumCliTypeInfo(typeName,  validValues);

        [NotNull]
        public static EnumCliTypeInfo Enum(Type type)
            => Enum("enum", ValueParser.GetEnumInfo(type).KnownValues);

        [NotNull]
        public static ArrayCliTypeInfo Array(CliTypeInfo elementType)
            => new ArrayCliTypeInfo($"array of {elementType.Name}", elementType);

    }
}