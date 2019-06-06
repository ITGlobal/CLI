using System;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class SystemTerminalWriter : TerminalWriterBase
    {
        private readonly TextWriter _writer;

        public SystemTerminalWriter(TextWriter writer)
        {
            _writer = writer;
        }

        protected override void WriteImpl(ColoredString str)
        {
            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;

            try
            {
                Console.ForegroundColor = str.ForegroundColor ?? fg;
                Console.BackgroundColor = str.BackgroundColor ?? bg;

                _writer.Write(str.Text);
            }
            finally
            {
                Console.ForegroundColor = fg;
                Console.BackgroundColor = bg;
            }
        }
    }
}