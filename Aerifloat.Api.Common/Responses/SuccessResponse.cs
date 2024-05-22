using Aerifloat.Api.Common.Exceptions;
using Aerifloat.Api.Common.Responses.Base;

namespace Aerifloat.Api.Common.Responses;

public record SuccessResponse<TResult> : IResponseBase<TResult>
{
    public TResult? Result { get; set; }
    public ErrorCode Code { get; set; }
    public string? Msg { get; set; }
    public SuccessResponse(TResult result)
    {
        Result = result;
        Code = ErrorCode.Success;
        Msg = ErrorCode.Success.ToString();
    }
}
