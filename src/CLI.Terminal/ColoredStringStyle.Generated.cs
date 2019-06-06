using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    partial class ColoredStringStyle
    {
        #region Xxx()

        [NotNull]
        public static IColoredStringStyle Black { get; } = Create(ConsoleColor.Black, null);

        [NotNull]
        public static IColoredStringStyle DarkBlue { get; } = Create(ConsoleColor.DarkBlue, null);

        [NotNull]
        public static IColoredStringStyle DarkGreen { get; } = Create(ConsoleColor.DarkGreen, null);

        [NotNull]
        public static IColoredStringStyle DarkCyan { get; } = Create(ConsoleColor.DarkCyan, null);

        [NotNull]
        public static IColoredStringStyle DarkRed { get; } = Create(ConsoleColor.DarkRed, null);

        [NotNull]
        public static IColoredStringStyle DarkMagenta { get; } = Create(ConsoleColor.DarkMagenta, null);

        [NotNull]
        public static IColoredStringStyle DarkYellow { get; } = Create(ConsoleColor.DarkYellow, null);

        [NotNull]
        public static IColoredStringStyle Gray { get; } = Create(ConsoleColor.Gray, null);

        [NotNull]
        public static IColoredStringStyle DarkGray { get; } = Create(ConsoleColor.DarkGray, null);

        [NotNull]
        public static IColoredStringStyle Blue { get; } = Create(ConsoleColor.Blue, null);

        [NotNull]
        public static IColoredStringStyle Green { get; } = Create(ConsoleColor.Green, null);

        [NotNull]
        public static IColoredStringStyle Cyan { get; } = Create(ConsoleColor.Cyan, null);

        [NotNull]
        public static IColoredStringStyle Red { get; } = Create(ConsoleColor.Red, null);

        [NotNull]
        public static IColoredStringStyle Magenta { get; } = Create(ConsoleColor.Magenta, null);

        [NotNull]
        public static IColoredStringStyle Yellow { get; } = Create(ConsoleColor.Yellow, null);

        [NotNull]
        public static IColoredStringStyle White { get; } = Create(ConsoleColor.White, null);

        #endregion 

        #region OnXxx()

        [NotNull]
        public static IColoredStringStyle OnBlack { get; } = Create(null, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle OnDarkBlue { get; } = Create(null, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle OnDarkGreen { get; } = Create(null, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle OnDarkCyan { get; } = Create(null, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle OnDarkRed { get; } = Create(null, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle OnDarkMagenta { get; } = Create(null, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle OnDarkYellow { get; } = Create(null, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle OnGray { get; } = Create(null, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle OnDarkGray { get; } = Create(null, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle OnBlue { get; } = Create(null, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle OnGreen { get; } = Create(null, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle OnCyan { get; } = Create(null, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle OnRed { get; } = Create(null, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle OnMagenta { get; } = Create(null, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle OnYellow { get; } = Create(null, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle OnWhite { get; } = Create(null, ConsoleColor.White);

        #endregion

        #region XxxOnYyy()
        [NotNull]
        public static IColoredStringStyle BlackOnBlack { get; } = Create(ConsoleColor.Black, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle BlackOnDarkBlue { get; } = Create(ConsoleColor.Black, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle BlackOnDarkGreen { get; } = Create(ConsoleColor.Black, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle BlackOnDarkCyan { get; } = Create(ConsoleColor.Black, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle BlackOnDarkRed { get; } = Create(ConsoleColor.Black, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle BlackOnDarkMagenta { get; } = Create(ConsoleColor.Black, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle BlackOnDarkYellow { get; } = Create(ConsoleColor.Black, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle BlackOnGray { get; } = Create(ConsoleColor.Black, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle BlackOnDarkGray { get; } = Create(ConsoleColor.Black, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle BlackOnBlue { get; } = Create(ConsoleColor.Black, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle BlackOnGreen { get; } = Create(ConsoleColor.Black, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle BlackOnCyan { get; } = Create(ConsoleColor.Black, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle BlackOnRed { get; } = Create(ConsoleColor.Black, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle BlackOnMagenta { get; } = Create(ConsoleColor.Black, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle BlackOnYellow { get; } = Create(ConsoleColor.Black, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle BlackOnWhite { get; } = Create(ConsoleColor.Black, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnBlack { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnDarkBlue { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnDarkGreen { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnDarkCyan { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnDarkRed { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnDarkMagenta { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnDarkYellow { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnGray { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnDarkGray { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnBlue { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnGreen { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnCyan { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnRed { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnMagenta { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnYellow { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle DarkBlueOnWhite { get; } = Create(ConsoleColor.DarkBlue, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnBlack { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnDarkBlue { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnDarkGreen { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnDarkCyan { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnDarkRed { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnDarkMagenta { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnDarkYellow { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnGray { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnDarkGray { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnBlue { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnGreen { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnCyan { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnRed { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnMagenta { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnYellow { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle DarkGreenOnWhite { get; } = Create(ConsoleColor.DarkGreen, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnBlack { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnDarkBlue { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnDarkGreen { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnDarkCyan { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnDarkRed { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnDarkMagenta { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnDarkYellow { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnGray { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnDarkGray { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnBlue { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnGreen { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnCyan { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnRed { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnMagenta { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnYellow { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle DarkCyanOnWhite { get; } = Create(ConsoleColor.DarkCyan, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle DarkRedOnBlack { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle DarkRedOnDarkBlue { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle DarkRedOnDarkGreen { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle DarkRedOnDarkCyan { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle DarkRedOnDarkRed { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle DarkRedOnDarkMagenta { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle DarkRedOnDarkYellow { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle DarkRedOnGray { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle DarkRedOnDarkGray { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle DarkRedOnBlue { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle DarkRedOnGreen { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle DarkRedOnCyan { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle DarkRedOnRed { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle DarkRedOnMagenta { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle DarkRedOnYellow { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle DarkRedOnWhite { get; } = Create(ConsoleColor.DarkRed, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnBlack { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnDarkBlue { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnDarkGreen { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnDarkCyan { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnDarkRed { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnDarkMagenta { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnDarkYellow { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnGray { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnDarkGray { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnBlue { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnGreen { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnCyan { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnRed { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnMagenta { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnYellow { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle DarkMagentaOnWhite { get; } = Create(ConsoleColor.DarkMagenta, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnBlack { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnDarkBlue { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnDarkGreen { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnDarkCyan { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnDarkRed { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnDarkMagenta { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnDarkYellow { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnGray { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnDarkGray { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnBlue { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnGreen { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnCyan { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnRed { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnMagenta { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnYellow { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle DarkYellowOnWhite { get; } = Create(ConsoleColor.DarkYellow, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle GrayOnBlack { get; } = Create(ConsoleColor.Gray, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle GrayOnDarkBlue { get; } = Create(ConsoleColor.Gray, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle GrayOnDarkGreen { get; } = Create(ConsoleColor.Gray, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle GrayOnDarkCyan { get; } = Create(ConsoleColor.Gray, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle GrayOnDarkRed { get; } = Create(ConsoleColor.Gray, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle GrayOnDarkMagenta { get; } = Create(ConsoleColor.Gray, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle GrayOnDarkYellow { get; } = Create(ConsoleColor.Gray, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle GrayOnGray { get; } = Create(ConsoleColor.Gray, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle GrayOnDarkGray { get; } = Create(ConsoleColor.Gray, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle GrayOnBlue { get; } = Create(ConsoleColor.Gray, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle GrayOnGreen { get; } = Create(ConsoleColor.Gray, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle GrayOnCyan { get; } = Create(ConsoleColor.Gray, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle GrayOnRed { get; } = Create(ConsoleColor.Gray, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle GrayOnMagenta { get; } = Create(ConsoleColor.Gray, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle GrayOnYellow { get; } = Create(ConsoleColor.Gray, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle GrayOnWhite { get; } = Create(ConsoleColor.Gray, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnBlack { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnDarkBlue { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnDarkGreen { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnDarkCyan { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnDarkRed { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnDarkMagenta { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnDarkYellow { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnGray { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnDarkGray { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnBlue { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnGreen { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnCyan { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnRed { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnMagenta { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnYellow { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle DarkGrayOnWhite { get; } = Create(ConsoleColor.DarkGray, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle BlueOnBlack { get; } = Create(ConsoleColor.Blue, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle BlueOnDarkBlue { get; } = Create(ConsoleColor.Blue, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle BlueOnDarkGreen { get; } = Create(ConsoleColor.Blue, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle BlueOnDarkCyan { get; } = Create(ConsoleColor.Blue, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle BlueOnDarkRed { get; } = Create(ConsoleColor.Blue, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle BlueOnDarkMagenta { get; } = Create(ConsoleColor.Blue, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle BlueOnDarkYellow { get; } = Create(ConsoleColor.Blue, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle BlueOnGray { get; } = Create(ConsoleColor.Blue, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle BlueOnDarkGray { get; } = Create(ConsoleColor.Blue, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle BlueOnBlue { get; } = Create(ConsoleColor.Blue, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle BlueOnGreen { get; } = Create(ConsoleColor.Blue, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle BlueOnCyan { get; } = Create(ConsoleColor.Blue, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle BlueOnRed { get; } = Create(ConsoleColor.Blue, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle BlueOnMagenta { get; } = Create(ConsoleColor.Blue, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle BlueOnYellow { get; } = Create(ConsoleColor.Blue, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle BlueOnWhite { get; } = Create(ConsoleColor.Blue, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle GreenOnBlack { get; } = Create(ConsoleColor.Green, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle GreenOnDarkBlue { get; } = Create(ConsoleColor.Green, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle GreenOnDarkGreen { get; } = Create(ConsoleColor.Green, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle GreenOnDarkCyan { get; } = Create(ConsoleColor.Green, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle GreenOnDarkRed { get; } = Create(ConsoleColor.Green, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle GreenOnDarkMagenta { get; } = Create(ConsoleColor.Green, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle GreenOnDarkYellow { get; } = Create(ConsoleColor.Green, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle GreenOnGray { get; } = Create(ConsoleColor.Green, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle GreenOnDarkGray { get; } = Create(ConsoleColor.Green, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle GreenOnBlue { get; } = Create(ConsoleColor.Green, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle GreenOnGreen { get; } = Create(ConsoleColor.Green, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle GreenOnCyan { get; } = Create(ConsoleColor.Green, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle GreenOnRed { get; } = Create(ConsoleColor.Green, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle GreenOnMagenta { get; } = Create(ConsoleColor.Green, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle GreenOnYellow { get; } = Create(ConsoleColor.Green, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle GreenOnWhite { get; } = Create(ConsoleColor.Green, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle CyanOnBlack { get; } = Create(ConsoleColor.Cyan, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle CyanOnDarkBlue { get; } = Create(ConsoleColor.Cyan, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle CyanOnDarkGreen { get; } = Create(ConsoleColor.Cyan, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle CyanOnDarkCyan { get; } = Create(ConsoleColor.Cyan, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle CyanOnDarkRed { get; } = Create(ConsoleColor.Cyan, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle CyanOnDarkMagenta { get; } = Create(ConsoleColor.Cyan, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle CyanOnDarkYellow { get; } = Create(ConsoleColor.Cyan, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle CyanOnGray { get; } = Create(ConsoleColor.Cyan, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle CyanOnDarkGray { get; } = Create(ConsoleColor.Cyan, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle CyanOnBlue { get; } = Create(ConsoleColor.Cyan, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle CyanOnGreen { get; } = Create(ConsoleColor.Cyan, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle CyanOnCyan { get; } = Create(ConsoleColor.Cyan, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle CyanOnRed { get; } = Create(ConsoleColor.Cyan, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle CyanOnMagenta { get; } = Create(ConsoleColor.Cyan, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle CyanOnYellow { get; } = Create(ConsoleColor.Cyan, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle CyanOnWhite { get; } = Create(ConsoleColor.Cyan, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle RedOnBlack { get; } = Create(ConsoleColor.Red, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle RedOnDarkBlue { get; } = Create(ConsoleColor.Red, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle RedOnDarkGreen { get; } = Create(ConsoleColor.Red, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle RedOnDarkCyan { get; } = Create(ConsoleColor.Red, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle RedOnDarkRed { get; } = Create(ConsoleColor.Red, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle RedOnDarkMagenta { get; } = Create(ConsoleColor.Red, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle RedOnDarkYellow { get; } = Create(ConsoleColor.Red, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle RedOnGray { get; } = Create(ConsoleColor.Red, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle RedOnDarkGray { get; } = Create(ConsoleColor.Red, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle RedOnBlue { get; } = Create(ConsoleColor.Red, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle RedOnGreen { get; } = Create(ConsoleColor.Red, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle RedOnCyan { get; } = Create(ConsoleColor.Red, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle RedOnRed { get; } = Create(ConsoleColor.Red, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle RedOnMagenta { get; } = Create(ConsoleColor.Red, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle RedOnYellow { get; } = Create(ConsoleColor.Red, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle RedOnWhite { get; } = Create(ConsoleColor.Red, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle MagentaOnBlack { get; } = Create(ConsoleColor.Magenta, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle MagentaOnDarkBlue { get; } = Create(ConsoleColor.Magenta, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle MagentaOnDarkGreen { get; } = Create(ConsoleColor.Magenta, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle MagentaOnDarkCyan { get; } = Create(ConsoleColor.Magenta, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle MagentaOnDarkRed { get; } = Create(ConsoleColor.Magenta, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle MagentaOnDarkMagenta { get; } = Create(ConsoleColor.Magenta, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle MagentaOnDarkYellow { get; } = Create(ConsoleColor.Magenta, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle MagentaOnGray { get; } = Create(ConsoleColor.Magenta, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle MagentaOnDarkGray { get; } = Create(ConsoleColor.Magenta, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle MagentaOnBlue { get; } = Create(ConsoleColor.Magenta, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle MagentaOnGreen { get; } = Create(ConsoleColor.Magenta, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle MagentaOnCyan { get; } = Create(ConsoleColor.Magenta, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle MagentaOnRed { get; } = Create(ConsoleColor.Magenta, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle MagentaOnMagenta { get; } = Create(ConsoleColor.Magenta, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle MagentaOnYellow { get; } = Create(ConsoleColor.Magenta, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle MagentaOnWhite { get; } = Create(ConsoleColor.Magenta, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle YellowOnBlack { get; } = Create(ConsoleColor.Yellow, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle YellowOnDarkBlue { get; } = Create(ConsoleColor.Yellow, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle YellowOnDarkGreen { get; } = Create(ConsoleColor.Yellow, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle YellowOnDarkCyan { get; } = Create(ConsoleColor.Yellow, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle YellowOnDarkRed { get; } = Create(ConsoleColor.Yellow, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle YellowOnDarkMagenta { get; } = Create(ConsoleColor.Yellow, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle YellowOnDarkYellow { get; } = Create(ConsoleColor.Yellow, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle YellowOnGray { get; } = Create(ConsoleColor.Yellow, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle YellowOnDarkGray { get; } = Create(ConsoleColor.Yellow, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle YellowOnBlue { get; } = Create(ConsoleColor.Yellow, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle YellowOnGreen { get; } = Create(ConsoleColor.Yellow, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle YellowOnCyan { get; } = Create(ConsoleColor.Yellow, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle YellowOnRed { get; } = Create(ConsoleColor.Yellow, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle YellowOnMagenta { get; } = Create(ConsoleColor.Yellow, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle YellowOnYellow { get; } = Create(ConsoleColor.Yellow, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle YellowOnWhite { get; } = Create(ConsoleColor.Yellow, ConsoleColor.White);

        [NotNull]
        public static IColoredStringStyle WhiteOnBlack { get; } = Create(ConsoleColor.White, ConsoleColor.Black);

        [NotNull]
        public static IColoredStringStyle WhiteOnDarkBlue { get; } = Create(ConsoleColor.White, ConsoleColor.DarkBlue);

        [NotNull]
        public static IColoredStringStyle WhiteOnDarkGreen { get; } = Create(ConsoleColor.White, ConsoleColor.DarkGreen);

        [NotNull]
        public static IColoredStringStyle WhiteOnDarkCyan { get; } = Create(ConsoleColor.White, ConsoleColor.DarkCyan);

        [NotNull]
        public static IColoredStringStyle WhiteOnDarkRed { get; } = Create(ConsoleColor.White, ConsoleColor.DarkRed);

        [NotNull]
        public static IColoredStringStyle WhiteOnDarkMagenta { get; } = Create(ConsoleColor.White, ConsoleColor.DarkMagenta);

        [NotNull]
        public static IColoredStringStyle WhiteOnDarkYellow { get; } = Create(ConsoleColor.White, ConsoleColor.DarkYellow);

        [NotNull]
        public static IColoredStringStyle WhiteOnGray { get; } = Create(ConsoleColor.White, ConsoleColor.Gray);

        [NotNull]
        public static IColoredStringStyle WhiteOnDarkGray { get; } = Create(ConsoleColor.White, ConsoleColor.DarkGray);

        [NotNull]
        public static IColoredStringStyle WhiteOnBlue { get; } = Create(ConsoleColor.White, ConsoleColor.Blue);

        [NotNull]
        public static IColoredStringStyle WhiteOnGreen { get; } = Create(ConsoleColor.White, ConsoleColor.Green);

        [NotNull]
        public static IColoredStringStyle WhiteOnCyan { get; } = Create(ConsoleColor.White, ConsoleColor.Cyan);

        [NotNull]
        public static IColoredStringStyle WhiteOnRed { get; } = Create(ConsoleColor.White, ConsoleColor.Red);

        [NotNull]
        public static IColoredStringStyle WhiteOnMagenta { get; } = Create(ConsoleColor.White, ConsoleColor.Magenta);

        [NotNull]
        public static IColoredStringStyle WhiteOnYellow { get; } = Create(ConsoleColor.White, ConsoleColor.Yellow);

        [NotNull]
        public static IColoredStringStyle WhiteOnWhite { get; } = Create(ConsoleColor.White, ConsoleColor.White);

        #endregion 
    }
}
