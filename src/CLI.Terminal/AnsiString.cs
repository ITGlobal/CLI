using System.Diagnostics.Contracts;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A per-character colored string
    /// </summary>
    public readonly partial struct AnsiString
    {
        private readonly AnsiChar[] _chars;

        /// <summary>
        ///     .ctor
        /// </summary>
        public AnsiString(AnsiChar[] chars)
        {
            _chars = chars;
        }

        /// <summary>
        ///     Characters
        /// </summary>
#if !NET45
        public System.Collections.Immutable.ImmutableArray<AnsiChar> Chars
            => System.Collections.Immutable.ImmutableArray.Create(_chars);
#else
        public System.Collections.Generic.IReadOnlyList<AnsiChar> Chars => _chars;
#endif

        /// <summary>
        ///     String length
        /// </summary>
        [Pure]
        public int Length => _chars.Length;

        /// <summary>
        ///     Plain-text string (without color attributes)
        /// </summary>
        [Pure]
        public string Text => ToPlainString();

        /// <summary>
        ///     An empty <see cref="AnsiString"/>
        /// </summary>
#if !NET45
        public static readonly AnsiString Empty = new AnsiString(System.Array.Empty<AnsiChar>());
#else
        public static readonly AnsiString Empty = new AnsiString(new AnsiChar[0]);
#endif
    }
}