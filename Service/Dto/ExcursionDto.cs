using System;
using System.Collections.Generic;

namespace Service.Dto
{
    public class ExcursionDto
    {
        public DateTimeOffset End { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PlaceVisitDto> PlaceVisits { get; set; }

        public DateTimeOffset Start { get; set; }
    }
}