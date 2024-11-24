namespace RollingDiceApi.Services.Tests
{
    using AutoMapper;
    using NSubstitute;
    using RollingDiceApi.DataAccess.Models;
    using RollingDiceApi.Repositories.Interfaces;
    using RollingDiceApi.Services;
    using RollingDiceApi.Services.Models.RollDice;

    public class RollDiceServiceTests
    {
        private readonly IMapper mapperMock;
        private readonly IRollDiceRepository rollDiceRepositoryMock;
        private readonly RollDiceService rollingDiceService;

        public RollDiceServiceTests()
        {
            mapperMock = Substitute.For<IMapper>();
            rollDiceRepositoryMock = Substitute.For<IRollDiceRepository>();
            rollingDiceService = new RollDiceService(mapperMock, rollDiceRepositoryMock);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task RollDiceAsync_Is_Success()
        {
            rollDiceRepositoryMock.SaveRolledDiceAsync(Arg.Any<RolledDiceData>(), Arg.Any<CancellationToken>()).Returns(true);

            var result = await rollingDiceService.RollDiceAsync(new RollDiceServiceRequest() { Email = "test@email.com" }, CancellationToken.None);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RollDiceServiceResponse>());
            Assert.That(result.Dice1, Is.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(6));
            Assert.That(result.Dice2, Is.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(6));
            Assert.That(result.Sum, Is.GreaterThanOrEqualTo(2).And.LessThanOrEqualTo(12));
        }

        [Test]
        public void RollDiceAsync_Throw_Error()
        {
            rollDiceRepositoryMock.SaveRolledDiceAsync(Arg.Any<RolledDiceData>(), Arg.Any<CancellationToken>()).Returns(false);

            var ex = Assert.ThrowsAsync<Exception>(() => rollingDiceService.RollDiceAsync(new RollDiceServiceRequest() { Email = "test@email.com" }, CancellationToken.None));

            Assert.That(ex.Message, Is.EqualTo("Failed to save rolled dice data"));
        }
    }
}