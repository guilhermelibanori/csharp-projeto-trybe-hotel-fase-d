using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Refatore o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            return _context.Cities.Select(c => new CityDto
            {
                CityId = c.CityId,
                Name = c.Name,
                State = c.State
            });
        }

        // 3. Desenvolva o endpoint POST /city
        public CityDto AddCity(City city)
        {
            try
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
                return new CityDto
                {
                    CityId = city.CityId,
                    Name = city.Name,
                    State = city.State
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // 3. Desenvolva o endpoint PUT /city
        public CityDto UpdateCity(City city)
        {
            try
            {
                var existingCity = _context.Cities.Find(city.CityId);
                existingCity.Name = city.Name;
                existingCity.State = city.State;
                _context.SaveChanges();
                return new CityDto
                {
                    CityId = existingCity.CityId,
                    Name = existingCity.Name,
                    State = existingCity.State
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}