using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line command creator
    /// </summary>
    [PublicAPI]
    public interface ICliCommandRoot
    {
        /// <summary>
        ///     Add a command line command
        /// </summary>
        CliCommand Command(string name, string helpText = null, bool hidden = false);
    }
}