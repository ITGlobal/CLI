using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    partial class ColoredStringFactory
    {
        #region Xxx()

        [Pure]
        public static ColoredString Black([NotNull] this string text)
            => Create(text, ConsoleColor.Black, null);

        [Pure]
        public static ColoredString DarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, null);

        [Pure]
        public static ColoredString DarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, null);

        [Pure]
        public static ColoredString DarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, null);

        [Pure]
        public static ColoredString DarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, null);

        [Pure]
        public static ColoredString DarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, null);

        [Pure]
        public static ColoredString DarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, null);

        [Pure]
        public static ColoredString Gray([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, null);

        [Pure]
        public static ColoredString DarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, null);

        [Pure]
        public static ColoredString Blue([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, null);

        [Pure]
        public static ColoredString Green([NotNull] this string text)
            => Create(text, ConsoleColor.Green, null);

        [Pure]
        public static ColoredString Cyan([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, null);

        [Pure]
        public static ColoredString Red([NotNull] this string text)
            => Create(text, ConsoleColor.Red, null);

        [Pure]
        public static ColoredString Magenta([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, null);

        [Pure]
        public static ColoredString Yellow([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, null);

        [Pure]
        public static ColoredString White([NotNull] this string text)
            => Create(text, ConsoleColor.White, null);

        #endregion

        #region OnXxx()

        [Pure]
        public static ColoredString OnBlack([NotNull] this string text)
            => Create(text, null, ConsoleColor.Black);

        [Pure]
        public static ColoredString OnDarkBlue([NotNull] this string text)
            => Create(text, null, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString OnDarkGreen([NotNull] this string text)
            => Create(text, null, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString OnDarkCyan([NotNull] this string text)
            => Create(text, null, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString OnDarkRed([NotNull] this string text)
            => Create(text, null, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString OnDarkMagenta([NotNull] this string text)
            => Create(text, null, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString OnDarkYellow([NotNull] this string text)
            => Create(text, null, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString OnGray([NotNull] this string text)
            => Create(text, null, ConsoleColor.Gray);

        [Pure]
        public static ColoredString OnDarkGray([NotNull] this string text)
            => Create(text, null, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString OnBlue([NotNull] this string text)
            => Create(text, null, ConsoleColor.Blue);

        [Pure]
        public static ColoredString OnGreen([NotNull] this string text)
            => Create(text, null, ConsoleColor.Green);

        [Pure]
        public static ColoredString OnCyan([NotNull] this string text)
            => Create(text, null, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString OnRed([NotNull] this string text)
            => Create(text, null, ConsoleColor.Red);

        [Pure]
        public static ColoredString OnMagenta([NotNull] this string text)
            => Create(text, null, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString OnYellow([NotNull] this string text)
            => Create(text, null, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString OnWhite([NotNull] this string text)
            => Create(text, null, ConsoleColor.White);

        #endregion

        #region XxxOnYyy()

        [Pure]
        public static ColoredString BlackOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Black);

        [Pure]
        public static ColoredString BlackOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString BlackOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString BlackOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString BlackOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString BlackOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString BlackOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString BlackOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Gray);

        [Pure]
        public static ColoredString BlackOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString BlackOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Blue);

        [Pure]
        public static ColoredString BlackOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Green);

        [Pure]
        public static ColoredString BlackOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString BlackOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Red);

        [Pure]
        public static ColoredString BlackOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString BlackOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString BlackOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.Black, ConsoleColor.White);

        [Pure]
        public static ColoredString DarkBlueOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Black);

        [Pure]
        public static ColoredString DarkBlueOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString DarkBlueOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString DarkBlueOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString DarkBlueOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString DarkBlueOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString DarkBlueOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString DarkBlueOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Gray);

        [Pure]
        public static ColoredString DarkBlueOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString DarkBlueOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Blue);

        [Pure]
        public static ColoredString DarkBlueOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Green);

        [Pure]
        public static ColoredString DarkBlueOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString DarkBlueOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Red);

        [Pure]
        public static ColoredString DarkBlueOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString DarkBlueOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString DarkBlueOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.DarkBlue, ConsoleColor.White);

        [Pure]
        public static ColoredString DarkGreenOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Black);

        [Pure]
        public static ColoredString DarkGreenOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString DarkGreenOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString DarkGreenOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString DarkGreenOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString DarkGreenOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString DarkGreenOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString DarkGreenOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Gray);

        [Pure]
        public static ColoredString DarkGreenOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString DarkGreenOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Blue);

        [Pure]
        public static ColoredString DarkGreenOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Green);

        [Pure]
        public static ColoredString DarkGreenOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString DarkGreenOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Red);

        [Pure]
        public static ColoredString DarkGreenOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString DarkGreenOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString DarkGreenOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGreen, ConsoleColor.White);

        [Pure]
        public static ColoredString DarkCyanOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Black);

        [Pure]
        public static ColoredString DarkCyanOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString DarkCyanOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString DarkCyanOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString DarkCyanOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString DarkCyanOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString DarkCyanOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString DarkCyanOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Gray);

        [Pure]
        public static ColoredString DarkCyanOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString DarkCyanOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Blue);

        [Pure]
        public static ColoredString DarkCyanOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Green);

        [Pure]
        public static ColoredString DarkCyanOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString DarkCyanOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Red);

        [Pure]
        public static ColoredString DarkCyanOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString DarkCyanOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString DarkCyanOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.DarkCyan, ConsoleColor.White);

        [Pure]
        public static ColoredString DarkRedOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Black);

        [Pure]
        public static ColoredString DarkRedOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString DarkRedOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString DarkRedOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString DarkRedOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString DarkRedOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString DarkRedOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString DarkRedOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Gray);

        [Pure]
        public static ColoredString DarkRedOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString DarkRedOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Blue);

        [Pure]
        public static ColoredString DarkRedOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Green);

        [Pure]
        public static ColoredString DarkRedOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString DarkRedOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Red);

        [Pure]
        public static ColoredString DarkRedOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString DarkRedOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString DarkRedOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.DarkRed, ConsoleColor.White);

        [Pure]
        public static ColoredString DarkMagentaOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Black);

        [Pure]
        public static ColoredString DarkMagentaOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString DarkMagentaOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString DarkMagentaOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString DarkMagentaOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString DarkMagentaOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString DarkMagentaOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString DarkMagentaOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Gray);

        [Pure]
        public static ColoredString DarkMagentaOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString DarkMagentaOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Blue);

        [Pure]
        public static ColoredString DarkMagentaOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Green);

        [Pure]
        public static ColoredString DarkMagentaOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString DarkMagentaOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Red);

        [Pure]
        public static ColoredString DarkMagentaOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString DarkMagentaOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString DarkMagentaOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.DarkMagenta, ConsoleColor.White);

        [Pure]
        public static ColoredString DarkYellowOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Black);

        [Pure]
        public static ColoredString DarkYellowOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString DarkYellowOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString DarkYellowOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString DarkYellowOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString DarkYellowOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString DarkYellowOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString DarkYellowOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Gray);

        [Pure]
        public static ColoredString DarkYellowOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString DarkYellowOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Blue);

        [Pure]
        public static ColoredString DarkYellowOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Green);

        [Pure]
        public static ColoredString DarkYellowOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString DarkYellowOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Red);

        [Pure]
        public static ColoredString DarkYellowOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString DarkYellowOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString DarkYellowOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.DarkYellow, ConsoleColor.White);

        [Pure]
        public static ColoredString GrayOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Black);

        [Pure]
        public static ColoredString GrayOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString GrayOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString GrayOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString GrayOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString GrayOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString GrayOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString GrayOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Gray);

        [Pure]
        public static ColoredString GrayOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString GrayOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Blue);

        [Pure]
        public static ColoredString GrayOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Green);

        [Pure]
        public static ColoredString GrayOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString GrayOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Red);

        [Pure]
        public static ColoredString GrayOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString GrayOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString GrayOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.Gray, ConsoleColor.White);

        [Pure]
        public static ColoredString DarkGrayOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Black);

        [Pure]
        public static ColoredString DarkGrayOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString DarkGrayOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString DarkGrayOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString DarkGrayOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString DarkGrayOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString DarkGrayOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString DarkGrayOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Gray);

        [Pure]
        public static ColoredString DarkGrayOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString DarkGrayOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Blue);

        [Pure]
        public static ColoredString DarkGrayOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Green);

        [Pure]
        public static ColoredString DarkGrayOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString DarkGrayOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Red);

        [Pure]
        public static ColoredString DarkGrayOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString DarkGrayOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString DarkGrayOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.DarkGray, ConsoleColor.White);

        [Pure]
        public static ColoredString BlueOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Black);

        [Pure]
        public static ColoredString BlueOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString BlueOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString BlueOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString BlueOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString BlueOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString BlueOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString BlueOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Gray);

        [Pure]
        public static ColoredString BlueOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString BlueOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Blue);

        [Pure]
        public static ColoredString BlueOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Green);

        [Pure]
        public static ColoredString BlueOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString BlueOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Red);

        [Pure]
        public static ColoredString BlueOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString BlueOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString BlueOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.Blue, ConsoleColor.White);

        [Pure]
        public static ColoredString GreenOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Black);

        [Pure]
        public static ColoredString GreenOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString GreenOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString GreenOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString GreenOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString GreenOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString GreenOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString GreenOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Gray);

        [Pure]
        public static ColoredString GreenOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString GreenOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Blue);

        [Pure]
        public static ColoredString GreenOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Green);

        [Pure]
        public static ColoredString GreenOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString GreenOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Red);

        [Pure]
        public static ColoredString GreenOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString GreenOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString GreenOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.Green, ConsoleColor.White);

        [Pure]
        public static ColoredString CyanOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Black);

        [Pure]
        public static ColoredString CyanOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString CyanOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString CyanOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString CyanOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString CyanOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString CyanOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString CyanOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Gray);

        [Pure]
        public static ColoredString CyanOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString CyanOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Blue);

        [Pure]
        public static ColoredString CyanOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Green);

        [Pure]
        public static ColoredString CyanOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString CyanOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Red);

        [Pure]
        public static ColoredString CyanOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString CyanOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString CyanOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.Cyan, ConsoleColor.White);

        [Pure]
        public static ColoredString RedOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Black);

        [Pure]
        public static ColoredString RedOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString RedOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString RedOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString RedOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString RedOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString RedOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString RedOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Gray);

        [Pure]
        public static ColoredString RedOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString RedOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Blue);

        [Pure]
        public static ColoredString RedOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Green);

        [Pure]
        public static ColoredString RedOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString RedOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Red);

        [Pure]
        public static ColoredString RedOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString RedOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString RedOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.Red, ConsoleColor.White);

        [Pure]
        public static ColoredString MagentaOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Black);

        [Pure]
        public static ColoredString MagentaOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString MagentaOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString MagentaOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString MagentaOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString MagentaOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString MagentaOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString MagentaOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Gray);

        [Pure]
        public static ColoredString MagentaOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString MagentaOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Blue);

        [Pure]
        public static ColoredString MagentaOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Green);

        [Pure]
        public static ColoredString MagentaOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString MagentaOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Red);

        [Pure]
        public static ColoredString MagentaOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString MagentaOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString MagentaOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.Magenta, ConsoleColor.White);

        [Pure]
        public static ColoredString YellowOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Black);

        [Pure]
        public static ColoredString YellowOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString YellowOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString YellowOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString YellowOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString YellowOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString YellowOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString YellowOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Gray);

        [Pure]
        public static ColoredString YellowOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString YellowOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Blue);

        [Pure]
        public static ColoredString YellowOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Green);

        [Pure]
        public static ColoredString YellowOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString YellowOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Red);

        [Pure]
        public static ColoredString YellowOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString YellowOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString YellowOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.Yellow, ConsoleColor.White);

        [Pure]
        public static ColoredString WhiteOnBlack([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.Black);

        [Pure]
        public static ColoredString WhiteOnDarkBlue([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkBlue);

        [Pure]
        public static ColoredString WhiteOnDarkGreen([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkGreen);

        [Pure]
        public static ColoredString WhiteOnDarkCyan([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkCyan);

        [Pure]
        public static ColoredString WhiteOnDarkRed([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkRed);

        [Pure]
        public static ColoredString WhiteOnDarkMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkMagenta);

        [Pure]
        public static ColoredString WhiteOnDarkYellow([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkYellow);

        [Pure]
        public static ColoredString WhiteOnGray([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.Gray);

        [Pure]
        public static ColoredString WhiteOnDarkGray([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.DarkGray);

        [Pure]
        public static ColoredString WhiteOnBlue([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.Blue);

        [Pure]
        public static ColoredString WhiteOnGreen([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.Green);

        [Pure]
        public static ColoredString WhiteOnCyan([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.Cyan);

        [Pure]
        public static ColoredString WhiteOnRed([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.Red);

        [Pure]
        public static ColoredString WhiteOnMagenta([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.Magenta);

        [Pure]
        public static ColoredString WhiteOnYellow([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.Yellow);

        [Pure]
        public static ColoredString WhiteOnWhite([NotNull] this string text)
            => Create(text, ConsoleColor.White, ConsoleColor.White);

        #endregion
    }
}