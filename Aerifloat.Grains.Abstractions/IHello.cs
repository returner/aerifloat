namespace Aerifloat.Grains.Abstractions
{
    public interface IHello : IGrainWithIntegerKey
    {
        Task<string> SayHello();
    }
}
