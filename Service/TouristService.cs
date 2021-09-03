using AgileObjects.AgileMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Service.Dto;
using System.Linq;

namespace Service
{
    public class TouristService
    {
        private readonly ApplicationDbContext _context;

        public TouristService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExcursionDto SwapPlaceVists(int excursionId, int firstPlaceId, int secondPlaceId)
        {
            var placeVisits = _context.PlaceVisits
                .Where(x => x.ExcursionId == excursionId)
                .ToList();

            var firstPlace = placeVisits.First(x => x.Id == firstPlaceId);

            var secondPlace = placeVisits.First(x => x.Id == secondPlaceId);

            int firstPlaceOrder = firstPlace.Order;

            firstPlace.Order = secondPlace.Order;

            secondPlace.Order = firstPlaceOrder;

            _context.SaveChanges();

            var excursion = _context.Excursions
                .Include(x => x.PlaceVisits)
                    .ThenInclude(x => x.Place)
                .Where(x => x.Id == excursionId)
                .AsNoTracking()
                .First();

            var excursionDto = Mapper.Map(excursion).ToANew<ExcursionDto>();

            return excursionDto;
        }
    }
}