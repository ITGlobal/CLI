using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class ArgumentInfo
    {
        public string Key { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public static ArgumentInfo Create(CliArgumentUsage u)
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

            return new ArgumentInfo
            {
                DisplayOrder = u.Position,
                Key = "",
                Name = u.Name.ToUpperInvariant(),
                Description = sb.ToString()
            };

            IEnumerable<string> EnumerateOptionDescriptions()
            {
                switch (u.Type)
                {
                    case EnumCliTypeInfo i when i.ValidValues.Length>0:
                        yield return $"valid values {string.Join("/", from v in i.ValidValues select v.Yellow())}";
                        break;
                    case StringCliTypeInfo _:
                        break;
                    default:
                        yield return u.Type.Name;
                        break;
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
                    yield return $"default {u.DefaultValue.Yellow()}";
                }
            }
        }
    }
}