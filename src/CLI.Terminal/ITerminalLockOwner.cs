using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal lock owner
    /// </summary>
    [PublicAPI]
    public interface ITerminalLockOwner
    {
        /// <summary>
        ///     Acquires terminal output lock
        /// </summary>
        void Begin();

        /// <summary>
        ///     Writes a character to standard output.
        ///     This method is always called after <see cref="Begin"/> and before <see cref="End"/> methods.
        /// </summary>
        void WriteOutput(AnsiChar c);

        /// <summary>
        ///     Writes a character to standard error.
        ///     This method is always called after <see cref="Begin"/> and before <see cref="End"/> methods.
        /// </summary>
        void WriteError(AnsiChar c);

        /// <summary>
        ///     Releases terminal output lock
        /// </summary>
        void End();
    }
}