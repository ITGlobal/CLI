namespace ITGlobal.CommandLine.Example
{
    public static class ConsoleNestedColorsDemo
    {
        public static void Run()
        {
            using (var liveOutput = LiveOutputManager.Create())
            {
                var w = liveOutput.CreateSpinner();

                w.Write($"Sending request {"#1".Cyan()}...".Yellow());

                using (var ctrlC = Terminal.OnCtrlC())
                {
                    ctrlC.CancellationToken.WaitHandle.WaitOne();
                }
            }
        }
    }
}