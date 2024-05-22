using Aerifloat.Api.Common.Exceptions;
using Aerifloat.Api.Common.Responses.Base;

namespace Aerifloat.Api.Common.Responses;

public record PaginationResponse<TResult> : IResponseBase<IPaginationResult<TResult>>
{
    public IPaginationResult<TResult>? Result { get; set; }
    public string? Msg { get; set; } = ErrorCode.Success.ToString();
    public ErrorCode Code { get; set; } = ErrorCode.Success;
}
