using Aerifloat.Grains.Abstractions;
using Aerifloat.Grains.Dtos.Grains.Concerts;
using Moq;

namespace Aerifloat.Grains.Test
{
    public class IConcertGrainTests
    {
        private readonly Mock<IConcertGrain> _concertGrainMock;

        public IConcertGrainTests()
        {
            _concertGrainMock = new Mock<IConcertGrain>();
        }

        [Fact]
        public async Task CreateConcertAsync_ShouldReturnConcertId()
        {
            // Arrange
            var concertDto = new GrainCreateConcertDto
            {
                Title = "Sample Concert",
                StartAt = DateTime.Now,
                EndAt = DateTime.Now.AddHours(2)
            };
            var expectedConcertId = 1;
            _concertGrainMock.Setup(x => x.CreateConcertAsync(concertDto)).ReturnsAsync(expectedConcertId);

            // Act
            var result = await _concertGrainMock.Object.CreateConcertAsync(concertDto);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(expectedConcertId, result);
        }

        [Fact]
        public async Task AddPerformersToConcert_ShouldReturnResult()
        {
            // Arrange
            var concertId = 1;
            var performerDtos = new List<GrainCreatePerformerDto>();
            var expectedResult = 1;
            _concertGrainMock.Setup(x => x.AddPerformersToConcert(concertId, performerDtos)).ReturnsAsync(expectedResult);

            // Act
            var result = await _concertGrainMock.Object.AddPerformersToConcert(concertId, performerDtos);

            // Assert
            Assert.Equal(expectedResult, result);
            Assert.NotNull(result);
            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task AddActsToConcert_ShouldReturnResult()
        {
            // Arrange
            var concertId = 1;
            var actDtos = new List<GrainCreateActDto>();
            var expectedResult = 1;
            _concertGrainMock.Setup(x => x.AddActsToConcert(concertId, actDtos)).ReturnsAsync(expectedResult);

            // Act
            var result = await _concertGrainMock.Object.AddActsToConcert(concertId, actDtos);

            // Assert
            Assert.Equal(expectedResult, result);
            Assert.NotNull(result);
            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task AddSessionToAct_ShouldReturnResult()
        {
            // Arrange
            var actId = 1;
            var sessionDtos = new List<GrainCreateSesionDto>();
            var expectedResult = 1;
            _concertGrainMock.Setup(x => x.AddSessionToAct(actId, sessionDtos)).ReturnsAsync(expectedResult);

            // Act
            var result = await _concertGrainMock.Object.AddSessionToAct(actId, sessionDtos);

            // Assert
            Assert.Equal(expectedResult, result);
            Assert.NotNull(result);
            Assert.IsType<int>(result);
        }
    }
}
