using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table row type
    /// </summary>
    [PublicAPI]
    public enum TableRowType
    {
        Body,
        Title,
        Header,
        Footer,
        Separator,
    }
}