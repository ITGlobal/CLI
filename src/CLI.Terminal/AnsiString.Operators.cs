using System.Diagnostics.Contracts;
using System.Globalization;

namespace ITGlobal.CommandLine
{
    partial struct AnsiString
    {
        /// <summary>
        ///     Implicit conversion into a string
        /// </summary>
        [Pure]
        public static implicit operator string(AnsiString str) => str.ToString();

        /// <summary>
        ///     Implicit conversion from a string value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(string value) => FromString(value);

        /// <summary>
        ///     Implicit conversion from a boolean value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(bool value) => FromString(value ? "true" : "false");

        /// <summary>
        ///     Implicit conversion from a char value
        /// </summary>
        [Pure]
        public static implicit operator AnsiString(char value) => FromString(new string(value, 1));

        /// <summary>
        ///     Implicit conversion from an uint8 value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(byte value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Implicit conversion from an int8 value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(sbyte value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Implicit conversion from an int16 value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(short value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Implicit conversion from an uint16 value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(ushort value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Implicit conversion from an int32 value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(int value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Implicit conversion from an uint32 value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(uint value) => FromString(value.ToString(CultureInfo.InvariantCulture));
        
        /// <summary>
        ///     Implicit conversion from an int64 value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(long value) => FromString(value.ToString(CultureInfo.InvariantCulture));
        
        /// <summary>
        ///     Implicit conversion from an uint64 value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(ulong value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Implicit conversion from a float value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(float value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Implicit conversion from a double value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(double value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Implicit conversion from a decimal value
        /// </summary>
        [Pure]
        public static explicit operator AnsiString(decimal value) => FromString(value.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        ///     Equality operator
        /// </summary>
        public static bool operator ==(AnsiString left, AnsiString right) => left.Equals(right);

        /// <summary>
        ///     Inequality operator
        /// </summary>
        public static bool operator !=(AnsiString left, AnsiString right) => !left.Equals(right);

        /// <summary>
        ///     Concatenation operator
        /// </summary>
        public static AnsiString operator +(AnsiString left, AnsiString right) => left.Concat(right);

        /// <inheritdoc />
        public bool Equals(AnsiString other) => Equals(_chars, other._chars);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is AnsiString other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => _chars != null ? _chars.GetHashCode() : 0;
    }
}
