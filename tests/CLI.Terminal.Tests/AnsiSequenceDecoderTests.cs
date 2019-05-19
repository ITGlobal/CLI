using System;
using System.Linq;
using ITGlobal.CommandLine.Impl;
using Xunit;
using Xunit.Abstractions;

namespace ITGlobal.CommandLine
{
    public class AnsiSequenceDecoderTests
    {
        private readonly ITestOutputHelper _output;

        public AnsiSequenceDecoderTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Plain_text()
        {
            var handler = Run("test");
            handler.Verify(new[]
                {
                    AnsiCommand.Write('t'),
                    AnsiCommand.Write('e'),
                    AnsiCommand.Write('s'),
                    AnsiCommand.Write('t')
                }
            );
        }

        [Theory]
        [InlineData("first\nsecond")]
        [InlineData("first\r\nsecond")]
        public void Plain_multiline_text(string text)
        {
            var handler = Run(text);

            handler.Verify(text.Select(AnsiCommand.Write).ToArray());
        }

        [Fact]
        public void SGR_DEFAULT()
        {
            var handler = Run(Ansi.SGR_DEFAULT);

            handler.Verify(new[]
                {
                    AnsiCommand.ResetColors(),
                }
            );
        }

        [Theory]
        [InlineData(ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Red)]
        [InlineData(ConsoleColor.Green)]
        [InlineData(ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.White)]
        public void SGR_foreground_only(ConsoleColor fg)
        {
            var handler = Run(Ansi.SGR(Ansi.ForegroundColorToAttributes(fg)), "Test");

            handler.Verify(new[]
                {
                    AnsiCommand.SetForegroundColor(fg),
                    AnsiCommand.Write('T'),
                    AnsiCommand.Write('e'),
                    AnsiCommand.Write('s'),
                    AnsiCommand.Write('t')
                }
            );
        }

        [Theory]
        [InlineData(ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Red)]
        [InlineData(ConsoleColor.Green)]
        [InlineData(ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.White)]
        public void SGR_background_only(ConsoleColor bg)
        {
            var handler = Run(Ansi.SGR(Ansi.BackgroundColorToAttributes(bg)), "Test");

            handler.Verify(new[]
                {
                    AnsiCommand.SetBackgroundColor(bg),
                    AnsiCommand.Write('T'),
                    AnsiCommand.Write('e'),
                    AnsiCommand.Write('s'),
                    AnsiCommand.Write('t')
                }
            );
        }

        [Theory]
        [InlineData(ConsoleColor.Black, ConsoleColor.Black)]
        [InlineData(ConsoleColor.Black, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.Black, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.Black, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.Black, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.Black, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.Black, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.Black, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Black, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Black, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Black, ConsoleColor.Green)]
        [InlineData(ConsoleColor.Black, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.Black, ConsoleColor.Red)]
        [InlineData(ConsoleColor.Black, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Black, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Black, ConsoleColor.White)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.Green)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.Red)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.DarkBlue, ConsoleColor.White)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.Green)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.Red)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.DarkGreen, ConsoleColor.White)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.Green)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.Red)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.DarkCyan, ConsoleColor.White)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.Green)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.Red)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.DarkRed, ConsoleColor.White)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.Green)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.Red)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.DarkMagenta, ConsoleColor.White)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.Green)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.Red)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.DarkYellow, ConsoleColor.White)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.Black)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.Green)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.Red)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Gray, ConsoleColor.White)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.Black)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.Green)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.Red)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.DarkGray, ConsoleColor.White)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.Black)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.Green)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.Red)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Blue, ConsoleColor.White)]
        [InlineData(ConsoleColor.Green, ConsoleColor.Black)]
        [InlineData(ConsoleColor.Green, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.Green, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.Green, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.Green, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.Green, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.Green, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.Green, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Green, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Green, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Green, ConsoleColor.Green)]
        [InlineData(ConsoleColor.Green, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.Green, ConsoleColor.Red)]
        [InlineData(ConsoleColor.Green, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Green, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Green, ConsoleColor.White)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.Black)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.Green)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.Red)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Cyan, ConsoleColor.White)]
        [InlineData(ConsoleColor.Red, ConsoleColor.Black)]
        [InlineData(ConsoleColor.Red, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.Red, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.Red, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.Red, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.Red, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.Red, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.Red, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Red, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Red, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Red, ConsoleColor.Green)]
        [InlineData(ConsoleColor.Red, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.Red, ConsoleColor.Red)]
        [InlineData(ConsoleColor.Red, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Red, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Red, ConsoleColor.White)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.Black)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.Green)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.Red)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Magenta, ConsoleColor.White)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.Black)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.Green)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.Red)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.Yellow, ConsoleColor.White)]
        [InlineData(ConsoleColor.White, ConsoleColor.Black)]
        [InlineData(ConsoleColor.White, ConsoleColor.DarkBlue)]
        [InlineData(ConsoleColor.White, ConsoleColor.DarkGreen)]
        [InlineData(ConsoleColor.White, ConsoleColor.DarkCyan)]
        [InlineData(ConsoleColor.White, ConsoleColor.DarkRed)]
        [InlineData(ConsoleColor.White, ConsoleColor.DarkMagenta)]
        [InlineData(ConsoleColor.White, ConsoleColor.DarkYellow)]
        [InlineData(ConsoleColor.White, ConsoleColor.Gray)]
        [InlineData(ConsoleColor.White, ConsoleColor.DarkGray)]
        [InlineData(ConsoleColor.White, ConsoleColor.Blue)]
        [InlineData(ConsoleColor.White, ConsoleColor.Green)]
        [InlineData(ConsoleColor.White, ConsoleColor.Cyan)]
        [InlineData(ConsoleColor.White, ConsoleColor.Red)]
        [InlineData(ConsoleColor.White, ConsoleColor.Magenta)]
        [InlineData(ConsoleColor.White, ConsoleColor.Yellow)]
        [InlineData(ConsoleColor.White, ConsoleColor.White)]
        public void SGR_both_foreground_and_background(ConsoleColor fg, ConsoleColor bg)
        {
            var handler = Run(
                Ansi.SGR(Ansi.ForegroundColorToAttributes(fg),
                Ansi.BackgroundColorToAttributes(bg)),
                "Test"
            );

            handler.Verify(new[]
                {
                    AnsiCommand.SetForegroundColor(fg),
                    AnsiCommand.SetBackgroundColor(bg),
                    AnsiCommand.Write('T'),
                    AnsiCommand.Write('e'),
                    AnsiCommand.Write('s'),
                    AnsiCommand.Write('t')
                }
            );
        }

        private AnsiCommandHandler Run(params string[] input)
        {
            var handler = new AnsiCommandHandler(_output);

            var decoder = new AnsiSequenceDecoder(handler);
            foreach (var s in input)
            {
                foreach (var c in s)
                {
                    decoder.Process(c);
                }
            }

            return handler;
        }
    }
}