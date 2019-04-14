using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal wrapper
    /// </summary>
    [PublicAPI]
    public interface ITerminal
    {
        /// <summary>
        ///     Terminal standard input wrapper
        /// </summary>
        [NotNull]
        ITerminalInput Stdin { get; }

        /// <summary>
        ///     Terminal standard output wrapper
        /// </summary>
        [NotNull]
        ITerminalOutput Stdout { get; }

        /// <summary>
        ///     Terminal standard error wrapper
        /// </summary>
        [NotNull]
        ITerminalOutput Stderr { get; }
    }
}