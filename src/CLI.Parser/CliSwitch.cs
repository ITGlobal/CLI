using System;
using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line switch
    /// </summary>
    [PublicAPI]
    public sealed class CliSwitch : ICliConsumer
    {
        #region fields

        private string _helpText = "";
        private bool _hidden;
        private int _displayOrder;
        private bool _isHelpSwitch;

        #endregion

        #region .ctor
        
        internal CliSwitch() { }

        #endregion
        
        #region properties

        /// <summary>
        ///     Gets a value indicating whether a switch was present in command line
        /// </summary>
        public bool IsSet { get; private set; }

        internal char? ShortName { get; set; }

        internal string LongName { get; set; }

        #endregion

        #region methods

        /// <summary>
        ///     Set a help text
        /// </summary>
        [NotNull]
        public CliSwitch HelpText([NotNull] string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            _helpText = text;
            return this;
        }

        /// <summary>
        ///     Mark switch as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public CliSwitch Hidden(bool hidden = true)
        {
            _hidden = hidden;
            return this;
        }

        /// <summary>
        ///     Sets switch display order
        /// </summary>
        [NotNull]
        public CliSwitch DisplayOrder(int displayOrder)
        {
            _displayOrder = displayOrder;
            return this;
        }

        /// <summary>
        ///     Marks switch as a help one
        /// </summary>
        [NotNull]
        internal CliSwitch HelpSwitch(bool isHelpSwitch = true)
        {
            _isHelpSwitch = isHelpSwitch;
            return this;
        }

        /// <inheritdoc />
        public override string ToString() => IsSet.ToString();

        #endregion

        #region operators

        /// <summary>
        ///     Implicit conversion to boolean
        /// </summary>
        public static implicit operator bool(CliSwitch option) => option.IsSet;

        #endregion

        #region ICliConsumer

        int ICliConsumer.Priority => CliConsumerPriority.Switch;

        void ICliConsumer.CheckConfiguration() { }

        void ICliConsumer.Consume(RawCommandLine raw)
        {
            if (ShortName != null)
            {
                IsSet |= raw.ConsumeSwitch(ShortName.Value);
            }

            if (LongName != null)
            {
                IsSet |= raw.ConsumeSwitch(LongName);
            }
        }

        void ICliConsumer.BuildUsage(IUsageBuilder builder)
        {
            builder.AddSwitch(new CliSwitchUsage(
                names: builder.GetOptionNames(ShortName, LongName),
                helpText: _helpText,
                isHidden: _hidden,
                isRepeatable: false,
                isHelpSwitch: _isHelpSwitch,
                displayOrder: _displayOrder
            ));
        }

        #endregion
    }
}
