using Aerifloat.Core.Entities.Base;

namespace Aerifloat.Core.Entities;

#pragma warning disable CS8618 // Required by Entity Framework
public class Concert : EntityBase<int>
{
    private readonly IList<Performer> _performers = [];
    private readonly IList<Act> _acts = new List<Act>();

    public string Title { get; private set; }
    public IReadOnlyCollection<Performer> Performers => _performers.AsReadOnly();
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
    public IReadOnlyCollection<Act> Acts => _acts.AsReadOnly();
    private Concert() { }

    public Concert(string title, DateTime startAt, DateTime endAt)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be null or empty");
        }

        if (startAt >= endAt)
        {
            throw new ArgumentException("Start date must be before end date");
        }

        Title = title;
        StartAt = startAt;
        EndAt = endAt;
    }
}
