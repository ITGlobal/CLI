using System;
using System.Diagnostics.Contracts;
using System.Text;
using ITGlobal.CommandLine.Impl;

namespace ITGlobal.CommandLine
{
    partial struct AnsiString
    {
        /// <inheritdoc />
        [Pure]
        public override string ToString()
        {
            return ToString(null, null);
        }

        [Pure]
        private string ToString(ConsoleColor? defaultForegroundColor, ConsoleColor? defaultBackgroundColor)
        {
            ConsoleColor? foregroundColor = default, backgroundColor = default;

            var sb = new StringBuilder();

            var ansiAttributesEverApplied = false;

            foreach (var (c, fg, bg) in _chars)
            {
                var ansiAttributesChanged = false;
                if (foregroundColor != fg)
                {
                    foregroundColor = fg;
                    ansiAttributesChanged = true;
                }
                if (backgroundColor != bg)
                {
                    backgroundColor = bg;
                    ansiAttributesChanged = true;
                }

                if (ansiAttributesChanged)
                {
                    if (foregroundColor != null || backgroundColor != null)
                    {
                        var sgr = Ansi.SGR(foregroundColor ?? defaultForegroundColor, backgroundColor ?? defaultBackgroundColor);
                        sb.Append(sgr);
                    }

                    ansiAttributesEverApplied = true;
                }

                sb.Append(c);
            }

            if (ansiAttributesEverApplied)
            {
                sb.Append(Ansi.SGR_DEFAULT);
            }

            return sb.ToString();
        }

        private string ToPlainString()
        {
            var sb = new StringBuilder();

            foreach (var (c, _, _) in _chars)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}