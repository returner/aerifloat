namespace Aerifloat.Api.Common.Exceptions
{
    public static class ValidValue
    {
        public static DateTime MinDate { get; set; } = DateTime.UtcNow.AddYears(-1);
        public static DateTime MaxDate { get; set; } = DateTime.UtcNow.AddYears(3);
    }
}
