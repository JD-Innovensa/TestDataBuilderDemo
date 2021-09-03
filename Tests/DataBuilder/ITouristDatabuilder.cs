using Domain;
using System;

namespace Tests.DataBuilder
{
    public interface ITouristDatabuilder
    {
        /// <summary>
        /// Call to return the Tourist.
        /// </summary>
        /// <returns></returns>
        public Tourist BuildTourist();

        /// <summary>
        /// Add first.
        /// </summary>
        /// <returns></returns>
        public ITouristDatabuilder CreateTourist(int id, string firstName, string lastName);

        /// <summary>
        /// Add to Tourist.
        /// </summary>
        /// <returns></returns>
        public ITouristDatabuilder WithExcursion(int id, string name, DateTimeOffset start, DateTimeOffset end);

        /// <summary>
        /// Add to Excursion.
        /// </summary>
        /// <returns></returns>
        public ITouristDatabuilder WithVisitToPlace(int id, int placeId);

        /// <summary>
        /// Add to Visit.
        /// </summary>
        /// <returns></returns>
        public ITouristDatabuilder WithVisitToPointOfInterest(int id, int pointOfInterestId);
    }
}