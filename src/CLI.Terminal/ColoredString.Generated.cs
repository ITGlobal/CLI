using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    partial struct ColoredString
    {
        #region Xxx()

        [Pure]
        public ColoredString Black()
            => new ColoredString(Text, ConsoleColor.Black, BackgroundColor);

        [Pure]
        public ColoredString DarkBlue()
            => new ColoredString(Text, ConsoleColor.DarkBlue, BackgroundColor);

        [Pure]
        public ColoredString DarkGreen()
            => new ColoredString(Text, ConsoleColor.DarkGreen, BackgroundColor);

        [Pure]
        public ColoredString DarkCyan()
            => new ColoredString(Text, ConsoleColor.DarkCyan, BackgroundColor);

        [Pure]
        public ColoredString DarkRed()
            => new ColoredString(Text, ConsoleColor.DarkRed, BackgroundColor);

        [Pure]
        public ColoredString DarkMagenta()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, BackgroundColor);

        [Pure]
        public ColoredString DarkYellow()
            => new ColoredString(Text, ConsoleColor.DarkYellow, BackgroundColor);

        [Pure]
        public ColoredString Gray()
            => new ColoredString(Text, ConsoleColor.Gray, BackgroundColor);

        [Pure]
        public ColoredString DarkGray()
            => new ColoredString(Text, ConsoleColor.DarkGray, BackgroundColor);

        [Pure]
        public ColoredString Blue()
            => new ColoredString(Text, ConsoleColor.Blue, BackgroundColor);

        [Pure]
        public ColoredString Green()
            => new ColoredString(Text, ConsoleColor.Green, BackgroundColor);

        [Pure]
        public ColoredString Cyan()
            => new ColoredString(Text, ConsoleColor.Cyan, BackgroundColor);

        [Pure]
        public ColoredString Red()
            => new ColoredString(Text, ConsoleColor.Red, BackgroundColor);

        [Pure]
        public ColoredString Magenta()
            => new ColoredString(Text, ConsoleColor.Magenta, BackgroundColor);

        [Pure]
        public ColoredString Yellow()
            => new ColoredString(Text, ConsoleColor.Yellow, BackgroundColor);

        [Pure]
        public ColoredString White()
            => new ColoredString(Text, ConsoleColor.White, BackgroundColor);

        #endregion 

        #region OnXxx()

        [Pure]
        public ColoredString OnBlack()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.Black);

        [Pure]
        public ColoredString OnDarkBlue()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString OnDarkGreen()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString OnDarkCyan()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString OnDarkRed()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString OnDarkMagenta()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString OnDarkYellow()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString OnGray()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.Gray);

        [Pure]
        public ColoredString OnDarkGray()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString OnBlue()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.Blue);

        [Pure]
        public ColoredString OnGreen()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.Green);

        [Pure]
        public ColoredString OnCyan()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.Cyan);

        [Pure]
        public ColoredString OnRed()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.Red);

        [Pure]
        public ColoredString OnMagenta()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.Magenta);

        [Pure]
        public ColoredString OnYellow()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.Yellow);

        [Pure]
        public ColoredString OnWhite()
            => new ColoredString(Text, ForegroundColor, ConsoleColor.White);

        #endregion

        #region XxxOnYyy()
        [Pure]
        public ColoredString BlackOnBlack()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.Black);

        [Pure]
        public ColoredString BlackOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString BlackOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString BlackOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString BlackOnDarkRed()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString BlackOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString BlackOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString BlackOnGray()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.Gray);

        [Pure]
        public ColoredString BlackOnDarkGray()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString BlackOnBlue()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.Blue);

        [Pure]
        public ColoredString BlackOnGreen()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.Green);

        [Pure]
        public ColoredString BlackOnCyan()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.Cyan);

        [Pure]
        public ColoredString BlackOnRed()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.Red);

        [Pure]
        public ColoredString BlackOnMagenta()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.Magenta);

        [Pure]
        public ColoredString BlackOnYellow()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.Yellow);

        [Pure]
        public ColoredString BlackOnWhite()
            => new ColoredString(Text, ConsoleColor.Black, ConsoleColor.White);

        [Pure]
        public ColoredString DarkBlueOnBlack()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.Black);

        [Pure]
        public ColoredString DarkBlueOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString DarkBlueOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString DarkBlueOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString DarkBlueOnDarkRed()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString DarkBlueOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString DarkBlueOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString DarkBlueOnGray()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.Gray);

        [Pure]
        public ColoredString DarkBlueOnDarkGray()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString DarkBlueOnBlue()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.Blue);

        [Pure]
        public ColoredString DarkBlueOnGreen()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.Green);

        [Pure]
        public ColoredString DarkBlueOnCyan()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.Cyan);

        [Pure]
        public ColoredString DarkBlueOnRed()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.Red);

        [Pure]
        public ColoredString DarkBlueOnMagenta()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.Magenta);

        [Pure]
        public ColoredString DarkBlueOnYellow()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.Yellow);

        [Pure]
        public ColoredString DarkBlueOnWhite()
            => new ColoredString(Text, ConsoleColor.DarkBlue, ConsoleColor.White);

        [Pure]
        public ColoredString DarkGreenOnBlack()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.Black);

        [Pure]
        public ColoredString DarkGreenOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString DarkGreenOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString DarkGreenOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString DarkGreenOnDarkRed()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString DarkGreenOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString DarkGreenOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString DarkGreenOnGray()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.Gray);

        [Pure]
        public ColoredString DarkGreenOnDarkGray()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString DarkGreenOnBlue()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.Blue);

        [Pure]
        public ColoredString DarkGreenOnGreen()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.Green);

        [Pure]
        public ColoredString DarkGreenOnCyan()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.Cyan);

        [Pure]
        public ColoredString DarkGreenOnRed()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.Red);

        [Pure]
        public ColoredString DarkGreenOnMagenta()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.Magenta);

        [Pure]
        public ColoredString DarkGreenOnYellow()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.Yellow);

        [Pure]
        public ColoredString DarkGreenOnWhite()
            => new ColoredString(Text, ConsoleColor.DarkGreen, ConsoleColor.White);

        [Pure]
        public ColoredString DarkCyanOnBlack()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.Black);

        [Pure]
        public ColoredString DarkCyanOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString DarkCyanOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString DarkCyanOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString DarkCyanOnDarkRed()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString DarkCyanOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString DarkCyanOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString DarkCyanOnGray()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.Gray);

        [Pure]
        public ColoredString DarkCyanOnDarkGray()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString DarkCyanOnBlue()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.Blue);

        [Pure]
        public ColoredString DarkCyanOnGreen()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.Green);

        [Pure]
        public ColoredString DarkCyanOnCyan()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.Cyan);

        [Pure]
        public ColoredString DarkCyanOnRed()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.Red);

        [Pure]
        public ColoredString DarkCyanOnMagenta()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.Magenta);

        [Pure]
        public ColoredString DarkCyanOnYellow()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.Yellow);

        [Pure]
        public ColoredString DarkCyanOnWhite()
            => new ColoredString(Text, ConsoleColor.DarkCyan, ConsoleColor.White);

        [Pure]
        public ColoredString DarkRedOnBlack()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.Black);

        [Pure]
        public ColoredString DarkRedOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString DarkRedOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString DarkRedOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString DarkRedOnDarkRed()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString DarkRedOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString DarkRedOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString DarkRedOnGray()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.Gray);

        [Pure]
        public ColoredString DarkRedOnDarkGray()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString DarkRedOnBlue()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.Blue);

        [Pure]
        public ColoredString DarkRedOnGreen()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.Green);

        [Pure]
        public ColoredString DarkRedOnCyan()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.Cyan);

        [Pure]
        public ColoredString DarkRedOnRed()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.Red);

        [Pure]
        public ColoredString DarkRedOnMagenta()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.Magenta);

        [Pure]
        public ColoredString DarkRedOnYellow()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.Yellow);

        [Pure]
        public ColoredString DarkRedOnWhite()
            => new ColoredString(Text, ConsoleColor.DarkRed, ConsoleColor.White);

        [Pure]
        public ColoredString DarkMagentaOnBlack()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.Black);

        [Pure]
        public ColoredString DarkMagentaOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString DarkMagentaOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString DarkMagentaOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString DarkMagentaOnDarkRed()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString DarkMagentaOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString DarkMagentaOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString DarkMagentaOnGray()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.Gray);

        [Pure]
        public ColoredString DarkMagentaOnDarkGray()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString DarkMagentaOnBlue()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.Blue);

        [Pure]
        public ColoredString DarkMagentaOnGreen()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.Green);

        [Pure]
        public ColoredString DarkMagentaOnCyan()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.Cyan);

        [Pure]
        public ColoredString DarkMagentaOnRed()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.Red);

        [Pure]
        public ColoredString DarkMagentaOnMagenta()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.Magenta);

        [Pure]
        public ColoredString DarkMagentaOnYellow()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.Yellow);

        [Pure]
        public ColoredString DarkMagentaOnWhite()
            => new ColoredString(Text, ConsoleColor.DarkMagenta, ConsoleColor.White);

        [Pure]
        public ColoredString DarkYellowOnBlack()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.Black);

        [Pure]
        public ColoredString DarkYellowOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString DarkYellowOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString DarkYellowOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString DarkYellowOnDarkRed()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString DarkYellowOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString DarkYellowOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString DarkYellowOnGray()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.Gray);

        [Pure]
        public ColoredString DarkYellowOnDarkGray()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString DarkYellowOnBlue()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.Blue);

        [Pure]
        public ColoredString DarkYellowOnGreen()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.Green);

        [Pure]
        public ColoredString DarkYellowOnCyan()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.Cyan);

        [Pure]
        public ColoredString DarkYellowOnRed()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.Red);

        [Pure]
        public ColoredString DarkYellowOnMagenta()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.Magenta);

        [Pure]
        public ColoredString DarkYellowOnYellow()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.Yellow);

        [Pure]
        public ColoredString DarkYellowOnWhite()
            => new ColoredString(Text, ConsoleColor.DarkYellow, ConsoleColor.White);

        [Pure]
        public ColoredString GrayOnBlack()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.Black);

        [Pure]
        public ColoredString GrayOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString GrayOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString GrayOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString GrayOnDarkRed()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString GrayOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString GrayOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString GrayOnGray()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.Gray);

        [Pure]
        public ColoredString GrayOnDarkGray()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString GrayOnBlue()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.Blue);

        [Pure]
        public ColoredString GrayOnGreen()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.Green);

        [Pure]
        public ColoredString GrayOnCyan()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.Cyan);

        [Pure]
        public ColoredString GrayOnRed()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.Red);

        [Pure]
        public ColoredString GrayOnMagenta()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.Magenta);

        [Pure]
        public ColoredString GrayOnYellow()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.Yellow);

        [Pure]
        public ColoredString GrayOnWhite()
            => new ColoredString(Text, ConsoleColor.Gray, ConsoleColor.White);

        [Pure]
        public ColoredString DarkGrayOnBlack()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.Black);

        [Pure]
        public ColoredString DarkGrayOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString DarkGrayOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString DarkGrayOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString DarkGrayOnDarkRed()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString DarkGrayOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString DarkGrayOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString DarkGrayOnGray()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.Gray);

        [Pure]
        public ColoredString DarkGrayOnDarkGray()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString DarkGrayOnBlue()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.Blue);

        [Pure]
        public ColoredString DarkGrayOnGreen()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.Green);

        [Pure]
        public ColoredString DarkGrayOnCyan()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.Cyan);

        [Pure]
        public ColoredString DarkGrayOnRed()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.Red);

        [Pure]
        public ColoredString DarkGrayOnMagenta()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.Magenta);

        [Pure]
        public ColoredString DarkGrayOnYellow()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.Yellow);

        [Pure]
        public ColoredString DarkGrayOnWhite()
            => new ColoredString(Text, ConsoleColor.DarkGray, ConsoleColor.White);

        [Pure]
        public ColoredString BlueOnBlack()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.Black);

        [Pure]
        public ColoredString BlueOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString BlueOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString BlueOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString BlueOnDarkRed()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString BlueOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString BlueOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString BlueOnGray()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.Gray);

        [Pure]
        public ColoredString BlueOnDarkGray()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString BlueOnBlue()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.Blue);

        [Pure]
        public ColoredString BlueOnGreen()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.Green);

        [Pure]
        public ColoredString BlueOnCyan()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.Cyan);

        [Pure]
        public ColoredString BlueOnRed()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.Red);

        [Pure]
        public ColoredString BlueOnMagenta()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.Magenta);

        [Pure]
        public ColoredString BlueOnYellow()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.Yellow);

        [Pure]
        public ColoredString BlueOnWhite()
            => new ColoredString(Text, ConsoleColor.Blue, ConsoleColor.White);

        [Pure]
        public ColoredString GreenOnBlack()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.Black);

        [Pure]
        public ColoredString GreenOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString GreenOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString GreenOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString GreenOnDarkRed()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString GreenOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString GreenOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString GreenOnGray()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.Gray);

        [Pure]
        public ColoredString GreenOnDarkGray()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString GreenOnBlue()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.Blue);

        [Pure]
        public ColoredString GreenOnGreen()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.Green);

        [Pure]
        public ColoredString GreenOnCyan()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.Cyan);

        [Pure]
        public ColoredString GreenOnRed()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.Red);

        [Pure]
        public ColoredString GreenOnMagenta()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.Magenta);

        [Pure]
        public ColoredString GreenOnYellow()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.Yellow);

        [Pure]
        public ColoredString GreenOnWhite()
            => new ColoredString(Text, ConsoleColor.Green, ConsoleColor.White);

        [Pure]
        public ColoredString CyanOnBlack()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.Black);

        [Pure]
        public ColoredString CyanOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString CyanOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString CyanOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString CyanOnDarkRed()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString CyanOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString CyanOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString CyanOnGray()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.Gray);

        [Pure]
        public ColoredString CyanOnDarkGray()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString CyanOnBlue()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.Blue);

        [Pure]
        public ColoredString CyanOnGreen()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.Green);

        [Pure]
        public ColoredString CyanOnCyan()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.Cyan);

        [Pure]
        public ColoredString CyanOnRed()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.Red);

        [Pure]
        public ColoredString CyanOnMagenta()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.Magenta);

        [Pure]
        public ColoredString CyanOnYellow()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.Yellow);

        [Pure]
        public ColoredString CyanOnWhite()
            => new ColoredString(Text, ConsoleColor.Cyan, ConsoleColor.White);

        [Pure]
        public ColoredString RedOnBlack()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.Black);

        [Pure]
        public ColoredString RedOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString RedOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString RedOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString RedOnDarkRed()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString RedOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString RedOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString RedOnGray()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.Gray);

        [Pure]
        public ColoredString RedOnDarkGray()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString RedOnBlue()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.Blue);

        [Pure]
        public ColoredString RedOnGreen()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.Green);

        [Pure]
        public ColoredString RedOnCyan()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.Cyan);

        [Pure]
        public ColoredString RedOnRed()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.Red);

        [Pure]
        public ColoredString RedOnMagenta()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.Magenta);

        [Pure]
        public ColoredString RedOnYellow()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.Yellow);

        [Pure]
        public ColoredString RedOnWhite()
            => new ColoredString(Text, ConsoleColor.Red, ConsoleColor.White);

        [Pure]
        public ColoredString MagentaOnBlack()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.Black);

        [Pure]
        public ColoredString MagentaOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString MagentaOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString MagentaOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString MagentaOnDarkRed()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString MagentaOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString MagentaOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString MagentaOnGray()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.Gray);

        [Pure]
        public ColoredString MagentaOnDarkGray()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString MagentaOnBlue()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.Blue);

        [Pure]
        public ColoredString MagentaOnGreen()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.Green);

        [Pure]
        public ColoredString MagentaOnCyan()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.Cyan);

        [Pure]
        public ColoredString MagentaOnRed()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.Red);

        [Pure]
        public ColoredString MagentaOnMagenta()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.Magenta);

        [Pure]
        public ColoredString MagentaOnYellow()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.Yellow);

        [Pure]
        public ColoredString MagentaOnWhite()
            => new ColoredString(Text, ConsoleColor.Magenta, ConsoleColor.White);

        [Pure]
        public ColoredString YellowOnBlack()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.Black);

        [Pure]
        public ColoredString YellowOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString YellowOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString YellowOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString YellowOnDarkRed()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString YellowOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString YellowOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString YellowOnGray()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.Gray);

        [Pure]
        public ColoredString YellowOnDarkGray()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString YellowOnBlue()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.Blue);

        [Pure]
        public ColoredString YellowOnGreen()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.Green);

        [Pure]
        public ColoredString YellowOnCyan()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.Cyan);

        [Pure]
        public ColoredString YellowOnRed()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.Red);

        [Pure]
        public ColoredString YellowOnMagenta()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.Magenta);

        [Pure]
        public ColoredString YellowOnYellow()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.Yellow);

        [Pure]
        public ColoredString YellowOnWhite()
            => new ColoredString(Text, ConsoleColor.Yellow, ConsoleColor.White);

        [Pure]
        public ColoredString WhiteOnBlack()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.Black);

        [Pure]
        public ColoredString WhiteOnDarkBlue()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.DarkBlue);

        [Pure]
        public ColoredString WhiteOnDarkGreen()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.DarkGreen);

        [Pure]
        public ColoredString WhiteOnDarkCyan()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.DarkCyan);

        [Pure]
        public ColoredString WhiteOnDarkRed()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.DarkRed);

        [Pure]
        public ColoredString WhiteOnDarkMagenta()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.DarkMagenta);

        [Pure]
        public ColoredString WhiteOnDarkYellow()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.DarkYellow);

        [Pure]
        public ColoredString WhiteOnGray()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.Gray);

        [Pure]
        public ColoredString WhiteOnDarkGray()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.DarkGray);

        [Pure]
        public ColoredString WhiteOnBlue()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.Blue);

        [Pure]
        public ColoredString WhiteOnGreen()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.Green);

        [Pure]
        public ColoredString WhiteOnCyan()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.Cyan);

        [Pure]
        public ColoredString WhiteOnRed()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.Red);

        [Pure]
        public ColoredString WhiteOnMagenta()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.Magenta);

        [Pure]
        public ColoredString WhiteOnYellow()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.Yellow);

        [Pure]
        public ColoredString WhiteOnWhite()
            => new ColoredString(Text, ConsoleColor.White, ConsoleColor.White);

        #endregion 
    }
}