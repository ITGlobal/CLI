using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal static class CommandLineTokenizer
    {
        public static string[] GetOptionNames(CliParserFlags flags, char? shortName, string longName)
        {
            return Iterator().ToArray();

            IEnumerable<string> Iterator()
            {
                var allowPosixNotation = flags.HasFlag(CliParserFlags.PosixNotation);
                var allowWindowsNotation = flags.HasFlag(CliParserFlags.WindowsNotation);

                if (shortName != null)
                {
                    if (allowPosixNotation)
                    {
                        yield return $"-{shortName.Value}";
                    }

                    if (allowWindowsNotation)
                    {
                        yield return $"/{shortName.Value}";
                    }
                }

                if (longName != null)
                {
                    if (allowPosixNotation)
                    {
                        yield return $"--{longName}";
                    }

                    if (allowWindowsNotation)
                    {
                        yield return $"/{longName}";
                    }
                }
            }
        }

        public static CommandLineToken[] Tokenize(CliParserFlags flags, params string[] args)
        {
            var allowPosixNotation = flags.HasFlag(CliParserFlags.PosixNotation);
            var allowWindowsNotation = flags.HasFlag(CliParserFlags.WindowsNotation);
            var allowColonSeparatedValues = flags.HasFlag(CliParserFlags.ColonSeparatedValues);
            var allowEqualitySignSeparatedValues = flags.HasFlag(CliParserFlags.EqualitySignSeparatedValues);
            var tokens = new List<CommandLineToken>();
            TokenizeImpl(
                allowPosixNotation, allowWindowsNotation, allowColonSeparatedValues,
                allowEqualitySignSeparatedValues,
                args,
                tokens);
            return tokens.ToArray();
        }

        private static void TokenizeImpl(
           bool allowPosixNotation,
           bool allowWindowsNotation,
           bool allowColonSeparatedValues,
           bool allowEqualitySignSeparatedValues,
           string[] args,
           List<CommandLineToken> tokens
           )
        {
            for (var index = 0; index < args.Length; index++)
            {
                var arg = args[index];
                switch (arg)
                {
                    case null:
                    case "":
                        continue;

                    case "--" when allowPosixNotation:
                        // everything after "--" is a value, not a option key
                        index++;
                        for (; index < args.Length; index++)
                        {
                            tokens.Add(CommandLineToken.CreateValue(args[index]));
                        }
                        return;

                    default:
                        if (allowPosixNotation && arg.Length > 2 && arg[0] == '-' && arg[1] == '-')
                        {
                            // Options that start with "--" are usually long-named options
                            ProcessLongName(
                                arg.Substring(2),
                                tokens,
                                allowColonSeparatedValues,
                                allowEqualitySignSeparatedValues
                            );
                        }
                        else if (allowPosixNotation && arg.Length > 1 && arg[0] == '-')
                        {
                            // Options that start with "-" are usually short-named options
                            arg = arg.Substring(1);
                            if (!TryProcessAsSeparatedValueArgument(
                                arg,
                                tokens,
                                allowColonSeparatedValues,
                                allowEqualitySignSeparatedValues))
                            {
                                foreach (var c in arg)
                                {
                                    tokens.Add(CommandLineToken.CreateShortName(c));
                                }
                            }

                        }
                        else if (allowWindowsNotation && arg.Length > 1 && arg[0] == '/')
                        {
                            // Options that start with "/" might be either long-named or short-named options
                            if (arg.Length == 2)
                            {
                                tokens.Add(CommandLineToken.CreateShortName(arg[1]));
                            }
                            else
                            {
                                ProcessLongName(
                                    arg.Substring(1),
                                    tokens,
                                    allowColonSeparatedValues,
                                    allowEqualitySignSeparatedValues
                                );
                            }
                        }
                        else
                        {
                            // Everything else is a value
                            tokens.Add(CommandLineToken.CreateValue(arg));
                        }
                        break;
                }
            }
        }

        private static void ProcessLongName(
            string arg,
            List<CommandLineToken> tokens,
            bool allowColonSeparatedValues,
            bool allowEqualitySignSeparatedValues)
        {
            if (TryProcessAsSeparatedValueArgument(
                arg,
                tokens,
                allowColonSeparatedValues,
                allowEqualitySignSeparatedValues))
            {
                return;
            }

            tokens.Add(CommandLineToken.CreateLongName(arg));
        }

        private static bool TryProcessAsSeparatedValueArgument(
            string arg,
            List<CommandLineToken> tokens,
            bool allowColonSeparatedValues,
            bool allowEqualitySignSeparatedValues)
        {
            if (allowEqualitySignSeparatedValues)
            {
                // Handle values like "--key=value" or "/key=value"
                var i = arg.IndexOf('=');
                if (i > 0)
                {
                    var name = arg.Substring(0, i);
                    var value = arg.Substring(i + 1);

                    if (name.Length == 1)
                    {
                        tokens.Add(CommandLineToken.CreateShortName(name[0]));
                    }
                    else
                    {
                        tokens.Add(CommandLineToken.CreateLongName(name));
                    }

                    tokens.Add(CommandLineToken.CreateValue(value));
                    return true;
                }
            }

            if (allowColonSeparatedValues)
            {
                // Handle values like "--key:value" or "/key:value"
                var i = arg.IndexOf(':');
                if (i > 0)
                {
                    var name = arg.Substring(0, i);
                    var value = arg.Substring(i + 1);

                    if (name.Length == 1)
                    {
                        tokens.Add(CommandLineToken.CreateShortName(name[0]));
                    }
                    else
                    {
                        tokens.Add(CommandLineToken.CreateLongName(name));
                    }

                    tokens.Add(CommandLineToken.CreateValue(value));
                    return true;
                }
            }

            return false;
        }
    }
}