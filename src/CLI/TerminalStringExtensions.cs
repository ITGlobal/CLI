using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class TerminalStringExtensions
    {
        public static TerminalString WithForeground(this TerminalString ts, ConsoleColor? foreground)
        {
            return new TerminalString(ts.Value, foreground, ts.BackgroundColor);
        }

        public static TerminalString WithBackground(this TerminalString ts, ConsoleColor? background)
        {
            return new TerminalString(ts.Value, ts.ForegroundColor, background);
        }

        public static TerminalString WithColors(this TerminalString ts, ConsoleColor? foreground, ConsoleColor? background)
        {
            return new TerminalString(ts.Value, foreground, background);
        }

        public static TerminalString WithForeground([NotNull] this string str, ConsoleColor? foreground)
        {
            return new TerminalString(str, foreground, null);
        }

        public static TerminalString WithBackground([NotNull] this string str, ConsoleColor? background)
        {
            return new TerminalString(str, null, background);
        }

        public static TerminalString WithColors([NotNull] this string str, ConsoleColor? foreground, ConsoleColor? background)
        {
            return new TerminalString(str, foreground, background);
        }
    }
}