using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A context for <see cref="CliHook"/>/<see cref="CliAsyncHandler"/>
    /// </summary>
    [PublicAPI]
    public interface IHookCliContext : ICliContext
    {
        /// <summary>
        ///     Suppress application logo
        /// </summary>
        void SuppressLogo(bool suppress = true);
    }
}