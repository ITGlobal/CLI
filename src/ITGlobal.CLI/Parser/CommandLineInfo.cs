using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class CommandLineInfo
    {
        private string[] _args;

        public CommandLineInfo(string[] args)
        {
            _args = args;
        }

        public List<string> UnconsumedArgs { get; } = new List<string>();

        public List<string> Errors { get; } = new List<string>();

        public void Parse(IList<IParameterParser> parsers)
        {
            foreach (var parser in parsers)
            {
                parser.Reset();
            }

            var remainingArgs = new List<string>();
            for (var index = 0; index < _args.Length; index++)
            {
                var arg = _args[index];

                var isConsumed = false;
                foreach (var parser in parsers)
                {
                    var result = parser.TryConsume(_args, ref index);
                    if (result.IsConsumed)
                    {
                        isConsumed = true;
                        break;
                    }

                    if (!result.IsSuccess)
                    {
                        Errors.Add(result.Error);
                    }
                }

                if (!isConsumed)
                {
                    remainingArgs.Add(arg);
                }
            }

            _args = remainingArgs.ToArray();
            remainingArgs.Clear();

            for (var index = 0; index < _args.Length; index++)
            {
                var arg = _args[index];

                if (arg == "--")
                {
                    index++;
                    for (; index < _args.Length; index++)
                    {
                        UnconsumedArgs.Add(_args[index]);
                    }
                    break;
                }

                var isConsumed = false;
                foreach (var parser in parsers)
                {
                    var result = parser.TryConsumeAt(_args, index);
                    if (result.IsConsumed)
                    {
                        isConsumed = true;
                        break;
                    }

                    if (!result.IsSuccess)
                    {
                        Errors.Add(result.Error);
                    }
                }

                if (!isConsumed)
                {
                    remainingArgs.Add(arg);
                }
            }

            foreach (var parser in parsers)
            {
                parser.Validate(Errors);
            }

            _args = remainingArgs.ToArray();
        }

        public void ThrowIfNotValid()
        {
            if (Errors.Count > 0)
            {
                throw new CommandLineValidationException(Errors.ToArray());
            }
        }

        public void AddFreeArguments()
        {
            if (_args.Length > 0)
            {
                foreach (var arg in _args)
                {
                    UnconsumedArgs.Add(arg);
                }
            }
        }
    }
}