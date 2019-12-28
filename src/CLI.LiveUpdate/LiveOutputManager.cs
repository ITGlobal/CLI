using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class LiveOutputManager
    {
        [NotNull]
        public static ILiveOutputManager Create(
            ISpinnerRenderer spinnerRenderer = null, 
            IProgressBarRenderer progressBarRenderer = null)
        {
            Terminal.Initialize();

            return new LiveOutputManagerImpl(
                spinnerRenderer ?? SpinnerRenderer.Default,
                progressBarRenderer ?? ProgressBarRenderer.Default
            );
        }
    }
}