using System;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class AnsiTerminalImplementation : ITerminalImplementation
    {
        private readonly TextWriter _stderr;

        public AnsiTerminalImplementation()
        {
            _stderr = Console.Error;

            Stdout = new SystemTerminalWriter(Console.Out);
            Stderr = new SystemTerminalWriter(Console.Error);
        }

        public ITerminalWriter Stdout { get; }

        public ITerminalWriter Stderr { get; }

        public void MoveToLine(int offset)
        {
            string cmd;
            if(offset > 0)
            {
                cmd = Ansi.CUD(offset);
            }
            else if(offset < 0)
            {
                cmd = Ansi.CUU(-offset);
            }
            else
            {
                return;
            }
           
            _stderr.Write(cmd);            
            _stderr.Flush();
        }

        public void ClearLine()
        {
            _stderr.Write('\r');
            _stderr.Write(Ansi.EL);
            _stderr.Write('\r');
            
            _stderr.Flush();
        }
    }
}
