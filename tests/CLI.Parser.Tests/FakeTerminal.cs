using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Parsing
{
    public sealed class FakeTerminal : ITerminal
    {
        public ITerminalInput Stdin { get; } = new FakeTerminalInput();
        public ITerminalOutput Stdout { get; } = new FakeTerminalOutput();
        public ITerminalOutput Stderr { get; } = new FakeTerminalOutput();

        private sealed class FakeTerminalInput : ITerminalInput
        {
            public bool IsRedirected => true;
            public Encoding Encoding { get; set; } = Encoding.Default;

            public TextReader CreateReader() => new StringReader("");

            public IDisposable AttachCancelKeyHandler(CancelKeyHandler handler)
            {
                return new DisposableToken();
            }

            public ConsoleKeyInfo ReadKey(bool intercept = true) => new ConsoleKeyInfo('\0', 0, false, false, false);
        }

        private sealed class DisposableToken : IDisposable
        {
            public void Dispose() { }
        }

        private sealed class FakeTerminalOutput : ITerminalOutput
        {
            public bool IsRedirected => true;
            public Encoding Encoding { get; set; } = Encoding.Default;
            public int WindowHeight => 24;
            public int WindowWidth => 80;
            public bool IsCursorVisible { get; set; }

            public TextWriter CreateWriter() => new StringWriter();

            public void MoveCursor(int? left = null, int? top = null) { }

            public void Write(TerminalString str) { }

            public void Write(params TerminalString[] strs) { }

            public void Write(string format, params object[] args) { }

            public void WriteLine() { }

            public void WriteLine(TerminalString str) { }

            public void WriteLine(params TerminalString[] strs) { }

            public void WriteLine(string format, params object[] args) { }

            public void Clear() { }

            public ColorChangeToken WithColors(ConsoleColor? fg, ConsoleColor? bg) => new ColorChangeToken();

            public ColorChangeToken WithForeground(ConsoleColor color) => new ColorChangeToken();

            public ColorChangeToken WithBackground(ConsoleColor color) => new ColorChangeToken();
        }
    }
}