using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Extension methods for <see cref="IFluentTableRowBuilder"/>
    /// </summary>
    [PublicAPI]
    public static class FluentTableRowBuilderExtensions
    {
        /// <summary>
        ///     Adds a cell into a row
        /// </summary>
        [NotNull]
        public static IFluentTableRowBuilder Add([NotNull] this IFluentTableRowBuilder builder, [NotNull] string text, TableCellAlignment? alignment = null)
            => builder.Add(text.Colored(), alignment);

        /// <summary>
        ///     Adds a left-aligned cell into a row
        /// </summary>
        [NotNull]
        public static IFluentTableRowBuilder AddLeftAlign([NotNull] this IFluentTableRowBuilder builder, AnsiString text) 
            => builder.Add(text, TableCellAlignment.Left);

        /// <summary>
        ///     Adds a right-aligned cell into a row
        /// </summary>
        [NotNull]
        public static IFluentTableRowBuilder AddRightAlign([NotNull] this IFluentTableRowBuilder builder, AnsiString text)
            => builder.Add(text, TableCellAlignment.Right);

        /// <summary>
        ///     Adds a middle-aligned cell into a row
        /// </summary>
        [NotNull]
        public static IFluentTableRowBuilder AddMiddleAlign([NotNull] this IFluentTableRowBuilder builder, AnsiString text)
            => builder.Add(text, TableCellAlignment.Middle);

        /// <summary>
        ///     Adds a left-aligned cell into a row
        /// </summary>
        [NotNull]
        public static IFluentTableRowBuilder AddLeftAlign([NotNull] this IFluentTableRowBuilder builder, [NotNull] string text)
            => builder.Add(text, TableCellAlignment.Left);

        /// <summary>
        ///     Adds a right-aligned cell into a row
        /// </summary>
        [NotNull]
        public static IFluentTableRowBuilder AddRightAlign([NotNull] this IFluentTableRowBuilder builder, [NotNull] string text)
            => builder.Add(text, TableCellAlignment.Right);

        /// <summary>
        ///     Adds a middle-aligned cell into a row
        /// </summary>
        [NotNull]
        public static IFluentTableRowBuilder AddMiddleAlign([NotNull] this IFluentTableRowBuilder builder, [NotNull] string text)
            => builder.Add(text, TableCellAlignment.Middle);
    }
}