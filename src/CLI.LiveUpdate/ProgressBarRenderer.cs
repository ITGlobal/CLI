using ITGlobal.CommandLine.Impl;

namespace ITGlobal.CommandLine
{
    public static class ProgressBarRenderer
    {
        private const int DEFAULT_WIDTH = 24;

        public static IProgressBarRenderer Default { get; set; } = Arrow();

        public static IProgressBarRenderer Arrow(
            ProgressBarLocation? location = null,
            int? width = null,
            IColoredStringStyle frameStyle = null,
            IColoredStringStyle fillStyle = null,
            IColoredStringStyle tipStyle = null,
            IColoredStringStyle emptyStyle = null
        )
        {
            return new ArrowProgressBarRendererImpl(
                location: location ?? ProgressBarLocation.Leading,
                width: width ?? DEFAULT_WIDTH,
                frameStyle: frameStyle ?? ColoredStringStyle.Null,
                fillStyle: fillStyle ?? ColoredStringStyle.Cyan,
                tipStyle: tipStyle ?? ColoredStringStyle.Cyan,
                emptyStyle: emptyStyle ?? ColoredStringStyle.Null
            );
        }

        public static IProgressBarRenderer HashSign(
            ProgressBarLocation? location = null,
            int? width = null,
            IColoredStringStyle frameStyle = null,
            IColoredStringStyle fillStyle = null,
            IColoredStringStyle emptyStyle = null
        )
        {
            return new HashSignProgressBarRendererImpl(
                location: location ?? ProgressBarLocation.Leading,
                width: width ?? DEFAULT_WIDTH,
                frameStyle: frameStyle ?? ColoredStringStyle.Null,
                fillStyle: fillStyle ?? ColoredStringStyle.Cyan,
                emptyStyle: emptyStyle ?? ColoredStringStyle.Null
            );
        }

        public static IProgressBarRenderer Legacy(
            ProgressBarLocation? location = null,
            int? width = null,
            IColoredStringStyle frameStyle = null,
            IColoredStringStyle fillStyle = null,
            IColoredStringStyle emptyStyle = null
        )
        {
            return new LegacyProgressBarRendererImpl(
                location: location ?? ProgressBarLocation.Leading,
                width: width ?? DEFAULT_WIDTH,
                frameStyle: frameStyle ?? ColoredStringStyle.Null,
                fillStyle: fillStyle ?? ColoredStringStyle.Cyan,
                emptyStyle: emptyStyle ?? ColoredStringStyle.Null
            );
        }

        public static IProgressBarRenderer Shades(
            ProgressBarLocation? location = null,
            int? width = null,
            IColoredStringStyle fillStyle = null,
            IColoredStringStyle emptyStyle = null
        )
        {
            return new ShadesProgressBarRendererImpl(
                location: location ?? ProgressBarLocation.Leading,
                width: width ?? DEFAULT_WIDTH,
                fillStyle: fillStyle ?? ColoredStringStyle.Cyan,
                emptyStyle: emptyStyle ?? ColoredStringStyle.Null
            );
        }
    }
}