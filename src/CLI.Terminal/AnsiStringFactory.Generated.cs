using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    partial class AnsiStringFactory
    {
        #region Xxx()

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Black([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString Black([NotNull] this string text)
            => Black(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlue([NotNull] this string text)
            => DarkBlue(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreen([NotNull] this string text)
            => DarkGreen(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyan([NotNull] this string text)
            => DarkCyan(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRed([NotNull] this string text)
            => DarkRed(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagenta([NotNull] this string text)
            => DarkMagenta(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellow([NotNull] this string text)
            => DarkYellow(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Gray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString Gray([NotNull] this string text)
            => Gray(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGray([NotNull] this string text)
            => DarkGray(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Blue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString Blue([NotNull] this string text)
            => Blue(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Green([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString Green([NotNull] this string text)
            => Green(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Cyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString Cyan([NotNull] this string text)
            => Cyan(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Red([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString Red([NotNull] this string text)
            => Red(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Magenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString Magenta([NotNull] this string text)
            => Magenta(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Yellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString Yellow([NotNull] this string text)
            => Yellow(AnsiString.Create(text));

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString White([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, null);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString White([NotNull] this string text)
            => White(AnsiString.Create(text));

        #endregion

        #region OnXxx()

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnBlack([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.Black);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString OnBlack([NotNull] this string text)
            => OnBlack(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkBlue([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.DarkBlue);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkBlue([NotNull] this string text)
            => OnDarkBlue(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkGreen([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.DarkGreen);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkGreen([NotNull] this string text)
            => OnDarkGreen(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkCyan([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.DarkCyan);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkCyan([NotNull] this string text)
            => OnDarkCyan(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkRed([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.DarkRed);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkRed([NotNull] this string text)
            => OnDarkRed(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.DarkMagenta);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkMagenta([NotNull] this string text)
            => OnDarkMagenta(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkYellow([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.DarkYellow);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkYellow([NotNull] this string text)
            => OnDarkYellow(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnGray([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.Gray);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString OnGray([NotNull] this string text)
            => OnGray(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkGray([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.DarkGray);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString OnDarkGray([NotNull] this string text)
            => OnDarkGray(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnBlue([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.Blue);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString OnBlue([NotNull] this string text)
            => OnBlue(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnGreen([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.Green);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString OnGreen([NotNull] this string text)
            => OnGreen(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnCyan([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.Cyan);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString OnCyan([NotNull] this string text)
            => OnCyan(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnRed([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.Red);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString OnRed([NotNull] this string text)
            => OnRed(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnMagenta([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.Magenta);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString OnMagenta([NotNull] this string text)
            => OnMagenta(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnYellow([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.Yellow);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString OnYellow([NotNull] this string text)
            => OnYellow(AnsiString.Create(text));

        /// <summary>
        ///     Applies default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString OnWhite([NotNull] this AnsiString text)
            => Create(text, null, ConsoleColor.White);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString OnWhite([NotNull] this string text)
            => OnWhite(AnsiString.Create(text));

        #endregion

        #region XxxOnYyy()

        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnBlack([NotNull] this string text)
            => BlackOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkBlue([NotNull] this string text)
            => BlackOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkGreen([NotNull] this string text)
            => BlackOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkCyan([NotNull] this string text)
            => BlackOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkRed([NotNull] this string text)
            => BlackOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkMagenta([NotNull] this string text)
            => BlackOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkYellow([NotNull] this string text)
            => BlackOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnGray([NotNull] this string text)
            => BlackOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnDarkGray([NotNull] this string text)
            => BlackOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnBlue([NotNull] this string text)
            => BlackOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnGreen([NotNull] this string text)
            => BlackOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnCyan([NotNull] this string text)
            => BlackOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnRed([NotNull] this string text)
            => BlackOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnMagenta([NotNull] this string text)
            => BlackOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnYellow([NotNull] this string text)
            => BlackOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Black"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Black, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Black"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString BlackOnWhite([NotNull] this string text)
            => BlackOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnBlack([NotNull] this string text)
            => DarkBlueOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkBlue([NotNull] this string text)
            => DarkBlueOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkGreen([NotNull] this string text)
            => DarkBlueOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkCyan([NotNull] this string text)
            => DarkBlueOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkRed([NotNull] this string text)
            => DarkBlueOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkMagenta([NotNull] this string text)
            => DarkBlueOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkYellow([NotNull] this string text)
            => DarkBlueOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnGray([NotNull] this string text)
            => DarkBlueOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnDarkGray([NotNull] this string text)
            => DarkBlueOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnBlue([NotNull] this string text)
            => DarkBlueOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnGreen([NotNull] this string text)
            => DarkBlueOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnCyan([NotNull] this string text)
            => DarkBlueOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnRed([NotNull] this string text)
            => DarkBlueOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnMagenta([NotNull] this string text)
            => DarkBlueOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnYellow([NotNull] this string text)
            => DarkBlueOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkBlue"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkBlue"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkBlueOnWhite([NotNull] this string text)
            => DarkBlueOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnBlack([NotNull] this string text)
            => DarkGreenOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkBlue([NotNull] this string text)
            => DarkGreenOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkGreen([NotNull] this string text)
            => DarkGreenOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkCyan([NotNull] this string text)
            => DarkGreenOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkRed([NotNull] this string text)
            => DarkGreenOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkMagenta([NotNull] this string text)
            => DarkGreenOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkYellow([NotNull] this string text)
            => DarkGreenOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnGray([NotNull] this string text)
            => DarkGreenOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnDarkGray([NotNull] this string text)
            => DarkGreenOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnBlue([NotNull] this string text)
            => DarkGreenOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnGreen([NotNull] this string text)
            => DarkGreenOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnCyan([NotNull] this string text)
            => DarkGreenOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnRed([NotNull] this string text)
            => DarkGreenOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnMagenta([NotNull] this string text)
            => DarkGreenOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnYellow([NotNull] this string text)
            => DarkGreenOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGreen"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGreen"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGreenOnWhite([NotNull] this string text)
            => DarkGreenOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnBlack([NotNull] this string text)
            => DarkCyanOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkBlue([NotNull] this string text)
            => DarkCyanOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkGreen([NotNull] this string text)
            => DarkCyanOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkCyan([NotNull] this string text)
            => DarkCyanOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkRed([NotNull] this string text)
            => DarkCyanOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkMagenta([NotNull] this string text)
            => DarkCyanOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkYellow([NotNull] this string text)
            => DarkCyanOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnGray([NotNull] this string text)
            => DarkCyanOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnDarkGray([NotNull] this string text)
            => DarkCyanOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnBlue([NotNull] this string text)
            => DarkCyanOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnGreen([NotNull] this string text)
            => DarkCyanOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnCyan([NotNull] this string text)
            => DarkCyanOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnRed([NotNull] this string text)
            => DarkCyanOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnMagenta([NotNull] this string text)
            => DarkCyanOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnYellow([NotNull] this string text)
            => DarkCyanOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkCyan"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkCyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkCyanOnWhite([NotNull] this string text)
            => DarkCyanOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnBlack([NotNull] this string text)
            => DarkRedOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkBlue([NotNull] this string text)
            => DarkRedOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkGreen([NotNull] this string text)
            => DarkRedOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkCyan([NotNull] this string text)
            => DarkRedOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkRed([NotNull] this string text)
            => DarkRedOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkMagenta([NotNull] this string text)
            => DarkRedOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkYellow([NotNull] this string text)
            => DarkRedOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnGray([NotNull] this string text)
            => DarkRedOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnDarkGray([NotNull] this string text)
            => DarkRedOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnBlue([NotNull] this string text)
            => DarkRedOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnGreen([NotNull] this string text)
            => DarkRedOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnCyan([NotNull] this string text)
            => DarkRedOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnRed([NotNull] this string text)
            => DarkRedOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnMagenta([NotNull] this string text)
            => DarkRedOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnYellow([NotNull] this string text)
            => DarkRedOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkRed"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkRed"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkRedOnWhite([NotNull] this string text)
            => DarkRedOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnBlack([NotNull] this string text)
            => DarkMagentaOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkBlue([NotNull] this string text)
            => DarkMagentaOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkGreen([NotNull] this string text)
            => DarkMagentaOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkCyan([NotNull] this string text)
            => DarkMagentaOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkRed([NotNull] this string text)
            => DarkMagentaOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkMagenta([NotNull] this string text)
            => DarkMagentaOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkYellow([NotNull] this string text)
            => DarkMagentaOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnGray([NotNull] this string text)
            => DarkMagentaOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnDarkGray([NotNull] this string text)
            => DarkMagentaOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnBlue([NotNull] this string text)
            => DarkMagentaOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnGreen([NotNull] this string text)
            => DarkMagentaOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnCyan([NotNull] this string text)
            => DarkMagentaOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnRed([NotNull] this string text)
            => DarkMagentaOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnMagenta([NotNull] this string text)
            => DarkMagentaOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnYellow([NotNull] this string text)
            => DarkMagentaOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkMagenta"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkMagenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkMagentaOnWhite([NotNull] this string text)
            => DarkMagentaOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnBlack([NotNull] this string text)
            => DarkYellowOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkBlue([NotNull] this string text)
            => DarkYellowOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkGreen([NotNull] this string text)
            => DarkYellowOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkCyan([NotNull] this string text)
            => DarkYellowOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkRed([NotNull] this string text)
            => DarkYellowOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkMagenta([NotNull] this string text)
            => DarkYellowOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkYellow([NotNull] this string text)
            => DarkYellowOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnGray([NotNull] this string text)
            => DarkYellowOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnDarkGray([NotNull] this string text)
            => DarkYellowOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnBlue([NotNull] this string text)
            => DarkYellowOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnGreen([NotNull] this string text)
            => DarkYellowOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnCyan([NotNull] this string text)
            => DarkYellowOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnRed([NotNull] this string text)
            => DarkYellowOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnMagenta([NotNull] this string text)
            => DarkYellowOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnYellow([NotNull] this string text)
            => DarkYellowOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkYellow"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkYellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkYellowOnWhite([NotNull] this string text)
            => DarkYellowOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnBlack([NotNull] this string text)
            => GrayOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkBlue([NotNull] this string text)
            => GrayOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkGreen([NotNull] this string text)
            => GrayOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkCyan([NotNull] this string text)
            => GrayOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkRed([NotNull] this string text)
            => GrayOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkMagenta([NotNull] this string text)
            => GrayOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkYellow([NotNull] this string text)
            => GrayOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnGray([NotNull] this string text)
            => GrayOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnDarkGray([NotNull] this string text)
            => GrayOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnBlue([NotNull] this string text)
            => GrayOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnGreen([NotNull] this string text)
            => GrayOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnCyan([NotNull] this string text)
            => GrayOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnRed([NotNull] this string text)
            => GrayOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnMagenta([NotNull] this string text)
            => GrayOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnYellow([NotNull] this string text)
            => GrayOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Gray"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Gray"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString GrayOnWhite([NotNull] this string text)
            => GrayOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnBlack([NotNull] this string text)
            => DarkGrayOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkBlue([NotNull] this string text)
            => DarkGrayOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkGreen([NotNull] this string text)
            => DarkGrayOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkCyan([NotNull] this string text)
            => DarkGrayOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkRed([NotNull] this string text)
            => DarkGrayOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkMagenta([NotNull] this string text)
            => DarkGrayOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkYellow([NotNull] this string text)
            => DarkGrayOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnGray([NotNull] this string text)
            => DarkGrayOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnDarkGray([NotNull] this string text)
            => DarkGrayOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnBlue([NotNull] this string text)
            => DarkGrayOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnGreen([NotNull] this string text)
            => DarkGrayOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnCyan([NotNull] this string text)
            => DarkGrayOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnRed([NotNull] this string text)
            => DarkGrayOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnMagenta([NotNull] this string text)
            => DarkGrayOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnYellow([NotNull] this string text)
            => DarkGrayOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.DarkGray"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.DarkGray"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString DarkGrayOnWhite([NotNull] this string text)
            => DarkGrayOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnBlack([NotNull] this string text)
            => BlueOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkBlue([NotNull] this string text)
            => BlueOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkGreen([NotNull] this string text)
            => BlueOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkCyan([NotNull] this string text)
            => BlueOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkRed([NotNull] this string text)
            => BlueOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkMagenta([NotNull] this string text)
            => BlueOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkYellow([NotNull] this string text)
            => BlueOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnGray([NotNull] this string text)
            => BlueOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnDarkGray([NotNull] this string text)
            => BlueOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnBlue([NotNull] this string text)
            => BlueOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnGreen([NotNull] this string text)
            => BlueOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnCyan([NotNull] this string text)
            => BlueOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnRed([NotNull] this string text)
            => BlueOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnMagenta([NotNull] this string text)
            => BlueOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnYellow([NotNull] this string text)
            => BlueOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Blue"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Blue"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString BlueOnWhite([NotNull] this string text)
            => BlueOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnBlack([NotNull] this string text)
            => GreenOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkBlue([NotNull] this string text)
            => GreenOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkGreen([NotNull] this string text)
            => GreenOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkCyan([NotNull] this string text)
            => GreenOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkRed([NotNull] this string text)
            => GreenOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkMagenta([NotNull] this string text)
            => GreenOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkYellow([NotNull] this string text)
            => GreenOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnGray([NotNull] this string text)
            => GreenOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnDarkGray([NotNull] this string text)
            => GreenOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnBlue([NotNull] this string text)
            => GreenOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnGreen([NotNull] this string text)
            => GreenOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnCyan([NotNull] this string text)
            => GreenOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnRed([NotNull] this string text)
            => GreenOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnMagenta([NotNull] this string text)
            => GreenOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnYellow([NotNull] this string text)
            => GreenOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Green"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Green, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Green"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString GreenOnWhite([NotNull] this string text)
            => GreenOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnBlack([NotNull] this string text)
            => CyanOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkBlue([NotNull] this string text)
            => CyanOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkGreen([NotNull] this string text)
            => CyanOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkCyan([NotNull] this string text)
            => CyanOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkRed([NotNull] this string text)
            => CyanOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkMagenta([NotNull] this string text)
            => CyanOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkYellow([NotNull] this string text)
            => CyanOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnGray([NotNull] this string text)
            => CyanOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnDarkGray([NotNull] this string text)
            => CyanOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnBlue([NotNull] this string text)
            => CyanOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnGreen([NotNull] this string text)
            => CyanOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnCyan([NotNull] this string text)
            => CyanOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnRed([NotNull] this string text)
            => CyanOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnMagenta([NotNull] this string text)
            => CyanOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnYellow([NotNull] this string text)
            => CyanOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Cyan"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Cyan"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString CyanOnWhite([NotNull] this string text)
            => CyanOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnBlack([NotNull] this string text)
            => RedOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkBlue([NotNull] this string text)
            => RedOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkGreen([NotNull] this string text)
            => RedOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkCyan([NotNull] this string text)
            => RedOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkRed([NotNull] this string text)
            => RedOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkMagenta([NotNull] this string text)
            => RedOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkYellow([NotNull] this string text)
            => RedOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnGray([NotNull] this string text)
            => RedOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnDarkGray([NotNull] this string text)
            => RedOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnBlue([NotNull] this string text)
            => RedOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnGreen([NotNull] this string text)
            => RedOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnCyan([NotNull] this string text)
            => RedOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnRed([NotNull] this string text)
            => RedOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnMagenta([NotNull] this string text)
            => RedOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnYellow([NotNull] this string text)
            => RedOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Red"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Red, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Red"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString RedOnWhite([NotNull] this string text)
            => RedOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnBlack([NotNull] this string text)
            => MagentaOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkBlue([NotNull] this string text)
            => MagentaOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkGreen([NotNull] this string text)
            => MagentaOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkCyan([NotNull] this string text)
            => MagentaOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkRed([NotNull] this string text)
            => MagentaOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkMagenta([NotNull] this string text)
            => MagentaOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkYellow([NotNull] this string text)
            => MagentaOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnGray([NotNull] this string text)
            => MagentaOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnDarkGray([NotNull] this string text)
            => MagentaOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnBlue([NotNull] this string text)
            => MagentaOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnGreen([NotNull] this string text)
            => MagentaOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnCyan([NotNull] this string text)
            => MagentaOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnRed([NotNull] this string text)
            => MagentaOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnMagenta([NotNull] this string text)
            => MagentaOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnYellow([NotNull] this string text)
            => MagentaOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Magenta"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Magenta"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString MagentaOnWhite([NotNull] this string text)
            => MagentaOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnBlack([NotNull] this string text)
            => YellowOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkBlue([NotNull] this string text)
            => YellowOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkGreen([NotNull] this string text)
            => YellowOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkCyan([NotNull] this string text)
            => YellowOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkRed([NotNull] this string text)
            => YellowOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkMagenta([NotNull] this string text)
            => YellowOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkYellow([NotNull] this string text)
            => YellowOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnGray([NotNull] this string text)
            => YellowOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnDarkGray([NotNull] this string text)
            => YellowOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnBlue([NotNull] this string text)
            => YellowOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnGreen([NotNull] this string text)
            => YellowOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnCyan([NotNull] this string text)
            => YellowOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnRed([NotNull] this string text)
            => YellowOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnMagenta([NotNull] this string text)
            => YellowOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnYellow([NotNull] this string text)
            => YellowOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.Yellow"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.Yellow"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString YellowOnWhite([NotNull] this string text)
            => YellowOnWhite(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.Black"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnBlack([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.Black);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.Black"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnBlack([NotNull] this string text)
            => WhiteOnBlack(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.DarkBlue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkBlue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkBlue"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkBlue([NotNull] this string text)
            => WhiteOnDarkBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.DarkGreen"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkGreen);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGreen"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkGreen([NotNull] this string text)
            => WhiteOnDarkGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.DarkCyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkCyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkCyan"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkCyan([NotNull] this string text)
            => WhiteOnDarkCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.DarkRed"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkRed);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkRed"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkRed([NotNull] this string text)
            => WhiteOnDarkRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.DarkMagenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkMagenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkMagenta"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkMagenta([NotNull] this string text)
            => WhiteOnDarkMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.DarkYellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkYellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkYellow"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkYellow([NotNull] this string text)
            => WhiteOnDarkYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.Gray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.Gray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.Gray"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnGray([NotNull] this string text)
            => WhiteOnGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.DarkGray"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkGray([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkGray);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.DarkGray"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnDarkGray([NotNull] this string text)
            => WhiteOnDarkGray(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.Blue"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnBlue([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.Blue);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.Blue"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnBlue([NotNull] this string text)
            => WhiteOnBlue(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.Green"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnGreen([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.Green);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.Green"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnGreen([NotNull] this string text)
            => WhiteOnGreen(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.Cyan"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnCyan([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.Cyan);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.Cyan"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnCyan([NotNull] this string text)
            => WhiteOnCyan(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.Red"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnRed([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.Red);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.Red"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnRed([NotNull] this string text)
            => WhiteOnRed(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.Magenta"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnMagenta([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.Magenta);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.Magenta"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnMagenta([NotNull] this string text)
            => WhiteOnMagenta(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.Yellow"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnYellow([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.Yellow);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnYellow([NotNull] this string text)
            => WhiteOnYellow(AnsiString.Create(text));
        /// <summary>
        ///     Applies default foreground color <see cref="ConsoleColor.White"/>
        ///     and default background color <see cref="ConsoleColor.White"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnWhite([NotNull] this AnsiString text)
            => Create(text, ConsoleColor.White, ConsoleColor.White);

          /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <see cref="ConsoleColor.White"/>
        ///     and their background colors set to <see cref="ConsoleColor.White"/>
        /// </summary>
        [Pure]
        public static AnsiString WhiteOnWhite([NotNull] this string text)
            => WhiteOnWhite(AnsiString.Create(text));
        #endregion
    }
}