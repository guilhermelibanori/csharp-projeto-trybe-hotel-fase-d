using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TrybeHotel.Dto;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("booking")]

    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize(Policy = "Client")]
        public IActionResult Add([FromBody] BookingDtoInsert bookingInsert)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                var booking = _repository.Add(bookingInsert, email);
                return Created("", booking);
            }
            catch (System.Exception e)
            {
                return Unauthorized(new { message = e.Message });
            }
        }


        [HttpGet("{Bookingid}")]
        [Authorize(Policy = "Client")]
        public IActionResult GetBooking(int Bookingid)
        {
            // try
            // {
            //     var email = User.FindFirst(ClaimTypes.Email)?.Value;
            //     var booking = _repository.GetBooking(Bookingid, email);
            //     return Created("", booking);
            // }
            // catch (Exception e)
            // {
            //     return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            // }
            throw new System.NotImplementedException();
        }
    }
}