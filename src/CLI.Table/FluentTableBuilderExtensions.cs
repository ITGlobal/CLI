using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    [PublicAPI]
    public static class FluentTableBuilderExtensions
    {
        /// <summary>
        ///     Add a table title
        /// </summary>
        [NotNull]
        public static IFluentTableBuilder Title(this IFluentTableBuilder builder, string text)
            => builder.Title(text.Colored());

        /// <summary>
        ///     Add a table headers
        /// </summary>
        [NotNull]
        public static IFluentTableBuilder Headers(this IFluentTableBuilder builder, params string[] headers)
            => builder.Headers(headers.Select(_ => _.Colored()).ToArray());

        /// <summary>
        ///     Add a table row
        /// </summary>
        [NotNull]
        public static IFluentTableBuilder Add(this IFluentTableBuilder builder, params string[] cells)
            => builder.Add(cells.Select(_ => _.Colored()).ToArray());

        /// <summary>
        ///     Add a table footer
        /// </summary>
        [NotNull]
        public static IFluentTableBuilder Footer(this IFluentTableBuilder builder, string text)
            => builder.Footer(text.Colored());
    }
}