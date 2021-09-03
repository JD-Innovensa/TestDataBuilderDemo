using System.Collections.Generic;

namespace Domain
{
    public class PlaceVisit
    {
        public int ExcursionId { get; set; }

        public int Id { get; set; }

        public int Order { get; set; }

        public Place Place { get; set; }

        public int PlaceId { get; set; }

        public ICollection<PointOfInterestVisit> PointOfInterests { get; set; }
    }
}