using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Default value provider for command line options
    /// </summary>
    [PublicAPI]
    public delegate bool DefaultValueProvider<T>(out T value);
}