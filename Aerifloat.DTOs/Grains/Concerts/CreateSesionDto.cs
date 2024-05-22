using Orleans;

namespace Aerifloat.DTOs.Grains.Concerts
{
    [GenerateSerializer]
    public class CreateSesionDto
    {
        [Id(0)]
        public int Order { get; set; }
    }
}
