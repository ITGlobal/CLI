using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    /// <summary>
    ///     Usage info for command line argument
    /// </summary>
    [PublicAPI]
    public sealed class CliArgumentUsage
    {
        internal CliArgumentUsage(
            int position,
            string name,
            CliTypeInfo type,
            string helpText,
            bool isHidden,
            string defaultValue,
            bool isRequired,
            bool isRepeatable)
        {
            Position = position;
            Name = name;
            Type = type;
            HelpText = helpText;
            IsHidden = isHidden;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
            IsRepeatable = isRepeatable;
        }

        /// <summary>
        ///     Argument index (zero-based)
        /// </summary>
        public int Position { get; }

        /// <summary>
        ///     Argument name
        /// </summary>
        [NotNull]
        public string Name { get; }

        /// <summary>
        ///     Argument type name
        /// </summary>
        [NotNull]
        public CliTypeInfo Type { get; }

        /// <summary>
        ///     Help text
        /// </summary>
        [CanBeNull]
        public string HelpText { get; }

        /// <summary>
        ///     Is argument hidden
        /// </summary>
        public bool IsHidden { get; }

        /// <summary>
        ///     Argument default value
        /// </summary>
        [CanBeNull]
        public string DefaultValue { get; }

        /// <summary>
        ///     Is argument required
        /// </summary>
        public bool IsRequired { get; }

        /// <summary>
        ///     Is argument repeatable
        /// </summary>
        public bool IsRepeatable { get; }
    }
}