using System;
using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    public static class SpinnerRenderer
    {
        [NotNull]
        public static ISpinnerRenderer Default { get; set; } = RotatingBar();

        [NotNull]
        public static ISpinnerRenderer RotatingBar(
            IColoredStringStyle colors = null, 
            SpinnerLocation? location = null,
            bool addSpaceSeparator = true)
        {
            return new RotatingBarSpinnerRenderer(
                colors: colors ?? ColoredStringStyle.Null,
                location: location ?? SpinnerLocation.Trailing,
                addSpaceSeparator: addSpaceSeparator
            );
        }

        [NotNull]
        public static ISpinnerRenderer RotatingAngle(
            IColoredStringStyle colors = null,
            SpinnerLocation? location = null,
            bool addSpaceSeparator = true)
        {
            return new RotatingAngleSpinnerRenderer(
                colors: colors ?? ColoredStringStyle.Null,
                location: location ?? SpinnerLocation.Trailing,
                addSpaceSeparator: addSpaceSeparator
            );
        }

        [NotNull]
        public static ISpinnerRenderer Arrow(
            IColoredStringStyle colors = null,
            SpinnerLocation? location = null,
            bool addSpaceSeparator = true,
            SpinnerArrowDirection? direction = null)
        {
            switch (direction?? SpinnerArrowDirection.Both)
            {
                case SpinnerArrowDirection.LeftToRight:
                    return new LeftToRightArrowSpinnerRenderer(
                        colors: colors ?? ColoredStringStyle.Null,
                        location: location ?? SpinnerLocation.Trailing,
                        addSpaceSeparator: addSpaceSeparator
                    );

                case SpinnerArrowDirection.RightToLeft:
                    return new RightToLeftArrowSpinnerRenderer(
                        colors: colors ?? ColoredStringStyle.Null,
                        location: location ?? SpinnerLocation.Trailing,
                        addSpaceSeparator: addSpaceSeparator
                    );

                case SpinnerArrowDirection.Both:
                    return new BothDirectionArrowSpinnerRenderer(
                        colors: colors ?? ColoredStringStyle.Null,
                        location: location ?? SpinnerLocation.Trailing,
                        addSpaceSeparator: addSpaceSeparator
                    );

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [NotNull]
        public static ISpinnerRenderer BouncingBall(
            IColoredStringStyle colors = null,
            SpinnerLocation? location = null,
            bool addSpaceSeparator = true)
        {
            return new BouncingBallSpinnerRenderer(
                colors: colors ?? ColoredStringStyle.Null,
                location: location ?? SpinnerLocation.Trailing,
                addSpaceSeparator: addSpaceSeparator
            );
        }
    }
}