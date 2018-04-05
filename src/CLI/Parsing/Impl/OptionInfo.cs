using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class OptionInfo
    {
        public string Key { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public static OptionInfo Create(CliSwitchUsage u)
        {
            var sb = new StringBuilder();
            sb.Append(u.HelpText);
            if (u.IsRepeatable)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append("(repeatable)");
            }

            return new OptionInfo
            {
                DisplayOrder = u.DisplayOrder,
                Key = u.Names.OrderByDescending(_ => _.Length).First().TrimStart('-').ToLowerInvariant(),
                Name = string.Join(", ", u.Names),
                Description = sb.ToString()
            };
        }

        public static OptionInfo Create(CliOptionUsage u)
        {
            var sb = new StringBuilder();
            sb.Append(u.HelpText);

            var descr = string.Join(", ", EnumerateOptionDescriptions());
            if (!string.IsNullOrEmpty(descr))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append("(");
                sb.Append(descr);
                sb.Append(")");
            }

            var valueName = !string.IsNullOrEmpty(u.TypeName) ? u.TypeName : "value";
            return new OptionInfo
            {
                DisplayOrder = u.DisplayOrder,
                Key = u.Names.OrderByDescending(_ => _.Length).First().TrimStart('-').ToLowerInvariant(),
                Name = string.Join(", ", u.Names) + " " + valueName,
                Description = sb.ToString()
            };

            IEnumerable<string> EnumerateOptionDescriptions()
            {
                if (!string.IsNullOrEmpty(u.TypeName) && u.TypeName != "string")
                {
                    yield return u.TypeName;
                }

                if (u.IsRequired)
                {
                    yield return "required";
                }

                if (u.IsRepeatable)
                {
                    yield return "repeatable";
                }

                if (u.DefaultValue != null)
                {
                    yield return $"default {u.DefaultValue}";
                }
            }
        }
    }
}