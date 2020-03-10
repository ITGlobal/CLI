using System;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class WindowsTerminalAnsiTextWriter : AnsiTextWriterBase
    {
        private readonly WindowsTerminalWriteQueue _queue;
        private readonly ConsoleStream _stream;

        public WindowsTerminalAnsiTextWriter(Encoding encoding, WindowsTerminalWriteQueue queue, ConsoleStream stream)
            : base(encoding)
        {
            _queue = queue;
            _stream = stream;
        }

        protected override void WriteImpl(char c, ConsoleColor? fg, ConsoleColor? bg)
        {
            _queue.Enqueue(c, fg, bg, _stream);
        }

        public override void Flush()
        {
            _queue.Flush();
        }
    }
}