using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class TreeCliParser : ITreeCliParser, ICliCommand
    {
        #region fields

        private readonly List<ICliConsumer> _consumers = new List<ICliConsumer>();
        private readonly List<CliCommand> _commands = new List<CliCommand>();
        private readonly List<CliAsyncHandler> _beforeExecuteHandlers = new List<CliAsyncHandler>();
        private readonly List<CliAsyncHandler> _executeHandlers = new List<CliAsyncHandler>();

        #endregion

        #region properties

        /// <summary>
        ///     Terminal instance associated with parser
        /// </summary>
        public ITerminal Terminal { get; private set; } = CommandLine.Terminal.Current;

        /// <summary>
        ///     Executable name
        /// </summary>
        public string ExecutableName { get; private set; }
            = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);

        /// <summary>
        ///     Application logo
        /// </summary>
        public string Logo { get; private set; }

        /// <summary>
        ///     Application description
        /// </summary>
        public string HelpText { get; private set; }

        /// <summary>
        ///     Is application logo suppressed
        /// </summary>
        public bool IsLogoSuppressed { get; private set; }

        /// <summary>
        ///     Parser flags
        /// </summary>
        public CliParserFlags Flags { get; private set; } = CliParserFlags.Default;

        public bool EnableImplicitHelp { get; set; }

        #endregion

        #region ITreeCliParser

        /// <summary>
        ///     Set an executable name (process name is used by default)
        /// </summary>
        void ICliParser.ExecutableName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            ExecutableName = name;
        }

        /// <summary>
        ///     Set a terminal for parser output
        /// </summary>
        void ICliParser.UseTerminal(ITerminal terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            Terminal = terminal;
        }

        /// <summary>
        ///     Set application logo
        /// </summary>
        void ICliParser.Logo(string logo)
        {
            if (logo != null)
            {
                logo = StringUtils.TrimLeadingAndTrailingEmptyLines(logo);
            }

            Logo = logo;
        }

        /// <summary>
        ///     Set application description
        /// </summary>
        void ICliParser.HelpText(string text)
        {
            HelpText = text;
        }

        /// <summary>
        ///     Suppress application logo
        /// </summary>
        void ICliParser.SuppressLogo(bool suppress)
        {
            IsLogoSuppressed = suppress;
        }

        /// <summary>
        ///     Set parser flags
        /// </summary>
        void ICliParser.Flags(CliParserFlags flags)
        {
            if (!flags.HasFlag(CliParserFlags.WindowsNotation) &&
                !flags.HasFlag(CliParserFlags.PosixNotation))
            {
                throw new ArgumentException(
                    $"At least one of flags should be specified: {nameof(CliParserFlags.PosixNotation)}, {nameof(CliParserFlags.WindowsNotation)}",
                    nameof(flags)
                );
            }

            Flags = flags;
        }

        /// <summary>
        ///     Add a command line switch
        /// </summary>
        public CliSwitch Switch(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var sw = new CliSwitch();
            _consumers.Add(sw);

            sw.ShortName = shortName;

            if (longName != null)
            {
                sw.LongName = longName;
            }

            if (!string.IsNullOrEmpty(helpText))
            {
                sw.HelpText(helpText);
            }

            if (hidden)
            {
                sw.Hidden();
            }

            return sw;
        }

        /// <summary>
        ///     Add a command line switch
        /// </summary>
        public CliSwitch Switch(
            string longName,
            string helpText = null,
            bool hidden = false)
        {
            if (string.IsNullOrEmpty(longName))
            {
                throw new ArgumentNullException(nameof(longName));
            }

            var sw = new CliSwitch();
            _consumers.Add(sw);

            sw.LongName = longName;

            if (!string.IsNullOrEmpty(helpText))
            {
                sw.HelpText(helpText);
            }

            if (hidden)
            {
                sw.Hidden();
            }

            return sw;
        }

        /// <summary>
        ///     Add a command line repeteable switch
        /// </summary>
        public MultiCliSwitch MultiSwitch(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var sw = new MultiCliSwitch();
            _consumers.Add(sw);

            sw.ShortName = shortName;

            if (longName != null)
            {
                sw.LongName = longName;
            }

            if (!string.IsNullOrEmpty(helpText))
            {
                sw.HelpText(helpText);
            }

            if (hidden)
            {
                sw.Hidden();
            }

            return sw;
        }

        /// <summary>
        ///     Add a command line repeteable switch
        /// </summary>
        public MultiCliSwitch MultiSwitch(
            string longName,
            string helpText = null,
            bool hidden = false)
        {
            if (string.IsNullOrEmpty(longName))
            {
                throw new ArgumentNullException(nameof(longName));
            }

            var sw = new MultiCliSwitch();
            _consumers.Add(sw);

            sw.LongName = longName;

            if (!string.IsNullOrEmpty(helpText))
            {
                sw.HelpText(helpText);
            }

            if (hidden)
            {
                sw.Hidden();
            }

            return sw;
        }

        /// <summary>
        ///     Add a command line positional argument
        /// </summary>
        public CliArgument<T> Argument<T>(
            string displayName,
            int position,
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            var arg = new CliArgument<T>(position, displayName);
            _consumers.Add(arg);

            if (!string.IsNullOrEmpty(helpText))
            {
                arg.HelpText(helpText);
            }

            if (hidden)
            {
                arg.Hidden();
            }

            if (parser != null)
            {
                arg.UseParser(parser);
            }

            return arg;
        }

        /// <summary>
        ///     Add a command line repeatable positional argument
        /// </summary>
        public MultiCliArgument<T> MultiArgument<T>(
            string displayName,
            int position,
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            var arg = new MultiCliArgument<T>(position, displayName);
            _consumers.Add(arg);

            if (!string.IsNullOrEmpty(helpText))
            {
                arg.HelpText(helpText);
            }

            if (hidden)
            {
                arg.Hidden();
            }

            if (parser != null)
            {
                arg.UseParser(parser);
            }

            return arg;
        }

        /// <summary>
        ///     Add a command line option
        /// </summary>
        public CliOption<T> Option<T>(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var option = new CliOption<T>();
            _consumers.Add(option);

            option.ShortName = shortName;

            if (longName != null)
            {
                option.LongName = longName;
            }

            if (!string.IsNullOrEmpty(helpText))
            {
                option.HelpText(helpText);
            }

            if (hidden)
            {
                option.Hidden();
            }

            return option;
        }

        /// <summary>
        ///     Add a command line option
        /// </summary>
        public CliOption<T> Option<T>(string longName, string helpText = null, bool hidden = false)
        {
            if (string.IsNullOrEmpty(longName))
            {
                throw new ArgumentNullException(nameof(longName));
            }

            var sw = new CliOption<T>();
            _consumers.Add(sw);

            sw.LongName = longName;

            if (!string.IsNullOrEmpty(helpText))
            {
                sw.HelpText(helpText);
            }

            if (hidden)
            {
                sw.Hidden();
            }

            return sw;
        }

        /// <summary>
        ///     Add a command line repetable option
        /// </summary>
        public MultiCliOption<T> MultiOption<T>(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var option = new MultiCliOption<T>();
            _consumers.Add(option);

            option.ShortName = shortName;

            if (longName != null)
            {
                option.LongName = longName;
            }

            if (!string.IsNullOrEmpty(helpText))
            {
                option.HelpText(helpText);
            }

            if (hidden)
            {
                option.Hidden();
            }

            return option;
        }

        /// <summary>
        ///     Add a command line repetable option
        /// </summary>
        public MultiCliOption<T> MultiOption<T>(string longName, string helpText = null, bool hidden = false)
        {
            if (string.IsNullOrEmpty(longName))
            {
                throw new ArgumentNullException(nameof(longName));
            }

            var sw = new MultiCliOption<T>();
            _consumers.Add(sw);

            sw.LongName = longName;

            if (!string.IsNullOrEmpty(helpText))
            {
                sw.HelpText(helpText);
            }

            if (hidden)
            {
                sw.Hidden();
            }

            return sw;
        }

        /// <summary>
        ///     Add a command line command
        /// </summary>
        public CliCommand Command(string name, string helpText = null, bool hidden = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            var command = new CliCommand(this, this, name);
            _commands.Add(command);

            if (!string.IsNullOrEmpty(helpText))
            {
                command.HelpText(helpText);
            }

            if (hidden)
            {
                command.Hidden();
            }

            return command;
        }

        /// <summary>
        ///     Add a callback that will be executed before main handler
        /// </summary>
        public void BeforeExecute(CliHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            _beforeExecuteHandlers.Add(handler.ToAsyncHandler());
        }

        /// <summary>
        ///     Add a callback that will be executed before main handler
        /// </summary>
        public void BeforeExecuteAsync(CliAsyncHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            _beforeExecuteHandlers.Add(handler);
        }

        /// <summary>
        ///     Add a execution callback
        /// </summary>
        public void OnExecute(CliHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            _executeHandlers.Add(handler.ToAsyncHandler());
        }

        /// <summary>
        ///     Add a execution callback
        /// </summary>
        public void OnExecuteAsync(CliAsyncHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            _executeHandlers.Add(handler);
        }

        /// <summary>
        ///     Run the parser
        /// </summary>
        public ICliParserResult Parse(params string[] args)
        {
            foreach (var consumer in _consumers)
            {
                consumer.CheckConfiguration();
            }

            foreach (var c in _commands)
            {
                c.CheckConfiguration();
            }

            var tokens = CommandLineTokenizer.Tokenize(Flags, args);
            var raw = new RawCommandLine(tokens);

            // Select command to execute
            ICliCommand command;

            try
            {
                command = SelectCommand(raw);
            }
            catch (UnknownCommandException e)
            {
                return new UnknownCommandCliParserResult(
                    Terminal, 
                    e.CommandName,
                    e.Usage);
            }
            
            // Consume command line options and arguments
            command.Consume(raw);

            var unknownArguments = raw.GetUnconsumedArguments();
            var ctx = new CliContext(
                IsLogoSuppressed && !string.IsNullOrEmpty(Logo),
                command as CliCommand,
                unknownArguments
            );

            command.EnumerateHooks().Run(ctx);
            if (ctx.ExitCode != null)
            {
                return new HookCliParserResult(ctx.ExitCode.Value);
            }

            // Validate input
            if (raw.Errors.Count > 0)
            {
                return new InvalidCliParserResult(Terminal, raw.Errors, GetUsage());
            }

            var unknownOptions = raw.GetUnconsumedOptions();
            if (unknownOptions.Length > 0 && !Flags.HasFlag(CliParserFlags.IgnoreUnknownOptions))
            {
                return new UnknownOptionsCliParserResult(Terminal, unknownOptions, GetUsage());
            }
            
            if (unknownArguments.Length > 0 && !Flags.HasFlag(CliParserFlags.AllowFreeArguments))
            {
                return new UnknownArgumentsCliParserResult(Terminal, unknownArguments, GetUsage());
            }
            
            var handlers = command.EnumerateHandlers().ToArray();
            if (handlers.Length == 0 && EnableImplicitHelp)
            {
                return new SuccessfulCliParserResult(
                    new[]
                    {
                        CliHandlerHelper.ToAsyncHandler(
                            context => TreeCliParserHelpExtension.PrintUsage(this, context)
                        )
                    },
                    Terminal,
                    null,
                    ctx
                );
            }

            return new SuccessfulCliParserResult(
                handlers,
                Terminal,
                !ctx.IsLogoSuppressed ? Logo : null,
                ctx
            );

            ICliCommand SelectCommand(RawCommandLine r)
            {
                if (_commands.Count == 0)
                {
                    return this;
                }

                var name = r.ConsumeArgument(0);
                if (name == null)
                {
                    return this;
                }

                foreach (var c in _commands)
                {
                    if (c.MatchesCommandName(name))
                    {
                        return c.SelectCommand(r);
                    }
                }

                throw new UnknownCommandException(name, GetUsage());
            }
        }

        /// <summary>
        ///     Get usage info
        /// </summary>
        public TreeCliParserUsage GetUsage()
        {
            var builder = new TreeCliParserUsageBuilder(this);

            foreach (var consumer in _consumers)
            {
                consumer.BuildUsage(builder);
            }

            foreach (var command in _commands)
            {
                command.BuildUsage(builder);
            }

            var usage = builder.Build();
            return usage;
        }

        #endregion

        #region ICliCommand

        IHelpUsage ICliCommand.GetUsage() => GetUsage();

        IEnumerable<string> ICliCommand.GetCommandName()
        {
            yield break;
        }

        void ICliCommand.Consume(RawCommandLine raw)
        {
            foreach (var option in _consumers)
            {
                option.Consume(raw);
            }
        }

        IEnumerable<CliAsyncHandler> ICliCommand.EnumerateHooks()
        {
            foreach (var handler in _beforeExecuteHandlers)
            {
                yield return handler;
            }
        }

        IEnumerable<CliAsyncHandler> ICliCommand.EnumerateHandlers()
        {
            foreach (var handler in _executeHandlers)
            {
                yield return handler;
            }
        }

        #endregion
    }
}
