namespace Aerifloat.Api.Common.Responses.Base;

/// <summary>
/// 페이징 처리를 위한 response 구조
/// </summary>
/// <typeparam name="TResult"></typeparam>
public interface IPaginationResult<TResult>
{
    /// <summary>
    /// 전체 글 갯수
    /// </summary>
    int TotalCount { get; set; }
    /// <summary>
    /// 페이지 갯수
    /// </summary>
    int PageSize { get; set; }
    /// <summary>
    /// 현재 페이지 인덱스(1부터 시작)
    /// </summary>
    int PageIndex { get; set; }
    IEnumerable<TResult>? Values { get; set; }
}
