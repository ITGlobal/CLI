using System;

namespace ITGlobal.CommandLine
{

    public interface ILiveOutput : IDisposable
    {
        void Write(params ColoredString[] strs);
        void WriteLine(params ColoredString[] strs);
        void Clear();
    }
}
