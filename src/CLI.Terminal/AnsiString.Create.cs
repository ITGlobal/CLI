using System;
using System.Linq;
using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    partial struct AnsiString
    {
        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from an ordinary string
        ///     with ANSI escape codes processing
        /// </summary>
        public static AnsiString Create([NotNull] string str)
        {
            return AnsiStringParser.Create(str);
        }

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from an ordinary string
        ///     with ANSI escape codes processing and default colors
        /// </summary>
        public static AnsiString Create([NotNull] string str, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var ansiString = AnsiStringParser.Create(str);
            if (foregroundColor != null || backgroundColor != null)
            {
                for (var i = 0; i < ansiString._chars.Length; i++)
                {
                    var (c, fg, bg) = ansiString._chars[i];
                    ansiString._chars[i] = new AnsiChar(
                        c,
                        fg ?? foregroundColor,
                        bg ?? backgroundColor
                    );
                }
            }

            return ansiString;
        }

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from an array of ordinary strings
        ///     with ANSI escape codes processing
        /// </summary>
        public static AnsiString Create([NotNull] string[] strs)
        {
            return Concat(strs.Select(Create).ToArray());
        }

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from an ordinary string
        ///     without ANSI escape codes processing
        /// </summary>
        public static AnsiString FromString([NotNull] string str)
        {
            return new AnsiString(str.Select(c => new AnsiChar(c)).ToArray());
        }

        internal static AnsiString FromChar(AnsiChar c)
        {
            return new AnsiString(new[] { c });
        }
    }
}
