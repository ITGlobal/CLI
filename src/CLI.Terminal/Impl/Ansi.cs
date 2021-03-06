using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;

namespace ITGlobal.CommandLine.Impl
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static partial class Ansi
    {
        public const char ESC = (char)0x1B;
        public const char SGR_START = '[';
        public const char SGR_SEP = ';';
        public const char END = 'm';
        
        private static readonly ThreadLocal<StringBuilder> SbLocal =
            new ThreadLocal<StringBuilder>(() => new StringBuilder());

        public static string SGR(ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            if (foregroundColor != null && backgroundColor != null)
            {
                var sgr = SGR(
                    ForegroundColorToAttributes(foregroundColor.Value),
                    BackgroundColorToAttributes(backgroundColor.Value)
                );
                return sgr;
            }

            if (foregroundColor != null)
            {
                var sgr = SGR(
                    ForegroundColorToAttributes(foregroundColor.Value)
                );
                return sgr;
            }

            if (backgroundColor != null)
            {
                var sgr = SGR(
                    BackgroundColorToAttributes(backgroundColor.Value)
                );
                return sgr;
            }

            return string.Empty;
        }

        public static string SGR(AnsiAttributes attribute)
        {
            var sb = SbLocal.Value;
            sb.Clear();

            sb.Append(ESC);
            sb.Append(SGR_START);
            sb.Append((int)attribute);
            sb.Append(END);

            var result = sb.ToString();
            return result;
        }

        public static string SGR(AnsiAttributes attribute1, AnsiAttributes attribute2)
        {
            var sb = SbLocal.Value;
            sb.Clear();

            sb.Append(ESC);
            sb.Append(SGR_START);
            sb.Append((int)attribute1);
            sb.Append(SGR_SEP);
            sb.Append((int)attribute2);
            sb.Append(END);

            var result = sb.ToString();
            return result;
        }

        public static string SGR(params AnsiAttributes[] attributes)
        {
            var sb = SbLocal.Value;
            sb.Clear();

            sb.Append(ESC);
            sb.Append(SGR_START);
            var isFirstAttr = true;
            foreach (var a in attributes)
            {
                if (!isFirstAttr)
                {
                    sb.Append(SGR_SEP);
                }

                sb.Append((int) a);
                isFirstAttr = false;
            }

            sb.Append(END);

            var result = sb.ToString();
            return result;
        }

        public static readonly string SGR_DEFAULT = SGR(AnsiAttributes.ATTR_DEFAULT);

        public const string EL = "\x1b[2K";

        public static string CUU(int i) => $"\x1b[{i}A";

        public static string CUD(int i) => $"\x1b[{i}B";
    }
}