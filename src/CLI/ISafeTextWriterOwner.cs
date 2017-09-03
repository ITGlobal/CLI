namespace ITGlobal.CommandLine
{
    internal interface ISafeTextWriterOwner
    {
        void BeginPrint();
        void EndPrint();
        void Redraw();
    }
}