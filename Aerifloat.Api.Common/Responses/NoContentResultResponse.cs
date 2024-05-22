using Aerifloat.Api.Common.Exceptions;
using Aerifloat.Api.Common.Responses.Base;

namespace Aerifloat.Api.Common.Responses;

public class NoContentResultResponse<TResult> : IResponseBase<TResult>
{
    public NoContentResultResponse(ErrorCode errorCode)
    {
        Result = default;
        Msg = errorCode.ToString();
        Code = errorCode;
    }

    public TResult? Result { get; set; }
    public string? Msg { get; set; }
    public ErrorCode Code { get; set; }
}
