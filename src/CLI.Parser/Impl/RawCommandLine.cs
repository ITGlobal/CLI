using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class RawCommandLine
    {
        private readonly CommandLineToken[] _tokens;
        private readonly bool[] _consumed;
        
        public RawCommandLine(CommandLineToken[] tokens)
        {
            _tokens = tokens;
            _consumed = new bool[tokens.Length];
            Errors = new List<string>();
        }

        public IList<string> Errors { get; }

        public bool ConsumeSwitch(char name)
        {
            for (var i = 0; i < _tokens.Length; i++)
            {
                if (IsConsumed(i))
                {
                    continue;
                }

                var token = _tokens[i];
                switch (token.Type)
                {
                    case CommandLineTokenType.ShortName:
                        if (token.Value.Length == 1 && token.Value[0] == name)
                        {
                            Consume(i);
                            return true;
                        }
                        break;
                }
            }

            return false;
        }

        public bool ConsumeSwitch(string name)
        {
            for (var i = 0; i < _tokens.Length; i++)
            {
                if (IsConsumed(i))
                {
                    continue;
                }

                var token = _tokens[i];
                switch (token.Type)
                {
                    case CommandLineTokenType.LongName:
                        if (token.Value == name)
                        {
                            Consume(i);
                            return true;
                        }
                        break;
                }
            }

            return false;
        }

        public string ConsumeOption(char name)
        {
            for (var i = 0; i < _tokens.Length; i++)
            {
                if (IsConsumed(i))
                {
                    continue;
                }

                var token = _tokens[i];
                switch (token.Type)
                {
                    case CommandLineTokenType.ShortName:
                        if (token.Value.Length == 1 && token.Value[0] == name)
                        {
                            for (var j = i + 1; j < _tokens.Length; j++)
                            {
                                if (IsConsumed(j))
                                {
                                    continue;
                                }

                                if (_tokens[j].Type == CommandLineTokenType.Value)
                                {
                                    var value = _tokens[j].Value;
                                    Consume(i);
                                    Consume(j);
                                    return value;
                                }

                                break;
                            }
                        }
                        break;
                }
            }

            return null;
        }

        public string ConsumeOption(string name)
        {
            for (var i = 0; i < _tokens.Length; i++)
            {
                if (IsConsumed(i))
                {
                    continue;
                }

                var token = _tokens[i];
                switch (token.Type)
                {
                    case CommandLineTokenType.LongName:
                        if (token.Value == name)
                        {
                            for (var j = i + 1; j < _tokens.Length; j++)
                            {
                                if (IsConsumed(j))
                                {
                                    continue;
                                }

                                if (_tokens[j].Type == CommandLineTokenType.Value)
                                {
                                    var value = _tokens[j].Value;
                                    Consume(i);
                                    Consume(j);
                                    return value;
                                }

                                break;
                            }
                        }
                        break;
                }
            }

            return null;
        }

        public string ConsumeArgument(int position)
        {
            var index = 0;
            for (var i = 0; i < _tokens.Length; i++)
            {
                if (IsConsumed(i))
                {
                    continue;
                }

                var token = _tokens[i];
                switch (token.Type)
                {
                    case CommandLineTokenType.Value:
                        if (index == position)
                        {
                            Consume(i);
                            return token.Value;
                        }
                        index++;
                        break;
                }
            }

            return null;
        }

        public string[] GetUnconsumedOptions()
        {
            return Iterator().Distinct().ToArray();

            IEnumerable<string> Iterator()
            {
                for (var i = 0; i < _tokens.Length; i++)
                {
                    if (IsConsumed(i))
                    {
                        continue;
                    }

                    var token = _tokens[i];
                    switch (token.Type)
                    {
                        case CommandLineTokenType.ShortName:
                            yield return $"-{token.Value}";
                            break;
                        case CommandLineTokenType.LongName:
                            yield return $"--{token.Value}";
                            break;
                    }
                }
            }
        }

        public string[] GetUnconsumedArguments()
        {
            return Iterator().Distinct().ToArray();

            IEnumerable<string> Iterator()
            {
                for (var i = 0; i < _tokens.Length; i++)
                {
                    if (IsConsumed(i))
                    {
                        continue;
                    }

                    var token = _tokens[i];
                    switch (token.Type)
                    {
                        case CommandLineTokenType.Value:
                            yield return token.Value;
                            break;
                    }
                }
            }
        }

        public void AddError(string message) => Errors.Add(message);

        private bool IsConsumed(int index) => _consumed[index];
        private void Consume(int index) => _consumed[index] = true;
    }
}