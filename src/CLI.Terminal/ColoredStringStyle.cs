using System;
using System.Collections.Concurrent;
using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     An implementation of <see cref="IColoredStringStyle"/>
    /// </summary>
    [PublicAPI]
    public static partial class ColoredStringStyle
    {
        private readonly struct Key : IEquatable<Key>
        {
            public Key(ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
            {
                ForegroundColor = foregroundColor;
                BackgroundColor = backgroundColor;
            }

            public readonly ConsoleColor? ForegroundColor;
            public readonly ConsoleColor? BackgroundColor;

            public bool Equals(Key other) 
                => ForegroundColor == other.ForegroundColor && BackgroundColor == other.BackgroundColor;

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is Key other && Equals(other);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (ForegroundColor.GetHashCode() * 397) ^ BackgroundColor.GetHashCode();
                }
            }

            public static bool operator ==(Key left, Key right) => left.Equals(right);

            public static bool operator !=(Key left, Key right) => !left.Equals(right);
        }

        private static readonly ConcurrentDictionary<Key, IColoredStringStyle> CachedValues
            = new ConcurrentDictionary<Key, IColoredStringStyle>();

        /// <summary>
        ///     An empty <see cref="IColoredStringStyle"/> 
        /// </summary>
        [NotNull]
        public static IColoredStringStyle Null { get; } = Create(null, null);

        /// <summary>
        ///     Creates new <see cref="IColoredStringStyle"/> with the specified parameters
        /// </summary>
        [NotNull]
        public static IColoredStringStyle Create(ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var key = new Key(foregroundColor, backgroundColor);
            return CachedValues.GetOrAdd(key, k => new ColoredStringStyleImpl(k.ForegroundColor, k.BackgroundColor));
        }

        /// <summary>
        ///     Creates new <see cref="IColoredStringStyle"/> from an existing one
        /// </summary>
        [NotNull]
        public static IColoredStringStyle Update(
            [NotNull] this IColoredStringStyle style, 
            ConsoleColor? foregroundColor= null, 
            ConsoleColor? backgroundColor = null)
        {
            switch (style)
            {
                case ColoredStringStyleImpl s:
                    foregroundColor ??= s.ForegroundColor;
                    backgroundColor ??= s.BackgroundColor;
                    break;
            }

            return Create(foregroundColor, backgroundColor);
        }
    }
}
