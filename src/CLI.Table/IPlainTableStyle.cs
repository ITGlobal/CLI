namespace ITGlobal.CommandLine.Table
{
    public interface IPlainTableStyle
    {
        IColoredStringStyle BodyColors { get; }
        IColoredStringStyle HeaderColors { get; }
        IColoredStringStyle TitleColors { get; }
        IColoredStringStyle FooterColors { get; }

        bool DrawHeaders { get; }
        bool UppercaseHeaders { get; }
        bool UnderlineHeaders { get; }
    }
}