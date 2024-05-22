using Aerifloat.DTOs.Context.Concerts;
using Aerifloat.Repositories.Entities;
using Aerifloat.Repositories.Repositories;
using MediatR;

namespace Aerofloat.MediatRs.Commands.Concerts
{
    

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
