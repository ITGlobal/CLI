using System.Linq;
using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    /// <summary>
    ///     Help extension for <see cref="ITreeCliParser"/>
    /// </summary>
    [PublicAPI]
    public static class CliParserHelpExtension
    {
        /// <summary>
        ///     Adds help support to parser
        /// </summary>
        [PublicAPI]
        public static void EnableHelp([NotNull] this ICliParser parser)
        {
            var helpSwitches = new []
            {
                parser.Switch('h', "help")
                    .HelpText("Print help and exit")
                    .DisplayOrder(1000)
                    .HelpSwitch(),
                parser.Switch('?')
                    .HelpText("Print help and exit")
                    .DisplayOrder(1000)
                    .HelpSwitch()
                    .Hidden(),
            };

            parser.BeforeExecute(ctx =>
            {
                if (!helpSwitches.Any(_ => _.IsSet))
                {
                    return;
                }

                PrintUsage((ICliParserInternal)parser, ctx);

                ctx.SuppressLogo();
                ctx.Break();
            });
        }

        internal static void PrintUsage(ICliParserInternal parser, ICliContext ctx)
        {
            if (ctx.Command != null)
            {
                parser.HelpPrinter.PrintHelp(ctx.Command.GetUsage());
            }
            else
            {
                parser.HelpPrinter.PrintHelp(((ICliParser)parser).GetUsage());
            }
        }
    }
}