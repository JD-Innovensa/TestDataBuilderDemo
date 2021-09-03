using System;
using Tests.DataBuilder;
using Tests.Utility;
using Ref = Tests.Utility.DataConstants;

namespace Tests
{
    public class TouristFixtureWithBuilder : BaseDatabaseFixture
    {
        public override void SetupData()
        {
            var marcoPolo = TouristFactory.CreateTourist(1, "Marco", "Polo")
                .WithExcursion(1, "My European City Break", DateTimeOffset.Now, DateTimeOffset.Now.AddDays(30))
                    .WithVisitToPlace(1, Ref.Paris)
                        .WithVisitToPointOfInterest(1, Ref.Louvre)
                        .WithVisitToPointOfInterest(2, Ref.EiffelTower)
                    .WithVisitToPlace(2, Ref.Berlin)
                        .WithVisitToPointOfInterest(3, Ref.Reichstag)
                            .BuildTourist();

            using var context = DbContextFactory.CreateContext(Db);

            context.Tourists.Add(marcoPolo);

            context.SaveChanges();
        }
    }
}