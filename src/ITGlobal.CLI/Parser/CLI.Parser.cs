using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        /// <summary>
        ///     Creates a command line parser
        /// </summary>
        [PublicAPI, NotNull]
        public static ICommandParser Parser() => new CommandParser();

        internal static string GetAliasFor(string name)
        {
            if (name.All(char.IsLetterOrDigit) && name.Length == 1)
            {
                return "-" + name;
            }

            return "--" + name;
        }
    }
}
