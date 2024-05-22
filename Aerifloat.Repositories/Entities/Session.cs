using Aerifloat.Repositories.Entities.Base;

namespace Aerifloat.Repositories.Entities;

#pragma warning disable CS8618 // Required by Entity Framework
public class Session : EntityBase<long>
{
    public int Order { get; private set; }
    public string Title { get; set; }
    private Session() { }
    public Session(int order, string title)
    {
        Order = order;
        Title = title;
    }
}
