using Aerifloat.Grains.Core.Entities.Base;

namespace Aerifloat.Grains.Core.Entities
{
#pragma warning disable CS8618 // Required by Entity Framework
    public class Performer : EntityBase<int>
    {
        public string Name { get; set; }
    }
}
