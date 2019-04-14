using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line options value validator
    /// </summary>
    [PublicAPI]
    public delegate string ValueValidator<in T>(T value, bool isSet);
}