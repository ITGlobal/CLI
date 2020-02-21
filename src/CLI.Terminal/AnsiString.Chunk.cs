using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

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
            ///     TAB chunk
            /// </summary>
            public static readonly Chunk TAB = new Chunk(new [] {' ', ' ', ' ', ' '}, null, null);
           
            /// <summary>
            ///     Empty chunk
            /// </summary>
            public static readonly Chunk EMPTY = new Chunk(new char[0], null, null);

            /// <summary>
            ///     .ctor
            /// </summary>
            public Chunk(char[] buffer, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
                : this(buffer, 0, buffer.Length, foregroundColor, backgroundColor)
            { }

            /// <summary>
            ///     .ctor
            /// </summary>
            private Chunk(char[] buffer, int offset, int length, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
            {
                Buffer = buffer;
                Offset = offset;
                Length = length;
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
            ///     Offset in <see cref="Buffer"/>
            /// </summary>
            public int Offset { get; }

            /// <summary>
            ///     Length of a chunk
            /// </summary>
            public int Length { get; }

            /// <summary>
            ///     Length of <see cref="Buffer"/>
            /// </summary>
            public int Capacity => Buffer.Length;

            /// <summary>
            ///     Get a char by an index
            /// </summary>
            public char this[int index] => Buffer[Offset + index];

            /// <summary>
            ///     Slice current chunk, selecting [<paramref name="offset"/>...<paramref name="offset"/> + <paramref name="length"/>] buffer.
            /// </summary>
            [Pure]
            public Chunk Slice(int offset, int length)
            {
                if (offset < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(offset));
                }

                if (offset >= Length)
                {
                    offset = Length - 1;
                }

                if (length < 0)
                {
                    length = 0;
                }

                if (offset + length > Length)
                {
                    length = Length - offset;
                }

                if (length == 0)
                {
                    return EMPTY;
                }

                return new Chunk(
                    buffer: Buffer,
                    offset: offset + Offset,
                    length: length,
                    foregroundColor: ForegroundColor,
                    backgroundColor: BackgroundColor
                );
            }

            /// <summary>
            ///     Slice current chunk, selecting [<paramref name="offset"/>...<see cref="Length"/>] buffer.
            /// </summary>
            [Pure]
            public Chunk Slice(int offset) => Slice(offset, Length - offset);

            /// <summary>
            ///     Create a copy of current chunk with different colors
            /// </summary>
            [Pure]
            public Chunk WithColors(ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
            {
                return new Chunk(
                    buffer: Buffer,
                    offset: Offset,
                    length: Length,
                    foregroundColor: foregroundColor,
                    backgroundColor: backgroundColor
                );
            }

            [Pure]
            private string DebuggerView()
            {
                var fgName = ForegroundColor != null ? ForegroundColor.Value.ToString() : "Default";
                var bgName = BackgroundColor != null ? BackgroundColor.Value.ToString() : "Default";

                var str = $"\"{ToString()}\" {fgName} on {bgName}";
                return str;
            }

            /// <inheritdoc />
            public override string ToString() => Length > 0 ? new string(Buffer, Offset, Length) : string.Empty;
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
