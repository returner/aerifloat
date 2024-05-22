using Aerifloat.Api.Common.Exceptions;

namespace Aerifloat.Api.Common.Responses.Base;

public interface IResponseBase<TResult>
{
    public TResult? Result { get; set; }
    public string? Msg { get; set; }
    public ErrorCode Code { get; set; }
}
