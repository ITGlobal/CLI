using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Usage info for command line option
    /// </summary>
    [PublicAPI]
    public sealed class CliOptionUsage
    {
        internal CliOptionUsage(
            string[] names,
            CliTypeInfo type,
            string helpText,
            bool isHidden,
            string defaultValue,
            bool isRequired,
            bool isRepeatable,
            int displayOrder)
        {
            Names = names;
            Type = type;
            HelpText = helpText;
            IsHidden = isHidden;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
            IsRepeatable = isRepeatable;
            DisplayOrder = displayOrder;
        }

        /// <summary>
        ///     Option names
        /// </summary>
        [NotNull]
        public string[] Names { get; }

        /// <summary>
        ///     Option type
        /// </summary>
        [NotNull]
        public CliTypeInfo Type { get; }

        /// <summary>
        ///     Help text
        /// </summary>
        [CanBeNull]
        public string HelpText { get; }

        /// <summary>
        ///     Is option hidden
        /// </summary>
        public bool IsHidden { get; }

        /// <summary>
        ///     Option default value
        /// </summary>
        [CanBeNull]
        public string DefaultValue { get; }

        /// <summary>
        ///     Is option required
        /// </summary>
        public bool IsRequired { get; }

        /// <summary>
        ///     Is option repeatable
        /// </summary>
        public bool IsRepeatable { get; }

        /// <summary>
        ///     Option display order
        /// </summary>
        public int DisplayOrder { get; }
    }
}