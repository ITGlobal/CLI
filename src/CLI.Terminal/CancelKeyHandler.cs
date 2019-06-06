using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     CtrlC/SIGINT handler function
    /// </summary>
    [PublicAPI]
    public delegate bool CancelKeyHandler();
}