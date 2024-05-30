using Aerifloat.Api.Endpoints.Concerts.Payloads;
using Aerifloat.Grains.Abstractions;
using Aerifloat.Grains.Dtos.Grains.Concerts;
using Moq;

namespace Aerifloat.Api.Endpoints.Concerts.Endpoints.Tests
{
    public class CreateEndpointTests
    {
        private readonly Mock<IClusterClient> _clusterClientMock;
        private readonly Mock<IConcertGrain> _concertGrainMock;
        private readonly CreateEndpoint _createEndpoint;

        public CreateEndpointTests()
        {
            _clusterClientMock = new Mock<IClusterClient>();
            _concertGrainMock = new Mock<IConcertGrain>();
            _createEndpoint = new CreateEndpoint();
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_ReturnsConcertId()
        {
            // Arrange
            var request = new CreateConcertPayload
            {
                Title = "Test Concert",
                Description = "This is a test concert",
                StartAt = DateTime.UtcNow,
                EndAt = DateTime.UtcNow.AddHours(2)
            };
            var expectedId = 1;

            _clusterClientMock.Setup(x => x.GetGrain<IConcertGrain>(0, null)).Returns(_concertGrainMock.Object);
            _concertGrainMock.Setup(x => x.CreateConcertAsync(It.IsAny<GrainCreateConcertDto>())).ReturnsAsync(expectedId);

            // Act
            var result = await _createEndpoint.HandleAsync(_clusterClientMock.Object, request, CancellationToken.None);

            // Assert
            Assert.Equal(expectedId, result);
        }

        // Add more test cases for different scenarios

        //[Fact]
        //public void AddRoute_ValidRoute_SuccessfullyAddsRoute()
        //{
        //    // Arrange
        //    var endpointRouteBuilderMock = new Mock<IEndpointRouteBuilder>();

        //    // Act
        //    _createEndpoint.AddRoute(endpointRouteBuilderMock.Object);

        //    // Assert
        //    endpointRouteBuilderMock.Setup(x => x.MapRoute(
        //        It.IsAny<RouteBuilderContext>()))
        //        .Callback((RouteBuilderContext context) =>
        //        {
        //            var routeName = context.RouteName;
        //            var routeValues = context.RouteValues;
        //            var order = context.Order;

        //            Assert.Equal("concert", routeValues["controller"]);
        //            Assert.Equal(_createEndpoint.HandleAsync, routeValues["action"]);
        //        })
        //        .Verifiable();

        //    // Add more assertions for other method calls
        //}
    }
}
