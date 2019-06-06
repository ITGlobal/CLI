using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Default exit codes
    /// </summary>
    [PublicAPI]
    public static class ExitCodes
    {
        public const int UnknownOptions = -1001;
        public const int UnknownArguments = -1002;
        public const int InvalidInput = -1003;
    }
}