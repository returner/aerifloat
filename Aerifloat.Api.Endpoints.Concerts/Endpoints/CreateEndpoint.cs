namespace Aerifloat.Api.Endpoints.Concerts.Endpoints
{
    public class CreateEndpoint : IEndpoint<int, IClusterClient, CreateConcertPayload, CancellationToken>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("concert", HandleAsync)
                .SuccessResponse<int>()
                .WithTags(EndpointTags.Concert)
                .SwaggerMessage(SwaggerMessageType.Create, "Create a concert");
        }

        public async Task<int> HandleAsync([FromServices] IClusterClient clusterClient, [FromBody] CreateConcertPayload request, CancellationToken cancellationToken)
        {
            var grain = clusterClient.GetGrain<IConcertGrain>(0);
            var dto = new CreateConcertDto
            {
                Title = request.Title,
                Description = request.Description,
                StartAt = request.StartAt,
                EndAt = request.EndAt
            };
            var id = await grain.CreateConcertAsync(dto);
            return id;
        }
    }
}
