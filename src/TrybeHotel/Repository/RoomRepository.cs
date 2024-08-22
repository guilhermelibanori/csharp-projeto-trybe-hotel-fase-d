using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var validCity = _context.Cities.Find(HotelId);
            var hotel = _context.Hotels.Find(HotelId);
            var rooms = _context.Rooms.Where(r => r.HotelId == HotelId);

            var roomsDto = rooms.Select(r => new RoomDto
            {
                RoomId = r.RoomId,
                Name = r.Name,
                Capacity = r.Capacity,
                Image = r.Image,
                Hotel = new HotelDto
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CityId = hotel.CityId,
                    CityName = hotel.City.Name,
                    State = hotel.City.State
                }
            });
            return roomsDto;
        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room)
        {
            try
            {
                var hotel = _context.Hotels.Find(room.HotelId);
                Console.WriteLine(hotel);
                var validCity = _context.Cities.Find(hotel.CityId);
                Console.WriteLine(validCity);
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return new RoomDto
                {
                    RoomId = room.RoomId,
                    Name = room.Name,
                    Capacity = room.Capacity,
                    Image = room.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = hotel.HotelId,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        CityId = validCity.CityId,
                        CityName = validCity.Name,
                        State = validCity.State
                    }

                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            var room = _context.Rooms.Find(RoomId);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}