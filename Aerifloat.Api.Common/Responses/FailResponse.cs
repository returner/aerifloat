using Aerifloat.Api.Common.Exceptions;
using Aerifloat.Api.Common.Responses.Base;

namespace Aerifloat.Api.Common.Responses;

public record FailResponse<TResult> : IResponseBase<TResult>
{
    public FailResponse(ErrorCode errorCode, TResult? result = default)
    {
        Code = errorCode;
        Msg = errorCode.ToString();
        Result = result;
    }

    public FailResponse(ErrorCode errorCode)
    {
        Code = errorCode;
        Msg = errorCode.ToString();
        Result = default;
    }

    public TResult? Result { get; set; }
    public string? Msg { get; set; }
    public ErrorCode Code { get; set; }
}
