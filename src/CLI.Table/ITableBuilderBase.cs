using System.IO;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Base interface for table builders
    /// </summary>
    [PublicAPI]
    public interface ITableBuilderBase
    {
        /// <summary>
        ///     Draws table to specified writer
        /// </summary>
        [PublicAPI]
        void Draw([NotNull] TextWriter writer, int? maxWidth = null);
    }
}