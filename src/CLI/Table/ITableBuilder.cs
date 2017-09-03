using System;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Console table builder
    /// </summary>
    /// <typeparam name="T">
    ///     Row item type
    /// </typeparam>
    [PublicAPI]
    public interface ITableBuilder<out T>
    {
        /// <summary>
        ///     Sets a table title
        /// </summary>
        [PublicAPI, NotNull]
        ITableBuilder<T> Title(string title);

        /// <summary>
        ///     Turn table title on or off
        /// </summary>
        [PublicAPI, NotNull]
        ITableBuilder<T> PrintTitle(bool enable = true);

        /// <summary>
        ///     Turn table column headers on or off
        /// </summary>
        [PublicAPI, NotNull]
        ITableBuilder<T> PrintHeader(bool enable = true);

        /// <summary>
        ///     Turn table paging on or off
        /// </summary>
        [PublicAPI, NotNull]
        ITableBuilder<T> EnablePaging(bool enable = true);

        /// <summary>
        ///     Defines a table column
        /// </summary>
        /// <param name="title">
        ///     Column header
        /// </param>
        /// <param name="property">
        ///     Value selector
        /// </param>
        /// <param name="fg">
        ///     Foreground selector
        /// </param>
        /// <param name="bg">
        ///     Background selector
        /// </param>
        /// <param name="maxWidth">
        ///     Max column width
        /// </param>
        [PublicAPI, NotNull]
        ITableBuilder<T> Column(
            string title,
            Func<T, string> property,
            Func<T, ConsoleColor?> fg = null,
            Func<T, ConsoleColor?> bg = null,
            int? maxWidth = null
            );
    }
}