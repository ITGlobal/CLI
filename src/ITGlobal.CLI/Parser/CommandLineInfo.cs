using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class CommandLineInfo
    {
        private string[] _args;
        private string _freeRemainder = "";

        public CommandLineInfo(string[] args)
        {
            _args = args;
        }

        public string FreeRemainder => _freeRemainder;

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
                    if (parser.TryConsume(_args, ref index))
                    {
                        isConsumed = true;
                        break;
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
                        _freeRemainder += _args[index];
                    }
                    break;
                }

                var isConsumed = false;
                foreach (var parser in parsers)
                {
                    if (parser.TryConsumeAt(_args, index))
                    {
                        isConsumed = true;
                        break;
                    }
                }

                if (!isConsumed)
                {
                    remainingArgs.Add(arg);
                }
            }

            var errors = new List<string>();
            foreach (var parser in parsers)
            {
                parser.Validate(errors);
            }

            if (errors.Count > 0)
            {
                throw new CommandLineValidationException(errors.ToArray());
            }

            _args = remainingArgs.ToArray();
        }

        public void AddFreeArguments()
        {
            if (_args.Length > 0)
            {
                _freeRemainder = string.Join(" ", _args) + " " + _freeRemainder;
            }
        }
    }
}