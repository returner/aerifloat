using Aerifloat.Domain.BoundedContext;
using Aerifloat.Grains.Abstractions;

namespace Aerifloat.Grains
{
    public class ConcertReadGrain : Grain, IConcertReadGrain
    {
        private readonly IConcertReadContext _context;
        public ConcertReadGrain(IConcertReadContext context)
        {
            _context = context;
        }
    }
}
