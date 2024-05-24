using Aerofloat.Entities.Entities.Base;

namespace Aerofloat.Entities.Entities;

#pragma warning disable CS8618 // Required by Entity Framework
public class Act : EntityBase<long>
{
    private readonly IList<Session> _session = [];
    public string Title { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public IReadOnlyCollection<Session> Sessions => _session.AsReadOnly();

    private Act() { }
    public Act(string title, TimeSpan startTime, TimeSpan endTime)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be null or empty");
        }

        if (startTime >= endTime)
        {
            throw new ArgumentException("Start time must be before end time");
        }

        Title = title;
        StartTime = startTime;
        EndTime = endTime;
    }

    public void AddSessions(IEnumerable<Session> sessions)
    {
        ArgumentNullException.ThrowIfNull(sessions);

        foreach (var session in sessions)
        {
            _session.Add(session);
        }
    }
}
