﻿using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        /// <summary>
        ///     Creates a spinner
        /// </summary>
        /// <param name="title">
        ///     Operation name
        /// </param>
        /// <returns>
        ///     A console spinner object
        /// </returns>
        [PublicAPI, NotNull]
        public static ISpinner Spinner([NotNull] string title) => new Spinner(title);
    }
}
