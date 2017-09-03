using System;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class TableColumn<T>
    {
        private readonly string _title;
        private readonly Func<T, string> _property;
        private readonly Func<T, ConsoleColor?> _fgSelector;
        private readonly Func<T, ConsoleColor?> _bgSelector;
        private readonly int? _trimWidth;
        private int _maxWidth;

        public TableColumn(string title, Func<T, string> property, Func<T, ConsoleColor?> fgSelector, Func<T, ConsoleColor?> bgSelector, int? trimWidth)
        {
            _title = title;
            _property = property;
            _fgSelector = fgSelector;
            _bgSelector = bgSelector;
            _trimWidth = trimWidth;
            _maxWidth = title.Length;
        }

        public void CalculateMaxWidth(T item)
        {
            var value = GetValueCore(item);

            var width = value.Length;
            if (width > _maxWidth)
            {
                _maxWidth = width;
            }
        }

        public string Title => _title.PadRight(_maxWidth);

        public void Print(T item)
        {
            var value = GetValueCore(item);
            value = value.PadRight(_maxWidth);

            using (WithColors(_fgSelector(item), _bgSelector(item)))
            {
                Console.Write(value);
            }
        }

        private string GetValueCore(T item)
        {
            var value = (_property(item) ?? "");
            if (_trimWidth != null && value.Length > _trimWidth.Value)
            {
                value = value.Substring(0, _trimWidth.Value - ELLIPSIS.Length) + ELLIPSIS;
            }
            return value;
        }
    }
}