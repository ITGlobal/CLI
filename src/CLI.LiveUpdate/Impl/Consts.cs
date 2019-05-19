using System.Diagnostics.CodeAnalysis;

namespace ITGlobal.CommandLine.Impl
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class Consts
    {
        public const int SPINNER_SLEEP_TIME = 50;
        public static readonly string[] SPINNER_CHARS = { "\\", "|", "/", "-" };
        public const int PROGRESS_BAR_LABEL_WIDTH = 24;
        public const char GLYPH_FILL = '\u2588';
        public const char GLYPH_EMPTY = '\u2592';
        public const char GLYPH_RECT = '\u25AA';
    }
}