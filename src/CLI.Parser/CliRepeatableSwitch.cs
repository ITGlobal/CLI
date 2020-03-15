using System;
using ITGlobal.CommandLine.Parsing.Help;
using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line repeatable switch
    /// </summary>
    [PublicAPI]
    public sealed class CliRepeatableSwitch : ICliConsumer
    {
        #region fields

        private string _helpText = "";
        private bool _hidden;
        private int _displayOrder;

        #endregion
        
        #region .ctor

        internal CliRepeatableSwitch() { }

        #endregion
        
        #region properties

        /// <summary>
        ///     Gets a value indicating whether a switch was present in command line
        /// </summary>
        public bool IsSet { get; private set; }

        /// <summary>
        ///     Gets a value indicating how many times switch has been specified
        /// </summary>
        public int RepeatCount { get; private set; }

        internal char? ShortName { get; set; }

        internal string LongName { get; set; }

        #endregion

        #region methods

        /// <summary>
        ///     Set a help text
        /// </summary>
        [NotNull]
        public CliRepeatableSwitch HelpText([NotNull] string text)
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
        public CliRepeatableSwitch Hidden(bool hidden = true)
        {
            _hidden = hidden;
            return this;
        }

        /// <summary>
        ///     Sets switch display order
        /// </summary>
        [NotNull]
        public CliRepeatableSwitch DisplayOrder(int displayOrder)
        {
            _displayOrder = displayOrder;
            return this;
        }

        /// <inheritdoc />
        public override string ToString() => !IsSet ? false.ToString() : RepeatCount.ToString();

        #endregion

        #region operators

        /// <summary>
        ///     Implicit conversion to boolean
        /// </summary>
        public static implicit operator bool(CliRepeatableSwitch option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to int
        /// </summary>
        public static implicit operator int(CliRepeatableSwitch option) => option.RepeatCount;

        #endregion

        #region ICliConsumer

        int ICliConsumer.Priority => CliConsumerPriority.Switch;

        void ICliConsumer.CheckConfiguration() { }

        void ICliConsumer.Consume(RawCommandLine raw)
        {
            if (ShortName != null)
            {
                while (raw.ConsumeSwitch(ShortName.Value))
                {
                    RepeatCount++;
                    IsSet = true;
                }
            }

            if (LongName != null)
            {
                while (raw.ConsumeSwitch(LongName))
                {
                    RepeatCount++;
                    IsSet = true;
                }
            }
        }

        void ICliConsumer.BuildUsage(IUsageBuilder builder)
        {
            builder.AddSwitch(new CliSwitchUsage(
                names: builder.GetOptionNames(ShortName, LongName),
                helpText: _helpText,
                isHidden: _hidden,
                isRepeatable: true,
                isHelpSwitch: false,
                displayOrder: _displayOrder
            ));
        }

        #endregion
    }
}