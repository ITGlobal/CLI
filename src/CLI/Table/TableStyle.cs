using System;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Table style flags
    /// </summary>
    [Flags]
    public enum TableStyle
    {
        /// <summary>
        ///     Enables table title rendering
        /// </summary>
        HasTitle = 1 << 0,

        /// <summary>
        ///     Makes table title uppercased
        /// </summary>
        UppercaseTitle = 1 << 1,

        /// <summary>
        ///     Makes table title underlined (with a double line)
        /// </summary>
        UnderlinedTitle = 1 << 2,


        /// <summary>
        ///     Enables table headers rendering
        /// </summary>
        HasHeaders = 1 << 2,

        /// <summary>
        ///     Makes table headers uppercased
        /// </summary>
        UppercaseHeaders = 1 << 3,

        /// <summary>
        ///     Makes table headers underlined (with a single line)
        /// </summary>
        UnderlinedHeaders = 1 << 4,


        /// <summary>
        ///     Default table style
        /// </summary>
        Default = HasHeaders | UppercaseHeaders
    }
}