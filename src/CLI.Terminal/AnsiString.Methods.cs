using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ITGlobal.CommandLine
{
    partial struct AnsiString
    {
        /// <summary>
        ///     Splits an <see cref="AnsiString"/> by a separator
        /// </summary>
        [Pure]
        [JetBrains.Annotations.NotNull]
        public IEnumerable<AnsiString> Split(char separator)
        {
            var buffer = new List<AnsiChar>(_chars.Length);

            foreach (var c in _chars)
            {
                if (c.Char == separator)
                {
                    yield return new AnsiString(buffer.ToArray());
                    buffer.Clear();
                }
                else
                {
                    buffer.Add(c);
                }
            }

            if (buffer.Count > 0)
            {
                yield return new AnsiString(buffer.ToArray());
            }
        }

        /// <summary>
        ///     Extracts a substring from an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public AnsiString Substring(int startIndex)
        {
            var length = _chars.Length - startIndex;
            return Substring(startIndex, length);
        }

        /// <summary>
        ///     Extracts a substring from an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public AnsiString Substring(int startIndex, int length)
        {
            if (startIndex == 0 && length >= Length)
            {
                return this;
            }

            if (startIndex + length > Length)
            {
                length = Length - startIndex;
            }

            var array = new AnsiChar[length];
            Array.Copy(_chars, startIndex, array, 0, length);

            return new AnsiString(array);
        }

        /// <summary>
        ///     Adds a right padding to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public AnsiString PadRight(int totalWidth)
        {
            if (Length >= totalWidth)
            {
                return this;
            }
            
            var array = new AnsiChar[totalWidth];
            Array.Copy(_chars, 0, array, 0, Length);
            for (var i = Length; i < totalWidth; i++)
            {
                array[i] = new AnsiChar(' ');
            }

            return new AnsiString(array);
        }

        /// <summary>
        ///     Adds a left padding to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public AnsiString PadLeft(int totalWidth)
        {
            if (Length >= totalWidth)
            {
                return this;
            }

            var array = new AnsiChar[totalWidth];
            Array.Copy(_chars, 0, array, totalWidth - Length, Length);
            for (var i = 0; i < totalWidth - Length; i++)
            {
                array[i] = new AnsiChar(' ');
            }

            return new AnsiString(array);
        }

        /// <summary>
        ///     Converts an <see cref="AnsiString"/> to upper-case (culture invariant)
        /// </summary>
        [Pure]
        public AnsiString ToUpperInvariant()
        {
            var array = new AnsiChar[Length];
            Array.Copy(_chars, 0, array, 0, Length);
            for (var i = 0; i < array.Length; i++)
            {
                var c = array[i];
                array[i] = new AnsiChar(char.ToUpperInvariant(c.Char), c.ForegroundColor, c.BackgroundColor);
            }

            return new AnsiString(array);
        }

        /// <summary>
        ///     Applies default colors to an <see cref="AnsiString"/>.
        ///     Every character with unset foreground color will have <paramref name="foregroundColor"/> as its foreground color.
        ///     Same applied to background colors.
        /// </summary>
        public AnsiString WithDefaultColors(ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var array = new AnsiChar[Length];
            Array.Copy(_chars, 0, array, 0, Length);
            for (var i = 0; i < array.Length; i++)
            {
                var (c, fg, bg) = array[i];
                array[i] = new AnsiChar(
                    c,
                    fg ?? foregroundColor,
                    bg ?? backgroundColor
                );
            }

            return new AnsiString(array);
        }

        /// <summary>
        ///     Concatenates few <see cref="AnsiString"/>s into a single one
        /// </summary>
        public static AnsiString Concat([JetBrains.Annotations.NotNull] params AnsiString[] strs)
        {
            switch (strs.Length)
            {
                case 0:
                    return Empty;
                case 1:
                    return strs[0];
                case 2 when strs[0].Length == 0:
                    return strs[1];
                case 2 when strs[1].Length == 0:
                    return strs[0];
            }

            var buffer = new AnsiChar[strs.Sum(_ => _._chars.Length)];

            var i = 0;
            foreach (var s in strs)
            {
                Array.Copy(s._chars, 0, buffer, i, s._chars.Length);
                i += s._chars.Length;
            }

            return new AnsiString(buffer);
        }

        /// <summary>
        ///     Concatenates this <see cref="AnsiString"/> with another one
        /// </summary>
        public AnsiString Concat(AnsiString str)
        {
            var buffer = new AnsiChar[_chars.Length + str._chars.Length];

            Array.Copy(_chars, 0, buffer, 0, _chars.Length);
            Array.Copy(str._chars, 0, buffer, _chars.Length, str._chars.Length);

            return new AnsiString(buffer);
        }
    }
}
