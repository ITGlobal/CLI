using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        private static readonly Dictionary<string, Func<LocalizedText>> _Localizations = new Dictionary
            <string, Func<LocalizedText>>
        {
            {"EN", () => new EnLocalizedText()},
            {"RU", () => new RuLocalizedText()},
        };
        private static readonly LocalizedText DefautLocalizedText = new EnLocalizedText();

        internal static LocalizedText Text { get; private set; } = DefautLocalizedText;

        /// <summary>
        ///     Sets a localization provider
        /// </summary>
        [PublicAPI]
        public static void UseLocalizedText([NotNull] LocalizedText text)
        {
            Text = text;
        }

        /// <summary>
        ///     Sets a default localization provider
        /// </summary>
        [PublicAPI]
        public static void UseDefaultLocalizedText()
        {
            var langCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToUpperInvariant();

            Func<LocalizedText> func;
            if (_Localizations.TryGetValue(langCode, out func))
            {
                Text = func();
            }
            else
            {
                Text = DefautLocalizedText;
            }
        }
    }
}
