using Aerifloat.Api.Common.Responses.Base;

namespace Aerifloat.Api.Common.Responses;

/// <summary>
/// 페이징 처리를 하는 response 모델의 Result
/// </summary>
/// <typeparam name="TResult"></typeparam>
public record PaginationResult<TResult> : IPaginationResult<TResult>
{
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public IEnumerable<TResult>? Values { get; set; }
}
