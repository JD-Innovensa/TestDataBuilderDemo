namespace Domain
{
    public class PointOfInterestVisit
    {
        public int Id { get; set; }

        public PlaceVisit PlaceVisit { get; set; }

        public int PointOfInterestId { get; set; }

        public int VisitId { get; set; }
    }
}