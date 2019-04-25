using System;

namespace ITGlobal.CommandLine
{
    public abstract class AnsiCommand
    {
        private sealed class SetForegroundColorCommand : AnsiCommand
        {
            public SetForegroundColorCommand(ConsoleColor color)
            {
                Color = color;
            }

            public ConsoleColor Color { get; }

            protected override bool Equals(AnsiCommand other) => other is SetForegroundColorCommand c && c.Color == Color;
            public override string ToString() => $"SetForegroundColor({Color})";
        }

        private sealed class SetBackgroundColorCommand : AnsiCommand
        {
            public SetBackgroundColorCommand(ConsoleColor color)
            {
                Color = color;
            }

            public ConsoleColor Color { get; }

            protected override bool Equals(AnsiCommand other) => other is SetBackgroundColorCommand c && c.Color == Color;
            public override string ToString() => $"SetBackgroundColor({Color})";
        }

        private sealed class ResetColorsCommand : AnsiCommand
        {
            protected override bool Equals(AnsiCommand other) => other is ResetColorsCommand;
            public override string ToString() => "ResetColors()";
        }

        private sealed class WriteCommand : AnsiCommand
        {
            public WriteCommand(char character)
            {
                Character = character;
            }

            public char Character { get; }

            protected override bool Equals(AnsiCommand other) => other is WriteCommand c && c.Character == Character;
            public override string ToString() => $"Write({Character})";
        }

        protected abstract bool Equals(AnsiCommand other);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AnsiCommand)obj);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }

        public static AnsiCommand SetForegroundColor(ConsoleColor color) => new SetForegroundColorCommand(color);
        public static AnsiCommand SetBackgroundColor(ConsoleColor color) => new SetBackgroundColorCommand(color);
        public static AnsiCommand ResetColors() => new ResetColorsCommand();
        public static AnsiCommand Write(char c) => new WriteCommand(c);
    }
}