using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    /// <summary>
    ///     Usage info for command line switch
    /// </summary>
    [PublicAPI]
    public sealed class CliSwitchUsage
    {
        internal CliSwitchUsage(
            string[] names,
            string helpText,
            bool isHidden,
            bool isRepeatable,
            bool isHelpSwitch,
            int displayOrder
            )
        {
            Names = names;
            HelpText = helpText;
            IsHidden = isHidden;
            IsRepeatable = isRepeatable;
            IsHelpSwitch = isHelpSwitch;
            DisplayOrder = displayOrder;
        }

        /// <summary>
        ///     Switch names
        /// </summary>
        [NotNull]
        public string[] Names { get; }

        /// <summary>
        ///     Help text
        /// </summary>
        [CanBeNull]
        public string HelpText { get; }

        /// <summary>
        ///     Is switch hidden
        /// </summary>
        public bool IsHidden { get; }

        /// <summary>
        ///     Is switch repeatable
        /// </summary>
        public bool IsRepeatable { get; }

        /// <summary>
        ///     Is this switch a help switch
        /// </summary>
        public bool IsHelpSwitch { get; }

        /// <summary>
        ///     Switch display order
        /// </summary>
        public int DisplayOrder { get; }
    }
}