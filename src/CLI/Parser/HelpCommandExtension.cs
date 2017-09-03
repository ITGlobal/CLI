using System;
using JetBrains.Annotations;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Extends <see cref="ICommandParser"/> to support auto-generated help
    /// </summary>
    [PublicAPI]
    public static class HelpCommandExtension
    {
        /// <summary>
        ///     Defines an auto-generated 'help' command
        /// </summary>
        /// <param name="parser">
        ///     Command line parser
        /// </param>
        /// <param name="name">
        ///     Command name
        /// </param>
        /// <returns>
        ///     A 'help' command
        /// </returns>
        [PublicAPI, NotNull]
        public static ICommand HelpCommand([NotNull] this ICommandParser parser, [NotNull] string name = "help")
        {
            var command = parser.Command(name);
            var target = command.Parameter<string>(0, "command");

            command.HelpText(Text.ShowHelp);
            command.Handler(_ =>
            {
                if (!target.IsSet)
                {
                    parser.Usage().Print();
                    return 0;
                }

                var commandName = target.Value.ToLowerInvariant();
                var usage = parser.Usage(commandName);
                if (usage == null)
                {
                    throw new CommandNotFoundException(commandName);
                }

                usage.Print();
                return 0;
            });
            ((Command)command).SuppressValidation = true;

            parser.Handler(_ =>
            {
                parser.Usage().Print();
                return 0;
            });

            ((CommandParser)parser).SuppressValidation = true;

            return command;
        }

        /// <summary>
        ///     Adds an auto-generated '--help' switch
        /// </summary>
        [PublicAPI, NotNull]
        public static ICommandParser HelpSwitch([NotNull] this ICommandParser parser)
        {
            var helpSwitch = parser.Switch("h").Alias("help")
                .HelpText("Show help");
            parser.Hook(() =>
            {
                if (helpSwitch.IsSet)
                {
                    var p = (CommandParser)parser;
                    if(p.Commands.Count > 0 && p.CommandNameParameter.IsSet)
                    {
                        var command = p.CommandNameParameter.Value;
                        parser.Usage(command).Print();
                        return 0;
                    }

                    parser.Usage().Print();
                    return 0;
                }

                return null;
            });

            return parser;
        }
    }
}