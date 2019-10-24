using System;
using System.Threading;
#if !NET45
using System.Globalization;
#endif

namespace ITGlobal.CommandLine.Impl
{
    internal abstract class TerminalWriterBase : ITerminalWriter
    {
        private readonly ThreadLocal<AnsiSplitter> _ansiSplitter =
            new ThreadLocal<AnsiSplitter>(() => new AnsiSplitter());

        public void Write(ColoredString str)
        {
            // Split input string into separate colored strings
            // Each of them is guarantied not to contain any ANSI escape sequences
            var splitter = _ansiSplitter.Value;
            var parts = splitter.Split(str);
            foreach (var s in parts)
            {
                WriteImpl(s);
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
                        Write((ColoredString)(string)token.Value);
                        break;

                    case StringFormatParser.TokenType.Field:
                        if (token.Value is ColoredString cs)
                        {
                            Write(cs);
                        }
                        else if (token.Value is IFormattable formattable)
                        {
                            Write((ColoredString)formattable.ToString(token.Format, CultureInfo.InvariantCulture));
                        }
                        else if (token.Value != null)
                        {
                            Write((ColoredString)token.Value.ToString());
                        }
                        break;
                }
            }
        }
#endif

        public void Write(params ColoredString[] strs)
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

        public void WriteLine(ColoredString str)
        {
            Write(str);
            WriteLine();
        }

        public void WriteLine(params ColoredString[] strs)
        {
            foreach (var str in strs)
            {
                Write(str);
            }

            WriteLine();
        }

        public void WriteLine()
        {
            Write(ColoredString.LF);
        }

        protected abstract void WriteImpl(ColoredString str);
    }
}
