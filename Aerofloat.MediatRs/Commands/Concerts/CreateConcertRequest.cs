using Aerifloat.Core.Entities;
using Aerifloat.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerofloat.MediatRs.Commands.Concerts
{
    public record CreateConcertRequest : IRequest<int>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required DateTime StartAt { get; set; }
        public required DateTime EndAt { get; set; }
    }

    public class CreateConcertRequestHandler : IRequestHandler<CreateConcertRequest, int>
    {
        private readonly IRepository<Concert> _repository;

        public CreateConcertRequestHandler(IRepository<Concert> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateConcertRequest request, CancellationToken cancellationToken = default)
        {
            var concert = new Concert(request.Title, request.Description, request.StartAt, request.EndAt);
            await _repository.AddAsync(concert, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return concert.Id;
        }
    }
}
