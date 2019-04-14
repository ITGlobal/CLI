namespace ITGlobal.CommandLine.Impl
{
    internal interface ITerminalLockOwner
    {
        void BeginPrint();
        void Redraw();
        void EndPrint();
    }
}