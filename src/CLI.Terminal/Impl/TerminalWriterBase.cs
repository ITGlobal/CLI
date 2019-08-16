#if !NET45
using System;
using System.Globalization;
#endif

namespace ITGlobal.CommandLine.Impl
{
    internal abstract class TerminalWriterBase : ITerminalWriter
    {
        public void Write(ColoredString str)
        {
            var i = str.Text.IndexOf('\n');
            if (i > 0)
            {
                var s = new ColoredString(
                    str.Text.Substring(0, i),
                    str.ForegroundColor,
                    str.BackgroundColor
                );
                var rem = new ColoredString(
                    str.Text.Substring(i),
                    str.ForegroundColor,
                    str.BackgroundColor
                );

                WriteImpl(s);
                Write(rem);
            }
            else
            {
                WriteImpl(str);
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
