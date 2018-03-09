using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Localication provider
    /// </summary>
    public abstract class LocalizedText
    {
        [NotNull]
        public virtual string AmbiguousCommandAlias => "Alias '{0}' points to more than one command: {1}";
        [NotNull]
        public virtual string AmbiguousParameter => "Alias '{0}' points to more than one parameter: {1}";
        [NotNull]
        public virtual string AmbiguousCommandParameter => "Alias '{0}' (in '{1}' command) point to more than one parameter: {2}";
        [NotNull]
        public virtual string Usage => "Usage:";
        [NotNull]
        public virtual string Commands => "Commands";
        [NotNull]
        public virtual string Parameters => "Parameters";
        [NotNull]
        public virtual string RequiredParameter => "(Required)";
        [NotNull]
        public virtual string ShowHelp => "Show help";
        [NotNull]
        public virtual string RequiredParameterIsNotSet => "Parameter '{0}' is not set";
        [NotNull]
        public virtual string UnknownCommand => "Command '{0}' is unknown";
    }
}