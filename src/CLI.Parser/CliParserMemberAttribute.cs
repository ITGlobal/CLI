using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Overrides an enum member's name for <see cref="ValueParser.Enum{T}"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    [PublicAPI]
    public sealed class CliParserMemberAttribute : Attribute
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        public CliParserMemberAttribute([NotNull] string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Overriden enum member name
        /// </summary>
        [NotNull]
        public string Name { get; }
    }
}