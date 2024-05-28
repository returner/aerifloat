using System.Security.Cryptography;

namespace Aerifloat.Api.Common.Extensions
{
    public static class GuidToLongExtension
    {
        public static long ToLong(this Guid guid)
        {
            byte[] bytes = SHA256.HashData(guid.ToByteArray());
            var hashdata = BitConverter.ToInt64(bytes, 0);
            return hashdata < 0 ? hashdata * -1 : hashdata;
        }
    }
}
