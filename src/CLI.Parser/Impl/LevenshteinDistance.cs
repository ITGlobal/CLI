using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    /// <summary>
    ///     Levenshtein distance calculator.
    ///     Based on https://github.com/NoelKennedy/MinimumEditDistance/blob/master/MinimumEditDistance/Levenshtein.cs
    /// </summary>
    internal static class LevenshteinDistance
    {
        public static int Calculate(string left, string right)
        {
            const int substitutionCost = 1;
            var d = new int[left.Length + 1, right.Length + 1];

            if (string.IsNullOrEmpty(left))
            {
                if (string.IsNullOrEmpty(right))
                    return 0;

                return right.Length;
            }

            if (string.IsNullOrEmpty(right))
            {
                if (string.IsNullOrEmpty(left))
                    return 0;

                return left.Length;
            }

            var m = left.Length + 1;
            var n = right.Length + 1;

            for (var i = 0; i < m; i++)
            {
                d[i, 0] = i;
            }
            for (var i = 0; i < n; i++)
            {
                d[0, i] = i;
            }
            
            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    if (char.ToLowerInvariant(left[i - 1]) == char.ToLowerInvariant(right[j - 1]))
                    {
                        d[i, j] = d[i - 1, j - 1];
                    }
                    else
                    {
                        var delete = d[i - 1, j] + 1;
                        var insert = d[i, j - 1] + 1;
                        var substitution = d[i - 1, j - 1] + substitutionCost;
                        d[i, j] = Math.Min(delete, Math.Min(insert, substitution));
                    }
                }
            }

            return d[m - 1, n - 1];
        }
    }
}