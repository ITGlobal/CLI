using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal interface IParameterParser
    {
        string Name { get; }
        string[] Aliases { get; }

        void Reset();
        bool TryConsume(string[] args, ref int index);
        bool TryConsumeAt(string[] args, int index);
        void Validate(IList<string> errors);

        ParameterInfo GetParameterInfo();
    }
}