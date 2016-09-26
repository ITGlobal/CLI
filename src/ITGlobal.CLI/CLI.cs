using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     An entry point for every command line utility in library
    /// </summary>
    [PublicAPI, SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        internal const int PROGRESS_BAR_LABEL_WIDTH = 24;
        
        internal const int SPINNER_SLEEP_TIME = 50;

        internal static readonly char[] SPINNER_CHARS = { '\\', '|', '/', '-' };

        internal static readonly string[] EmptyArray = new string[0];

        internal const string ELLIPSIS = "...";
    }
}
