using Orleans;

namespace Aerifloat.DTOs.Concerts
{
    [GenerateSerializer]
    public class CreateSesionDto
    {
        [Id(0)]
        public int Order { get; set; }
    }
}
