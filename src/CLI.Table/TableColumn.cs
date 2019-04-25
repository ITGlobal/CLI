using System;
using ITGlobal.CommandLine.Table.Impl;

namespace ITGlobal.CommandLine.Table
{
    internal sealed class TableColumn<T> : ITableColumnModel<T>
    {
        private readonly Func<T, string> _property;
        private readonly Func<T, ConsoleColor?> _fgSelector;
        private readonly Func<T, ConsoleColor?> _bgSelector;

        private readonly string _header;

        private readonly int? _trimWidth;
        private int _effectiveMaxWidth;
        private int _maxWidth;

        public TableColumn(string header, Func<T, string> property, Func<T, ConsoleColor?> fgSelector, Func<T, ConsoleColor?> bgSelector, int? trimWidth)
        {
            _header = header;
            _property = property;
            _fgSelector = fgSelector;
            _bgSelector = bgSelector;
            _trimWidth = trimWidth;
            MaxWidth = header.Length;
        }

        public void CalculateMaxWidth(T item)
        {
            var value = GetTextCore(item);

            var width = value.Length;
            if (width > MaxWidth)
            {
                MaxWidth = width;
            }
        }
        
        public string Header => _header.PadRight(MaxWidth);

        public int MaxWidth
        {
            get => _effectiveMaxWidth;
            set
            {
                _maxWidth = value;
                if (_trimWidth != null && value >= _trimWidth.Value)
                {
                    value = _trimWidth.Value;
                }

                _effectiveMaxWidth = value;
            }
        }

        public string GetText(T item)
        {
            var value = GetTextCore(item);
            if (MaxWidth >= 0 && value.Length > MaxWidth)
            {
                value = value.Substring(0, MaxWidth - Consts.ELLIPSIS.Length) + Consts.ELLIPSIS;
            }

            if (value.Length < MaxWidth)
            {
                value = value.PadRight(MaxWidth);
            }
            return value;
        }

        public ConsoleColor? GetForegroundColor(T item)
        {
            var color = _fgSelector(item);
            return color;
        }

        public ConsoleColor? GetBackgroundColor(T item)
        {
            var color = _bgSelector(item);
            return color;
        }

        private string GetTextCore(T item)
        {
            var value = _property(item) ?? "";
            return value;
        }

        public override string ToString()
        {
            return $"Column {_header} MaxWidth: {MaxWidth}";
        }
    }
}