namespace Domain
{
    public class PointOfInterest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Place Place { get; set; }

        public int PlaceId { get; set; }
    }
}