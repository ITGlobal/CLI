namespace ITGlobal.CommandLine.Internals
{
    internal interface ITerminalLockOwner
    {
        void BeginPrint();
        void Redraw();
        void EndPrint();
    }
}