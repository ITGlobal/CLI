using System;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class NoColorTerminalImplementation : ITerminalImplementation
    {
        private readonly ITerminalImplementation _impl;
        private readonly TextWriter _originalStdErr;
        private readonly TextWriter _originalStdOut;

        public NoColorTerminalImplementation(ITerminalImplementation impl)
        {
            _impl = impl;

            Stdout = new TrimAnsiTerminalWriter(impl.Stdout);
            Stderr = new TrimAnsiTerminalWriter(impl.Stderr);
            DriverName = $"{impl.DriverName} (NoColor)";

            _originalStdErr = Console.Error;
            _originalStdOut = Console.Out;
        }

        public ITerminalWriter Stdout { get; }
        public ITerminalWriter Stderr { get; }
        public string DriverName { get; }
        public int WindowWidth => _impl.WindowWidth;

        public ITerminalImplementation Clone()
        {
           return new NoColorTerminalImplementation(_impl);
        }

        public void Initialize()
        {
            Console.SetError(new TrimAnsiTextWriter(Console.Error));
            Console.SetOut(new TrimAnsiTextWriter(Console.Out));
        }

        public void MoveToLine(int offset) => _impl.MoveToLine(offset);

        public void ClearLine() => _impl.ClearLine();
        public void Dispose()
        {
            Console.SetError(_originalStdErr);
            Console.SetOut(_originalStdOut);

            _impl.Dispose();
        }
    }
}