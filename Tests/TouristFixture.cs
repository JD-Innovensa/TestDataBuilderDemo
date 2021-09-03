using Domain;
using System;
using Tests.Utility;
using Ref = Tests.Utility.DataConstants;

namespace Tests
{
    public class TouristFixture : BaseDatabaseFixture
    {
        public override void SetupData()
        {
            using var context = DbContextFactory.CreateContext(Db);

            context.Tourists.Add(new Tourist { Id = 1, FirstName = "Marco", LastName = "Polo" });
            context.Excursions.Add(new Excursion
                { Id = 1, TouristId = 1, Name = "My European City Break", Start = DateTimeOffset.Now, End = DateTimeOffset.Now.AddDays(30) });
            context.PlaceVisits.AddRange(
                new PlaceVisit { Id = 1, ExcursionId = 1, PlaceId = Ref.Paris, Order = 1 },
                new PlaceVisit { Id = 2, ExcursionId = 1, PlaceId = Ref.Berlin, Order = 2 });
            context.PointOfInterestVisits.AddRange(
                new PointOfInterestVisit { Id = 1, VisitId = 1, PointOfInterestId = Ref.Louvre },
                new PointOfInterestVisit { Id = 2, VisitId = 1, PointOfInterestId = Ref.EiffelTower },
                new PointOfInterestVisit { Id = 3, VisitId = 2, PointOfInterestId = Ref.Reichstag });

            context.SaveChanges();
        }
    }
}