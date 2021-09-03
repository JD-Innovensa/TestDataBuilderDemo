using System.Collections.Generic;

namespace Domain
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PlaceType PlaceType { get; set; }

        public ICollection<PointOfInterest> PointOfInterests { get; set; }
    }
}