using System.IO;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table renderer
    /// </summary>
    [PublicAPI]
    public interface ITableRenderer
    {
        /// <summary>
        ///     Render a table
        /// </summary>
        void Render([NotNull] TableModel model, [NotNull] TextWriter output, int? maxWidth);
    }
}