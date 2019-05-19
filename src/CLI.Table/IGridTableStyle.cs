namespace ITGlobal.CommandLine.Table
{
    public interface IGridTableStyle
    {
        IColoredStringStyle FrameColors { get; }
        IColoredStringStyle BodyColors { get; }
        IColoredStringStyle HeaderColors { get; }
        IColoredStringStyle TitleColors { get; }
        IColoredStringStyle FooterColors { get; }

        //
        // ---
        //
        char BoxHorizontal { get; }

        //  |
        //  |
        //  |
        char BoxVertical { get; }

        //  |
        //  +--
        //
        char BoxDownRight { get; }

        //   |
        // --+
        // 
        char BoxDownLeft { get; }

        // 
        //  +--
        //  |
        char BoxUpRight { get; }

        // 
        // --+
        //   |
        char BoxUpLeft { get; }

        //   |
        // --+
        //   |
        char BoxVerticalAndLeft { get; }

        //   |
        //   +--
        //   |
        char BoxVerticalAndRight { get; }

        //   |
        // --+--
        // 
        char BoxHorizontalAndUp { get; }

        // 
        // --+--
        //   |
        char BoxHorizontalAndDown { get; }

        //   |
        // --+--
        //   |
        char BoxVerticalAndHorizontal { get; }
    }
}