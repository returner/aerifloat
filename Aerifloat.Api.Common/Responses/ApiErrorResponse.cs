using Aerifloat.Api.Common.Exceptions;
using Aerifloat.Api.Common.Responses.Base;

namespace Aerifloat.Api.Common.Responses;

public class ApiErrorResponse<TResult> : IResponseBase<TResult>
{
    public TResult? Result { get; set; }
    public string? Msg { get; set; }
    public ErrorCode Code { get; set; }
    
    public ApiErrorResponse(ErrorCode errorCode, string? message, TResult? result)
    {
        Code = errorCode;
        Msg = message;
        Result = result;
    }
}
