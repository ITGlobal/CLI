// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    public class RuLocalizedText : LocalizedText
    {
        public override string AmbiguousCommandAlias => "Название '{0}' используется более чем для одной команды: {1}";
        public override string AmbiguousParameter => "Название '{0}' используетя более чем для одного параметра: {1}";
        public override string AmbiguousCommandParameter => "Название '{0}' (в команде '{1}') используетя более чем для одного параметра: {2}";
        public override string Usage => "Параметры командной строки:";
        public override string Commands => "Команды";
        public override string Parameters => "Параметры";
        public override string RequiredParameter => "(Обязателен)";
        public override string ShowHelp => "Показать справку";
        public override string RequiredParameterIsNotSet => "Параметр '{0}' не был задан";
        public override string UnknownCommand => "Команда '{0}' неизвестна";
    }
}