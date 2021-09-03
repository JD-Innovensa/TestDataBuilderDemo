using System;
using System.Collections.Generic;

namespace Domain
{
    public class Excursion
    {
        public DateTimeOffset End { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PlaceVisit> PlaceVisits { get; set; }

        public DateTimeOffset Start { get; set; }

        public int TouristId { get; set; }
    }
}