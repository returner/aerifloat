using Aerifloat.Api.Backend.Payloads.Concerts;
using Aerifloat.Api.Common.Constants;
using Aerifloat.Api.Common.Extensions;
using Aerifloat.Api.Common.TypeDefines;
using Aerifloat.DTOs.Concerts;
using Aerifloat.Grains.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MinimalApi.Endpoint;

namespace Aerifloat.Api.Backend.Endpoints.Concerts
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
