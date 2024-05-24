using Aerifloat.Repositories.BoundedContext.Abstractions;
using Aerifloat.Repositories.Entities;
using Aerifloat.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aerifloat.Repositories.BoundedContext
{
    public class ConcertCommandContext : IConcertCommandContext
    {
        public ConcertCommandContext(IRepository<Concert> repository)
        {
            var concert = new Concert(request.Title, request.Description, request.StartAt, request.EndAt);
            await _repository.AddAsync(concert, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return concert.Id;
        }
    }
}
