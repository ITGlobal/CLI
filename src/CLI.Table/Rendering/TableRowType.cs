using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table row type
    /// </summary>
    [PublicAPI]
    public enum TableRowType
    {
        /// <summary>
        ///     Body row
        /// </summary>
        Body,

        /// <summary>
        ///     Title row
        /// </summary>
        Title,

        /// <summary>
        ///     Header row
        /// </summary>
        Header,

        /// <summary>
        ///     Footer row
        /// </summary>
        Footer,

        /// <summary>
        ///     Separator row
        /// </summary>
        Separator,
    }
}