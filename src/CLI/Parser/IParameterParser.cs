using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal interface IParameterParser
    {
        string Name { get; }
        string[] Aliases { get; }

        void Reset();
        ParameterParserResult TryConsume(string[] args, ref int index);
        ParameterParserResult TryConsumeAt(string[] args, int index);
        void Validate(IList<string> errors);

        ParameterInfo GetParameterInfo();
    }

    internal sealed class ParameterParserResult
    {
        private ParameterParserResult(bool isSuccess, bool isConsumed, string error)
        {
            IsSuccess = isSuccess;
            IsConsumed = isConsumed;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsConsumed { get; }
        public string Error { get; }

        public static ParameterParserResult Consumed { get; } = new ParameterParserResult(true, true, null);
        public static ParameterParserResult NotConsumed { get; } = new ParameterParserResult(true, false, null);
        public static ParameterParserResult Failure(string error) => new ParameterParserResult(false, false, error);
    }
}