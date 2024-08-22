using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            return _context.Hotels.Select(h => new HotelDto
            {
                HotelId = h.HotelId,
                Name = h.Name,
                Address = h.Address,
                CityId = h.CityId,
                CityName = h.City.Name,
                State = h.City.State
            });
        }

        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            try
            {
                var validCity = _context.Cities.Find(hotel.CityId);
                _context.Hotels.Add(hotel);
                _context.SaveChanges();
                return new HotelDto
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CityId = hotel.CityId,
                    CityName = hotel.City.Name,
                    State = hotel.City.State
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}