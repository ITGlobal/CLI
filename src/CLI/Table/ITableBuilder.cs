using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Terminal table builder
    /// </summary>
    /// <typeparam name="T">
    ///     Row item type
    /// </typeparam>
    [PublicAPI]
    public interface ITableBuilder<out T>
    {
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

        /// <summary>
        ///     Draws table to screen
        /// </summary>
        void Draw();
    }
}