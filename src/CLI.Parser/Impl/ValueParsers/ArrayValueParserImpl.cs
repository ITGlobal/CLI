using System;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl.ValueParsers
{
    internal sealed class ArrayValueParserImpl<T> : IValueParser<T[]>
    {
        private readonly IValueParser<T> _parser;

        public ArrayValueParserImpl(IValueParser<T> parser)
        {
            _parser = parser;
            TypeInfo = CliTypeInfo.Array(parser.TypeInfo);
        }

        public CliTypeInfo TypeInfo { get; }

        public string Format(T[] values) => string.Join(", ", values.Select(_parser.Format));

        public ValueParserResult<T[]> Parse(string str)
        {
            try
            {
                var values = str.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(_parser.Parse)
                    .ToArray();
                var error = values.FirstOrDefault(_ => !_.IsSuccess);
                if (error.ErrorMessage != null)
                {
                    return ValueParserResult.Error<T[]>(error.ErrorMessage);
                }

                return ValueParserResult.Success(values.Select(_ => _.Value).ToArray());
            }
            catch (Exception e)
            {
                return ValueParserResult.Error<T[]>(e.Message);
            }
        }
    }
}