using System.Collections.Generic;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Allows to override parser output for various non-successful cases
    /// </summary>
    [PublicAPI]
    public interface ICliParserResultFactory
    {
        [NotNull]
        ICliParserResult ValidationErrors(
            [NotNull] ICliParser parser,
            [NotNull] IList<string> errors,
            [NotNull] IHelpUsage helpUsage
        );

        [NotNull]
        ICliParserResult UnknownOptions(
            [NotNull] ICliParser parser,
            [NotNull] IList<string> unknownOptions,
            [NotNull] IHelpUsage helpUsage
        );

        [NotNull]
        ICliParserResult UnknownArguments(
            [NotNull] ICliParser parser,
            [NotNull] IList<string> unknownArguments,
            [NotNull] IHelpUsage helpUsage
        );

        [NotNull]
        ICliParserResult UnknownCommand(
            [NotNull] ICliParser parser,
            [NotNull] string command,
            [NotNull] IHelpUsage helpUsage
        );
    }
}