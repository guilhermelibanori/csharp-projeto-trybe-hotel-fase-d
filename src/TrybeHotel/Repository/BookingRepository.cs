using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);
                var room = _context.Rooms.FirstOrDefault(r => r.RoomId == booking.RoomId);
                var hotel = _context.Hotels.FirstOrDefault(h => h.HotelId == room.HotelId);
                var city = _context.Cities.FirstOrDefault(c => c.CityId == hotel.CityId);
                var bookingEntity = new Booking
                {
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    GuestQuant = booking.GuestQuant,
                    Room = room,
                    User = user
                };
                _context.Bookings.Add(bookingEntity);
                _context.SaveChanges();
                return new BookingResponse
                {
                    BookingId = bookingEntity.BookingId,
                    CheckIn = bookingEntity.CheckIn,
                    CheckOut = bookingEntity.CheckOut,
                    GuestQuant = bookingEntity.GuestQuant,
                    Room = new RoomDto
                    {
                        RoomId = bookingEntity.Room.RoomId,
                        Name = bookingEntity.Room.Name,
                        Capacity = bookingEntity.Room.Capacity,
                        Image = bookingEntity.Room.Image,
                        Hotel = new HotelDto
                        {
                            HotelId = hotel.HotelId,
                            Name = hotel.Name,
                            Address = hotel.Address,
                            CityId = hotel.CityId,
                            CityName = city.Name,
                            State = city.State
                        }
                    }
                };
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomById(int RoomId)
        {
            throw new NotImplementedException();
        }

    }

}