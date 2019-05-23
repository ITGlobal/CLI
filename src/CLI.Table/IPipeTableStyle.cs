namespace ITGlobal.CommandLine.Table
{
    public interface IPipeTableStyle
    {
        IColoredStringStyle BodyColors { get; }
        IColoredStringStyle HeaderColors { get; }
        IColoredStringStyle TitleColors { get; }
        IColoredStringStyle FooterColors { get; }
        IColoredStringStyle FrameColors { get; }
    }
}