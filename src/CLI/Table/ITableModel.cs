using System.Collections.Generic;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Table model
    /// </summary>
    [PublicAPI]
    public interface ITableModel<T>
    {
        /// <summary>
        ///     Table rows
        /// </summary>
        [NotNull]
#if NET40
        IList<T> Rows { get; }
#else
        IReadOnlyList<T> Rows { get; }
#endif


        /// <summary>
        ///     Table columns
        /// </summary>
        [NotNull]
#if NET40
        IList<ITableColumnModel<T>> Columns { get; }
#else
        IReadOnlyList<ITableColumnModel<T>> Columns { get; }
#endif
    }
}