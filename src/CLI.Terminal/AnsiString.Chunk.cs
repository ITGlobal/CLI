using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace ITGlobal.CommandLine
{
    partial struct AnsiString
    {
        /// <summary>
        ///     A piece of adjacent characters with the same colors
        /// </summary>
        [DebuggerDisplay("{" + nameof(DebuggerView) + "()}")]
        public readonly struct Chunk
        {
            /// <summary>
            ///     .ctor
            /// </summary>
            public Chunk(char[] buffer, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
            {
                Buffer = buffer;
                ForegroundColor = foregroundColor;
                BackgroundColor = backgroundColor;
            }

            /// <summary>
            ///     Characters
            /// </summary>
            public readonly char[] Buffer;

            /// <summary>
            ///     Foreground color
            /// </summary>
            public readonly ConsoleColor? ForegroundColor;
            
            /// <summary>
            ///     Background color
            /// </summary>
            public readonly ConsoleColor? BackgroundColor;

            /// <summary>
            ///     Length of <see cref="Buffer"/>
            /// </summary>
            public int Length => Buffer.Length;

            [Pure]
            private string DebuggerView()
            {
                var fgName = ForegroundColor != null ? ForegroundColor.Value.ToString() : "Default";
                var bgName = BackgroundColor != null ? BackgroundColor.Value.ToString() : "Default";

                var str = $"\"{new string(Buffer)}\" {fgName} on {bgName}";
                return str;
            }

            /// <inheritdoc />
            public override string ToString() => new string(Buffer);
        }

        /// <summary>
        ///     Splits an <see cref="AnsiString"/> into <see cref="Chunk"/>s - blocks of adjacent characters with the same colors.
        /// </summary>
        [Pure]
        public IReadOnlyList<Chunk> SplitIntoChunks()
        {
            var list = new List<Chunk>();
            ConsoleColor? foregroundColor = default;
            ConsoleColor? backgroundColor = default;

            var sb = new List<char>(_chars.Length);
            foreach (var (c, fg, bg) in _chars)
            {
                if (fg != foregroundColor || bg != backgroundColor)
                {
                    if (sb.Count > 0)
                    {
                        list.Add(new Chunk(sb.ToArray(), foregroundColor, backgroundColor));
                        sb.Clear();
                    }

                    foregroundColor = fg;
                    backgroundColor = bg;
                }

                sb.Add(c);
            }

            if (sb.Count > 0)
            {
                list.Add(new Chunk(sb.ToArray(), foregroundColor, backgroundColor));
                sb.Clear();
            }

            return list;
        }
    }
}
