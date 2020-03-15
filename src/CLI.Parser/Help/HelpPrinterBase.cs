using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    /// <summary>
    ///     A base class for <see cref="IHelpPrinter"/> implementations
    /// </summary>
    [PublicAPI]
    public abstract partial class HelpPrinterBase : IHelpPrinter
    {
        void IHelpPrinter.PrintHelp(CliParserUsage usage)
        {
            var info = GetRootUsageInfo(usage);
            Print(info, isImplicitHelp: false);
        }

        void IHelpPrinter.PrintHelp(CliCommandUsage usage)
        {
            var info = GetCommandUsageInfo(usage);
            Print(info, isImplicitHelp: false);
        }

        void IHelpPrinter.PrintImplicitHelp(CliParserUsage usage)
        {
            var info = GetRootUsageInfo(usage);
            Print(info, isImplicitHelp: true);
        }

        void IHelpPrinter.PrintImplicitHelp(CliCommandUsage usage)
        {
            var info = GetCommandUsageInfo(usage);
            Print(info, isImplicitHelp: true);
        }

        protected abstract void Print([NotNull] UsageInfo info, bool isImplicitHelp);
    }
}