using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace ITGlobal.CommandLine.Parsing
{
    internal sealed class EnumMetadata<T>
        where T : struct, Enum
    {
        public static EnumMetadata<T> Instance { get; } = new EnumMetadata<T>();

        private readonly Dictionary<string, T> _nameToValueDict = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<T, string> _valueToNameDict = new Dictionary<T, string>();

        private EnumMetadata()
        {
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                var field = typeof(T).GetField(name);
                AddEnumMember(field);
            }

            Values = _valueToNameDict.Values.ToArray();
        }

        public string[] Values { get; }

        public string Format(T value)
        {
            if (!_valueToNameDict.TryGetValue(value, out var name))
            {
                name = value.ToString();
            }

            return name;
        }

        public bool TryParse(string str, out T value)
        {
            return _nameToValueDict.TryGetValue(str, out value);
        }

        private void AddEnumMember(FieldInfo field)
        {
            // Skip enum members annotated with [IgnoreDataMember]
            if (field.GetCustomAttribute<IgnoreDataMemberAttribute>() != null)
            {
                return;
            }

            // Skip enum members annotated with [CliParserIgnore]
            if (field.GetCustomAttribute<CliParserIgnoreAttribute>() != null)
            {
                return;
            }

            var value = (T)field.GetValue(null);

            // For enum members annotated with [CliParserMember] - try to use name from attribute
            // This attribute may be defined more than once for an enum member
            var cliParserMemberAttributes = field.GetCustomAttributes<CliParserMemberAttribute>().ToArray();
            if (cliParserMemberAttributes.Length > 0)
            {
                foreach (var cliParserMemberAttribute in cliParserMemberAttributes)
                {
                    AddEnumMember(value, cliParserMemberAttribute.Name);
                }
                return;
            }

            // For enum members annotated with [DataMember] - try to use name from attribute
            var dataMemberAttribute = field.GetCustomAttribute<DataMemberAttribute>();
            if (!string.IsNullOrEmpty(dataMemberAttribute?.Name))
            {
                AddEnumMember(value, dataMemberAttribute.Name);
                return;
            }

            // Otherwise - use field name
            AddEnumMember(value, field.Name);
        }

        private void AddEnumMember(T value, string name)
        {
            if (!_nameToValueDict.ContainsKey(name))
            {
                _nameToValueDict.Add(name, value);

                if (!_valueToNameDict.ContainsKey(value))
                {
                    _valueToNameDict.Add(value, name);
                }
            }
        }
    }
}