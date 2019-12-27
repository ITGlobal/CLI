using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     A table style for "Plain" renderer
    /// </summary>
    public interface IPlainTableStyle
    {
        #region Color styles
        
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

        #endregion

        #region Drawing options
        
        /// <summary>
        ///     Should draw table headers
        /// </summary>
        bool DrawHeaders { get; }

        /// <summary>
        ///     Should draw table headers in upper-case
        /// </summary>
        bool UppercaseHeaders { get; }

        /// <summary>
        ///     Should draw an underline under table title
        /// </summary>
        bool UnderlineTitle { get; }

        /// <summary>
        ///     Should draw an underline under table headers
        /// </summary>
        bool UnderlineHeaders { get; }

        #endregion
    }
}