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
        ///     Adds help switch support to parser
        /// </summary>
        [PublicAPI]
        public static void EnableHelpSwitch([NotNull] this ICliParser parser)
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

        /// <summary>
        ///     Adds help command support to parser
        /// </summary>
        [PublicAPI]
        public static void EnableHelpCommand([NotNull] this ITreeCliParser parser)
        {
            var command = parser.Command("help")
                .HelpText("Print help and exit")
                .DisplayOrder(10000);

            var arguments = parser.RepeatableArgument("command")
                .HelpText("Command name");

            command.OnExecute(ctx =>
            {
                var treeCliParser = (TreeCliParser)parser;
                var cliParserInternal = (ICliParserInternal)parser;
                var helpPrinter = cliParserInternal.HelpPrinter;

                if (!arguments.IsSet || arguments.Values.Length == 0)
                {
                    helpPrinter.PrintHelp(parser.GetUsage());
                    return;
                }

                ICliCommand command;
                try
                {
                    var tokens = CommandLineTokenizer.Tokenize(cliParserInternal.Flags, arguments);
                    var raw = new RawCommandLine(tokens);
                    command = treeCliParser.SelectCommand(raw);
                }
                catch (UnknownCommandException e)
                {
                    var result = treeCliParser.ResultFactory.UnknownCommand(
                        parser: parser,
                        command: e.CommandName,
                        commandNameCandidates: e.CommandNameCandidates,
                        helpUsage: e.Usage
                    );
                    ctx.Break(result.Run());
                    return;
                }

                if (command is CliCommand c)
                {
                    helpPrinter.PrintHelp(c.GetUsage());
                }
                else
                {
                    helpPrinter.PrintHelp(parser.GetUsage());
                }
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