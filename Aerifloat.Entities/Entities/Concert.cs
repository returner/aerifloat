using Aerifloat.Entities.Entities.Base;

namespace Aerifloat.Entities.Entities;

#pragma warning disable CS8618 // Required by Entity Framework
public class Concert : EntityBase<int>
{
    private readonly IList<Performer> _performers = [];
    private readonly IList<Act> _acts = [];

    public string Title { get; private set; }
    public string? Description { get; private set; }
    public IReadOnlyCollection<Performer> Performers => _performers.AsReadOnly();
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
    public IReadOnlyCollection<Act> Acts => _acts.AsReadOnly();
    private Concert() { }

    public Concert(string title, string? description, DateTime startAt, DateTime endAt)
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
        Description = description;
        StartAt = startAt;
        EndAt = endAt;
    }

    public void AddPerformers(IEnumerable<Performer> performers)
    {
        ArgumentNullException.ThrowIfNull(performers);

        foreach (var performer in performers)
        {
            _performers.Add(performer);
        }
    }

    public void AddAct(IEnumerable<Act> acts)
    {
        ArgumentNullException.ThrowIfNull(acts);

        foreach (var act in acts)
        {
            _acts.Add(act);
        }
    }
}
