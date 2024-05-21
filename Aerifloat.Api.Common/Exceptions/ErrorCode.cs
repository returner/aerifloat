namespace Aerifloat.Api.Common.Exceptions
{
    public enum ErrorCode
    {
        NegativeOrZero,
        Negative,
        UnexpectedResult,
        NullOrWhiteSpace,
        Null,
        EmptyCollection,
        DateTimeOutOfRange,
        EndDateBiggerThanStartDate,
        InvalidFileNameOrExtension
    }
}