using FluentAssertions;
using FluentAssertions.Execution;
using Service;
using Tests.Utility;
using Xunit;
using Ref = Tests.Utility.DataConstants;

namespace Tests
{
    public class TestsWithFixtureAndBuilder : IClassFixture<TouristFixtureWithBuilder>
    {
        private readonly TouristFixtureWithBuilder _fixture;

        public TestsWithFixtureAndBuilder(TouristFixtureWithBuilder fixture)
        {
            _fixture = fixture;

            _fixture.SetupData();
        }

        [Fact]
        public void SwapPlaceVistsTest()
        {
            var service = new TouristService(DbContextFactory.CreateContext(_fixture.Db));

            var excursionId = 1;

            var updatedExcursion = service.SwapPlaceVists(excursionId, Ref.Paris, Ref.Berlin);

            using (new AssertionScope())
            {
                updatedExcursion.Id.Should().Be(excursionId);

                updatedExcursion.PlaceVisits.Should().SatisfyRespectively(
                    first =>
                    {
                        first.Id.Should().Be(Ref.Paris);
                        first.Order.Should().Be(2);
                    },
                    second =>
                    {
                        second.Id.Should().Be(Ref.Berlin);
                        second.Order.Should().Be(1);
                    });
            }
        }
    }
}