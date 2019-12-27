#if !NET45
using System;
using System.Globalization;
#endif

namespace ITGlobal.CommandLine.Impl
{
    internal abstract class TerminalWriterBase : ITerminalWriter
    {
        private static readonly AnsiString LF = new AnsiString(new[] { new AnsiChar('\n'), });

        public void Write(AnsiString str)
        {
            // Split input string into separate colored strings
            // Each of them is guarantied not to contain any ANSI escape sequences
            
            var parts = str.SplitIntoChunks();
            foreach (var s in parts)
            {
                Write(s);
            }
        }

#if !NET45
        public void Write(FormattableString str)
        {
            var tokens = StringFormatParser.Tokenize(str.Format, str.GetArguments());
            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case StringFormatParser.TokenType.Plain:
                        Write((AnsiString)(string)token.Value);
                        break;

                    case StringFormatParser.TokenType.Field:
                        if (token.Value is AnsiString cs)
                        {
                            Write(cs);
                        }
                        else if (token.Value is IFormattable formattable)
                        {
                            Write((AnsiString)formattable.ToString(token.Format, CultureInfo.InvariantCulture));
                        }
                        else if (token.Value != null)
                        {
                            Write((AnsiString)token.Value.ToString());
                        }
                        break;
                }
            }
        }
#endif

        public void Write(params AnsiString[] strs)
        {
            foreach (var str in strs)
            {
                Write(str);
            }
        }

#if !NET45
        public void WriteLine(FormattableString str)
        {
            Write(str);
            WriteLine();
        }
#endif

        public void WriteLine(AnsiString str)
        {
            Write(str);
            WriteLine();
        }

        public void WriteLine(params AnsiString[] strs)
        {
            foreach (var str in strs)
            {
                Write(str);
            }

            WriteLine();
        }

        public void WriteLine()
        {
            Write(LF);
        }

        public abstract void Write(AnsiString.Chunk str);
    }
}
