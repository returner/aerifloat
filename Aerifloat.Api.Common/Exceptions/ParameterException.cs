namespace Aerifloat.Api.Common.Exceptions
{
    public class ParameterException(ErrorType errorType, ErrorCode errorCode, string? paramName) : Exception
    {
        public ErrorType ErrorType { get; init; } = errorType;
        public ErrorCode ErrorCode { get; init; } = errorCode;
        public string? ParamName { get; init; } = paramName;
    }
}