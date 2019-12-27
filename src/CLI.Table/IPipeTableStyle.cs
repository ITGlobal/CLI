using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     A table style for "Pipe" renderer
    /// </summary>
    public interface IPipeTableStyle
    {
        /// <summary>
        ///     A style for table body
        /// </summary>
        [NotNull]
        IColoredStringStyle BodyColors { get; }

        /// <summary>
        ///     A style for table headers
        /// </summary>
        [NotNull]
        IColoredStringStyle HeaderColors { get; }

        /// <summary>
        ///     A style for table title row
        /// </summary>
        [NotNull]
        IColoredStringStyle TitleColors { get; }

        /// <summary>
        ///     A style for table footer row
        /// </summary>
        [NotNull]
        IColoredStringStyle FooterColors { get; }

        /// <summary>
        ///     A style for table frame
        /// </summary>
        [NotNull]
        IColoredStringStyle FrameColors { get; }
    }
}