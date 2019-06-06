using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    [PublicAPI]
    public static class FluentTableRowBuilderExtensions
    {
        [NotNull]
        public static IFluentTableRowBuilder Add([NotNull] this IFluentTableRowBuilder builder, [NotNull] string text, TableCellAlignment? alignment = null)
            => builder.Add(text.Colored(), alignment);

        [NotNull]
        public static IFluentTableRowBuilder AddLeftAlign([NotNull] this IFluentTableRowBuilder builder, ColoredString text) 
            => builder.Add(text, TableCellAlignment.Left);

        [NotNull]
        public static IFluentTableRowBuilder AddRightAlign([NotNull] this IFluentTableRowBuilder builder, ColoredString text)
            => builder.Add(text, TableCellAlignment.Right);

        [NotNull]
        public static IFluentTableRowBuilder AddMiddleAlign([NotNull] this IFluentTableRowBuilder builder, ColoredString text)
            => builder.Add(text, TableCellAlignment.Middle);

        [NotNull]
        public static IFluentTableRowBuilder AddLeftAlign([NotNull] this IFluentTableRowBuilder builder, [NotNull] string text)
            => builder.Add(text, TableCellAlignment.Left);

        [NotNull]
        public static IFluentTableRowBuilder AddRightAlign([NotNull] this IFluentTableRowBuilder builder, [NotNull] string text)
            => builder.Add(text, TableCellAlignment.Right);

        [NotNull]
        public static IFluentTableRowBuilder AddMiddleAlign([NotNull] this IFluentTableRowBuilder builder, [NotNull] string text)
            => builder.Add(text, TableCellAlignment.Middle);
    }
}