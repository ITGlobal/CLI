using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Marks an enum member as hidden for <see cref="ValueParser.Enum{T}"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    [PublicAPI]
    public sealed class CliParserIgnoreAttribute : Attribute { }
}