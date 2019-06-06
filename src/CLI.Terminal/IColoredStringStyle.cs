using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    public interface IColoredStringStyle
    {
        ColoredString Apply([NotNull] string str);
        ColoredString Apply(char c);
        ColoredString Apply(ColoredString str);
    }
}