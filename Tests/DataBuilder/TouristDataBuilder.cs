using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.DataBuilder
{
    public class TouristDataBuilder : ITouristDatabuilder
    {
        private Tourist _tourist;

        public Tourist BuildTourist()
        {
            return _tourist;
        }

        public ITouristDatabuilder CreateTourist(int id, string firstName, string lastName)
        {
            if (_tourist != null)
            {
                throw new Exception("Tourist already exists!");
            }

            _tourist = new Tourist
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
            };

            return this;
        }

        public ITouristDatabuilder WithExcursion(int id, string name, DateTimeOffset start, DateTimeOffset end)
        {
            if (_tourist.Excursions == null)
            {
                _tourist.Excursions = new List<Excursion>();
            }

            _tourist.Excursions.Add(
                new Excursion
                {
                    Id = id,
                    TouristId = _tourist.Id,
                    Name = name,
                    Start = start,
                    End = end,
                });

            return this;
        }

        public ITouristDatabuilder WithVisitToPlace(int id, int placeId)
        {
            var excursion = _tourist.Excursions?.Last();

            if (excursion.PlaceVisits == null)
            {
                excursion.PlaceVisits = new List<PlaceVisit>();
            }

            excursion.PlaceVisits.Add(new PlaceVisit
            {
                Id = id,
                ExcursionId = excursion.Id,
                PlaceId = placeId,
                Order = excursion.PlaceVisits.Count + 1,
            });

            return this;
        }

        public ITouristDatabuilder WithVisitToPointOfInterest(int id, int pointOfInterestId)
        {
            var placeVisit = _tourist.Excursions?.Last().PlaceVisits?.Last();

            if (placeVisit.PointOfInterests == null)
            {
                placeVisit.PointOfInterests = new List<PointOfInterestVisit>();
            }

            placeVisit.PointOfInterests.Add(new PointOfInterestVisit
            {
                Id = id,
                PointOfInterestId = pointOfInterestId,
            });

            return this;
        }
    }
}