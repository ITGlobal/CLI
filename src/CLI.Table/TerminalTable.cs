using System.Collections.Generic;
using ITGlobal.CommandLine.Table.Impl;
using ITGlobal.CommandLine.Table.Rendering;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Terminal table builder
    /// </summary>
    [PublicAPI]
    public static class TerminalTable
    {
        /// <summary>
        ///     Creates new fluent table builder
        /// </summary>
        [NotNull]
        public static IFluentTableBuilder CreateFluent(ITableRenderer renderer = null)
        {
            return new FluentTableBuilderImpl(renderer ?? TableRenderer.Default);
        }

        /// <summary>
        ///     Creates new fluent table builder
        /// </summary>
        [NotNull]
        public static IGeneratedTableBuilder<T> CreateGenerated<T>([NotNull] IEnumerable<T> rows, ITableRenderer renderer = null)
        {
            return new GeneratedTableBuilderImpl<T>(rows, renderer ?? TableRenderer.Default);
        }
    }
}
