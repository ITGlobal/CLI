using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class StringFormatParser
    {
        public enum TokenType
        {
            Plain,
            Field
        }

        public struct Token
        {
            public object Value;
            public int Padding;
            public string Format;
            public TokenType Type;

            public static Token Plain(string str)
            {
                return new Token
                {
                    Value = str,
                    Type = TokenType.Plain
                };
            }

            public static Token Field(object value, int padding, string format)
            {
                return new Token
                {
                    Value = value,
                    Type = TokenType.Field,
                    Padding = padding,
                    Format = format
                };
            }

            public override string ToString()
            {
                switch (Type)
                {
                    case TokenType.Plain:
                        return $"Plain('{Value}')";
                    case TokenType.Field:
                        return $"Field('{Value}', padding: {Padding}, format: '{Format}')";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static Token[] Tokenize(string format, object[] args)
        {
            var tokens = TokenizeIterator(format, args).ToArray();
            return tokens;
        }

        private static IEnumerable<Token> TokenizeIterator(string format, object[] args)
        {
            var sb = PlainTokenStringBuilder.Value;
            sb.Clear();

            for (var i = 0; i < format.Length; i++)
            {
                if (format[i] == '{' && i < format.Length - 1 && format[i + 1] == '{')
                {
                    continue;
                }

                if (format[i] == '}' && i < format.Length - 1 && format[i + 1] == '}')
                {
                    continue;
                }

                if (format[i] == '{' && TryReadField(format, args, ref i, out var token))
                {
                    if (sb.Length > 0)
                    {
                        yield return Token.Plain(sb.ToString());
                        sb.Clear();
                    }

                    yield return token;
                    continue;
                }

                sb.Append(format[i]);
            }

            if (sb.Length > 0)
            {
                yield return Token.Plain(sb.ToString());
                sb.Clear();
            }
        }

        private enum FieldParseMode { Index, Padding, Format, Done }

        private static readonly ThreadLocal<StringBuilder> PlainTokenStringBuilder
            = new ThreadLocal<StringBuilder>(() => new StringBuilder());

        private static readonly ThreadLocal<StringBuilder> FieldTokenStringBuilder
            = new ThreadLocal<StringBuilder>(() => new StringBuilder());

        private static bool TryReadField(string format, object[] args, ref int index, out Token token)
        {
            token = default(Token);

            var sb = FieldTokenStringBuilder.Value;
            sb.Clear();
            var mode = FieldParseMode.Index;

            var argumentIndex = -1;
            var argumentPadding = 0;
            string argumentFormat = null;

            var i = index + 1;
            for (; i < format.Length && mode != FieldParseMode.Done; i++)
            {
                var ch = format[i];
                if (i == index + 1 && ch == '{')
                {
                    // Not a format field
                    return false;
                }

                switch (mode)
                {
                    // Parse argument index
                    case FieldParseMode.Index:
                        if (char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (char.IsDigit(ch))
                        {
                            sb.Append(ch);
                            continue;
                        }

                        if (ch == ':')
                        {
                            mode = FieldParseMode.Format;
                        }
                        else if (ch == ',')
                        {
                            mode = FieldParseMode.Padding;
                        }
                        else if (ch == '}')
                        {
                            mode = FieldParseMode.Done;
                        }
                        else
                        {
                            // Malformed format field
                            return false;
                        }

                        if (mode != FieldParseMode.Index)
                        {
                            if (!int.TryParse(sb.ToString(), out argumentIndex))
                            {
                                // Malformed format field
                                return false;
                            }

                            sb.Clear();
                        }

                        break;

                    // Parse padding value
                    case FieldParseMode.Padding:
                        if (char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (char.IsDigit(ch) || ch == '-' || ch == '+')
                        {
                            sb.Append(ch);
                            continue;
                        }

                        if (ch == ':')
                        {
                            mode = FieldParseMode.Format;
                        }
                        else if (ch == '}')
                        {
                            mode = FieldParseMode.Done;
                        }
                        else
                        {
                            // Malformed format field
                            return false;
                        }

                        if (mode != FieldParseMode.Padding)
                        {
                            if (!int.TryParse(sb.ToString(), out argumentPadding))
                            {
                                // Malformed format field
                                return false;
                            }

                            sb.Clear();
                        }
                        break;

                    // Parse format
                    case FieldParseMode.Format:
                        if (ch == '}')
                        {
                            mode = FieldParseMode.Done;
                        }
                        else
                        {
                            sb.Append(ch);
                        }

                        if (mode != FieldParseMode.Format)
                        {
                            argumentFormat = sb.ToString();
                            sb.Clear();
                        }

                        break;

                    case FieldParseMode.Done:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (argumentIndex < 0 || argumentIndex >= args.Length)
            {
                // Index out of range
                return false;
            }

            token = Token.Field(args[argumentIndex], argumentPadding, argumentFormat);
            index = i - 1;

            // End of string reached
            return true;
        }
    }
}