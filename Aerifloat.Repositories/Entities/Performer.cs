using Aerifloat.Repositories.Entities.Base;

namespace Aerifloat.Repositories.Entities;

#pragma warning disable CS8618 // Required by Entity Framework
public class Performer : EntityBase<int>
{
    public string Name { get; set; }
}
