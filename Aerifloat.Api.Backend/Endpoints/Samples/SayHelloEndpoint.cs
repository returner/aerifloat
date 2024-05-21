using Aerifloat.Grains.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Endpoint;

namespace Aerifloat.Api.Backend.Endpoints.Samples
{
    public class SayHelloEndpoint : IEndpoint<string, IClusterClient>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("samples/sayhello", HandleAsync);
        }

        public async Task<string> HandleAsync([FromServices] IClusterClient clusterClient)
        {
            var friend = clusterClient.GetGrain<IHello>(0);
            string response = await friend.SayHello();
            return response;
        }
    }
}
