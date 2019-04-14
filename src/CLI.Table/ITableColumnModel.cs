using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Table column model
    /// </summary>
    [PublicAPI]
    public interface ITableColumnModel<T>
    {
        /// <summary>
        ///     Column header
        /// </summary>
        [NotNull]
        string Header { get; }

        /// <summary>
        ///     Column's max wdith
        /// </summary>
        int MaxWidth { get; set; }

        /// <summary>
        ///     Gets a cell text
        /// </summary>
        [NotNull]
        string GetText(T item);

        /// <summary>
        ///     Gets a cell foreground color
        /// </summary>
        ConsoleColor? GetForegroundColor(T item);

        /// <summary>
        ///     Gets a cell background color
        /// </summary>
        ConsoleColor? GetBackgroundColor(T item);
    }
}