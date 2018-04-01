using System.Text;

namespace ITGlobal.CommandLine.Parsing
{
    internal static class StringUtils
    {
        public static string TrimLeadingAndTrailingEmptyLines(string str)
        {
            var parts = str.Replace("\r", "").Split('\n');

            var startIndex = 0;
            var endIndex = parts.Length - 1;
            for (var i = 0; i < parts.Length; i++)
            {
                var part = parts[i];
                if (!string.IsNullOrWhiteSpace(part))
                {
                    startIndex = i;
                    break;
                }
            }
            for (var i = parts.Length - 1; i >= 0; i--)
            {
                var part = parts[i];
                if (!string.IsNullOrWhiteSpace(part))
                {
                    endIndex = i;
                    break;
                }
            }

            var sb = new StringBuilder();
            for (var i = startIndex; i <= endIndex; i++)
            {
                sb.Append(parts[i]);
                if (i != endIndex)
                {
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}