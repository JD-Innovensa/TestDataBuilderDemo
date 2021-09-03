using System.Collections.Generic;

namespace Domain
{
    public class Tourist
    {
        public ICollection<Excursion> Excursions { get; set; }

        public string FirstName { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }
    }
}