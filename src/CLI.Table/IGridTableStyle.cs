using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     A table style for "Grid" renderer
    /// </summary>
    public interface IGridTableStyle
    {
        #region Color styles

        /// <summary>
        ///     A style for table frame
        /// </summary>
        [NotNull]
        IColoredStringStyle FrameColors { get; }

        /// <summary>
        ///     A style for table body
        /// </summary>
        [NotNull]
        IColoredStringStyle BodyColors { get; }

        /// <summary>
        ///     A style for table header row
        /// </summary>
        [NotNull]
        IColoredStringStyle HeaderColors { get; }

        /// <summary>
        ///     A style for table title
        /// </summary>
        [NotNull]
        IColoredStringStyle TitleColors { get; }

        /// <summary>
        ///     A style for table footer row
        /// </summary>
        [NotNull]
        IColoredStringStyle FooterColors { get; }
        
        #endregion
        
        #region Box drawing characters

        /// <summary>
        ///     A box-drawing character for single horizontal line:
        ///
        ///     <code>
        ///     ... <br/>
        ///     --- <br/>
        ///     ...
        ///     </code>
        /// </summary>
        char BoxHorizontal { get; }

        /// <summary>
        ///     A box-drawing character for single vertical line:
        ///
        ///     <code>
        ///     .|. <br/>
        ///     .|. <br/>
        ///     .|.
        ///     </code>
        /// </summary>
        char BoxVertical { get; }

        /// <summary>
        ///     A box-drawing character for single down and right line:
        ///
        ///     <code>
        ///     +-- <br/>
        ///     |..
        ///     </code>
        /// </summary>
        char BoxDownRight { get; }

        /// <summary>
        ///     A box-drawing character for single down and left line:
        ///
        ///     <code>
        ///     --+ <br/>
        ///     ..|
        ///     </code>
        /// </summary>
        char BoxDownLeft { get; }

        /// <summary>
        ///     A box-drawing character for single up and right line:
        ///
        ///     <code>
        ///     |.. <br/>
        ///     +--
        ///     </code>
        /// </summary>
        char BoxUpRight { get; }

        /// <summary>
        ///     A box-drawing character for single up and left line:
        ///
        ///     <code>
        ///     ..| <br/>
        ///     --+
        ///     </code>
        /// </summary>
        char BoxUpLeft { get; }

        /// <summary>
        ///     A box-drawing character for single vertical and left line:
        ///
        ///     <code>
        ///     ..| <br/>
        ///     --+ <br/>
        ///     ..|
        ///     </code>
        /// </summary>
        char BoxVerticalAndLeft { get; }

        /// <summary>
        ///     A box-drawing character for single vertical and right line:
        ///
        ///     <code>
        ///     |.. <br/>
        ///     +-- <br/>
        ///     |..
        ///     </code>
        /// </summary>
        char BoxVerticalAndRight { get; }

        /// <summary>
        ///     A box-drawing character for single horizontal and up line:
        ///
        ///     <code>
        ///     ..|.. <br/>
        ///     --+-- <br/>
        ///     .....
        ///     </code>
        /// </summary>
        char BoxHorizontalAndUp { get; }

        /// <summary>
        ///     A box-drawing character for single horizontal and down line:
        ///
        ///     <code>
        ///     ..... <br/>
        ///     --+-- <br/>
        ///     ..|..
        ///     </code>
        /// </summary>
        char BoxHorizontalAndDown { get; }

        /// <summary>
        ///     A box-drawing character for single vertical and horizontal line:
        ///
        ///     <code>
        ///     ..|.. <br/>
        ///     --+-- <br/>
        ///     ..|..
        ///     </code>
        /// </summary>
        char BoxVerticalAndHorizontal { get; }
        
        #endregion
    }
}