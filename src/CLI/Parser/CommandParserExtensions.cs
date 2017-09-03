using System.Reflection;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A few extension method for <see cref="ICommandParser"/>
    /// </summary>
    [PublicAPI]
    public static class CommandParserExtensions
    {
        /// <summary>
        ///     Sets <see cref="ICommandParser.Title"/> and <see cref="ICommandParser.Version"/> parameters from assembly attributes
        /// </summary>
        [PublicAPI, NotNull]
        public static ICommandParser FromAssembly([NotNull] this ICommandParser parser, [NotNull] Assembly assembly)
        {
            {
                var attr = assembly.GetCustomAttribute<AssemblyProductAttribute>();
                if (attr != null)
                {
                    parser.Title(attr.Product);
                }
            }

            {
                var attr = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
                if (attr != null)
                {
                    parser.Version(attr.InformationalVersion);
                }
            }

            return parser;
        }
    }
}