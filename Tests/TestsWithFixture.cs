using FluentAssertions;
using FluentAssertions.Execution;
using Service;
using Tests.Utility;
using Xunit;

namespace Tests
{
    public class TestsWithFixture : IClassFixture<TouristFixture>
    {
        private readonly TouristFixture _fixture;

        public TestsWithFixture(TouristFixture fixture)
        {
            _fixture = fixture;

            _fixture.SetupData();
        }

        [Fact]
        public void SwapPlaceVistsTest()
        {
            var service = new TouristService(DbContextFactory.CreateContext(_fixture.Db));

            var updatedExcursion = service.SwapPlaceVists(1, 1, 2);

            using (new AssertionScope())
            {
                updatedExcursion.PlaceVisits.Should().SatisfyRespectively(
                    first =>
                    {
                        first.Id.Should().Be(1);
                        first.Order.Should().Be(2);
                    },
                    first =>
                    {
                        first.Id.Should().Be(2);
                        first.Order.Should().Be(1);
                    });
            }
        }
    }
}