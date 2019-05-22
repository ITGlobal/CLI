using System;
using System.Collections.Generic;
using System.Linq;
using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line command
    /// </summary>
    [PublicAPI]
    public sealed class CliCommand : ICliCommandRoot, ICliCommand
    {
        #region fields

        private readonly TreeCliParser _root;
        private readonly ICliCommand _parent;
        private readonly List<string> _names = new List<string>();

        private readonly List<ICliConsumer> _consumers = new List<ICliConsumer>();
        private readonly List<CliCommand> _commands = new List<CliCommand>();
        private readonly List<CliAsyncHandler> _beforeExecuteHandlers = new List<CliAsyncHandler>();
        private readonly List<CliAsyncHandler> _executeHandlers = new List<CliAsyncHandler>();

        private string _helpText;
        private bool _hidden;
        private int _displayOrder;
        private int _argumentCount;

        #endregion

        #region .ctor

        internal CliCommand(TreeCliParser root, ICliCommand parent, string name)
        {
            _root = root;
            _parent = parent;
            _names.Add(name);
        }

        #endregion

        #region Public members

        /// <summary>
        ///     Parent command
        /// </summary>
        [CanBeNull]
        public CliCommand Parent => _parent as CliCommand;

        /// <summary>
        ///     Add a command alias
        /// </summary>
        [NotNull]
        public CliCommand Alias([NotNull] string alias)
        {
            if (string.IsNullOrWhiteSpace(alias))
            {
                throw new ArgumentNullException(nameof(alias));
            }

            _names.Add(alias);
            return this;
        }

        /// <summary>
        ///     Set a help text
        /// </summary>
        [NotNull]
        public CliCommand HelpText([NotNull] string text)
        {
            _helpText = text;
            return this;
        }

        /// <summary>
        ///     Mark command as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public CliCommand Hidden(bool hidden = true)
        {
            _hidden = hidden;
            return this;
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
        public CliRepeatableSwitch RepeatableSwitch(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var sw = new CliRepeatableSwitch();
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
        public CliRepeatableSwitch RepeatableSwitch(
            string longName,
            string helpText = null,
            bool hidden = false)
        {
            if (string.IsNullOrEmpty(longName))
            {
                throw new ArgumentNullException(nameof(longName));
            }

            var sw = new CliRepeatableSwitch();
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
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            var position = _argumentCount;
            _argumentCount++;
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
        public CliRepeatableArgument<T> RepeatableArgument<T>(
            string displayName,
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            var position = _argumentCount;
            _argumentCount++;
            var arg = new CliRepeatableArgument<T>(position, displayName);
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
        public CliRepeatableOption<T> RepeatableOption<T>(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var option = new CliRepeatableOption<T>();
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
        public CliRepeatableOption<T> RepeatableOption<T>(string longName, string helpText = null, bool hidden = false)
        {
            if (string.IsNullOrEmpty(longName))
            {
                throw new ArgumentNullException(nameof(longName));
            }

            var sw = new CliRepeatableOption<T>();
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

            var command = new CliCommand(_root, this, name);
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
        ///     Sets comand display order
        /// </summary>
        [NotNull]
        public CliCommand DisplayOrder(int displayOrder)
        {
            _displayOrder = displayOrder;
            return this;
        }

        /// <summary>
        ///     Get usage info
        /// </summary>
        [NotNull]
        public CliCommandUsage GetUsage()
        {
            var commandName = ((ICliCommand)this).GetCommandName().ToArray();
            var rootUsage = _root.GetUsage();
            var usage = rootUsage.GetCommandUsage(commandName);
            if (usage == null)
            {
                throw new InvalidOperationException($"Unable to get usage for command \"{rootUsage.ExecutableName} {string.Join(" ", commandName)}\"");
            }

            return usage;
        }

        #endregion

        #region Internal methods

        internal IEnumerable<string> EnumerateCommandNames() => _names;

        internal bool MatchesCommandName(string name)
        {
            return _names.Any(_ => _.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        IHelpUsage ICliCommand.GetUsage() => GetUsage();

        internal ICliCommand SelectCommand(RawCommandLine raw)
        {
            if (_commands.Count == 0)
            {
                return this;
            }

            var name = raw.ConsumeArgument(0);
            if (name == null)
            {
                return this;
            }
            

            var (cmd, commandCandidates) = SelectCommandHelper.SelectCommand(raw, _commands, name);
            if (cmd != null)
            {
                return cmd;
            }

            var prefix = ((ICliCommand) this).GetFullCommandName();

            if (!string.IsNullOrEmpty(prefix))
            {
                commandCandidates = commandCandidates.Select(n => $"{prefix} {n}").ToArray();
            }

            throw new UnknownCommandException(name, commandCandidates, GetUsage());
        }

        string ICliCommand.GetFullCommandName()
        {
            var parentName = _parent.GetFullCommandName();
            if (!string.IsNullOrEmpty(parentName))
            {
                return $"{parentName} {_names[0]}";
            }

            return _names[0];
        }

        IEnumerable<string> ICliCommand.GetCommandName()
        {
            foreach (var name in _parent.GetCommandName())
            {
                yield return name;
            }

            yield return _names[0];
        }

        void ICliCommand.Consume(RawCommandLine raw)
        {
            _parent.Consume(raw);

            foreach (var option in _consumers.OrderBy(_ => _.Priority))
            {
                option.Consume(raw);
            }
        }

        IEnumerable<CliAsyncHandler> ICliCommand.EnumerateHooks()
        {
            foreach (var handler in _parent.EnumerateHooks())
            {
                yield return handler;
            }

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

        internal void BuildUsage(ICliCommandUsageBuilder parentBuilder)
        {
            var builder = parentBuilder.AddCommand(_names.ToArray(), _helpText, _hidden, _displayOrder);

            foreach (var consumer in _consumers)
            {
                consumer.BuildUsage(builder);
            }

            foreach (var command in _commands)
            {
                command.BuildUsage(builder);
            }
        }

        internal void CheckConfiguration()
        {
            foreach (var consumer in _consumers)
            {
                consumer.CheckConfiguration();
            }

            foreach (var c in _commands)
            {
                c.CheckConfiguration();
            }
        }

        #endregion
    }
}