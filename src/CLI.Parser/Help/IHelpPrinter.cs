using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    /// <summary>
    ///     Prints help to console
    /// </summary>
    [PublicAPI]
    public interface IHelpPrinter
    {
        void PrintHelp([NotNull] CliParserUsage usage);
        void PrintHelp([NotNull] CliCommandUsage usage);

        void PrintImplicitHelp([NotNull] CliParserUsage usage);
        void PrintImplicitHelp([NotNull] CliCommandUsage usage);
    }
}
