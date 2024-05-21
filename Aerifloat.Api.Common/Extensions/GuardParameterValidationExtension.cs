using Aerifloat.Api.Common.Exceptions;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace Aerifloat.Api.Common.Extensions;

public static class GuardParameterValidationExtension
{
    /// <summary>
    /// 파라미터가 음수나 0인지 확인
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ParameterNegativeOrZeroException"></exception>
    public static int ParamNegativeOrZero(this IGuardClause guardClause, int value, string? paramName)
    {
        if (value <= 0)
        {
            throw new ParameterException(ErrorType.Parameter, ErrorCode.NegativeOrZero, paramName);
        }
        return value;
    }

    /// <summary>
    /// 파라미터가 음수나 0인지 확인
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ParameterNegativeOrZeroException"></exception>
    public static long ParamNegativeOrZero(this IGuardClause guardClause, long value, string? paramName)
    {
        if (value <= 0)
        {
            throw new ParameterException(ErrorType.Parameter, ErrorCode.NegativeOrZero, paramName);
        }
        return value;
    }

    /// <summary>
    /// 파라미터가 음수인지 확인
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ParameterNegativeException"></exception>
    public static int ParamNegative(this IGuardClause guardClause, int value, string? paramName)
    {
        if (value < 0)
        {
            throw new ParameterException(ErrorType.Parameter, ErrorCode.Negative, paramName);
        }
        return value;
    }

    /// <summary>
    /// 파라미터가 음수인지 확인
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ParameterNegativeException"></exception>
    public static long ParamNegative(this IGuardClause guardClause, long value, string? paramName)
    {
        if (value < 0)
        {
            throw new ParameterException(ErrorType.Parameter, ErrorCode.Negative, paramName);
        }
        return value;
    }

    /// <summary>
    /// 파라미터가 null인지 확인
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guardClause"></param>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ParameterNullException"></exception>
    public static T ParamNull<T>(this IGuardClause guardClause, [NotNull] T? value, string? paramName)
    {
        if (value is null)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.Null, paramName);

        return value;
    }

    public static T ParamNullOrEmpty<T>(this IGuardClause guardClause, [NotNull] T? value, string? paramName)
    {
        if (value is null)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.Null, paramName);
        if (value is IEnumerable<T> enumerable)
        {
            if (!enumerable.Any())
                throw new ParameterException(ErrorType.Parameter, ErrorCode.EmptyCollection, paramName);
        }

        return value;
    }

    /// <summary>
    /// string 파라미터가 Null이나 WhiteSpace인지 확인
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ParameterNullOrWhiteSpaceException"></exception>
    public static string ParamNullOrWhiteSpace(this IGuardClause guardClause, [NotNull] string? value, string? paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ParameterException(ErrorType.Parameter, ErrorCode.NullOrWhiteSpace, value);

        return value;
    }

    /// <summary>
    /// DateTime의 유효성 검사
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ParameterNullException"></exception>
    /// <exception cref="ParameterDateTimeOutOfRangeException"></exception>
    public static DateTime ParamDateTime(this IGuardClause guardClause, [NotNull] DateTime? value, string? paramName)
    {
        if (value == null)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.Null, paramName);

        if (value <= ValidValue.MinDate || value >= ValidValue.MaxDate)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.DateTimeOutOfRange, paramName);

        return (DateTime)value;
    }

    public static void ParamCompareDateTime(this IGuardClause guardClause, [NotNull] DateTime? startDate, [NotNull] DateTime? endDate)
    {
        if (startDate == null)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.Null, nameof(startDate));
        if (endDate == null)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.Null, nameof(endDate));
        if (startDate <= ValidValue.MinDate || startDate >= ValidValue.MaxDate)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.DateTimeOutOfRange, nameof(startDate));
        if (endDate <= ValidValue.MinDate || endDate >= ValidValue.MaxDate)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.DateTimeOutOfRange, nameof(endDate));

        if (startDate > endDate)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.EndDateBiggerThanStartDate, nameof(endDate));

    }

    public static void ParamCompareDateTime(this IGuardClause guardClause, TimeOnly startTime, TimeOnly endTime)
    {
        if (startTime > endTime)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.EndDateBiggerThanStartDate, nameof(endTime));
    }

    public static void ParamCompareDateTime(this IGuardClause guardClause, DateOnly startDate, DateOnly endDate)
    {
        if (startDate > endDate)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.EndDateBiggerThanStartDate, nameof(endDate));
    }

    /// <summary>
    /// 파일의 유효성 검사
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ParameterNullException"></exception>
    /// <exception cref="ParameterFileLengthNegativeOrZeroException"></exception>
    public static IFormFile ParamFile(this IGuardClause guardClause, [NotNull] IFormFile? value, string? paramName)
    {
        if (value == null)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.Null, paramName);
        if (value.Length <= 0)
            throw new ParameterException(ErrorType.Parameter, ErrorCode.NegativeOrZero, paramName);
        if (!Path.HasExtension(value.FileName))
            throw new ParameterException(ErrorType.Parameter, ErrorCode.InvalidFileNameOrExtension, paramName);
        return value;
    }
}
