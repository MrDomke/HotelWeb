using Microsoft.AspNetCore.Mvc;
using HotelAPI.Models;
using HotelAPI.Repositories.Interface;
using System;
using System.Threading.Tasks;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingsRepository _bookingRepository;

        public BookingController(IBookingsRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> BookHotelRoom([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            booking.TotalCost = CalculateTotalCost(booking);
            var createdBooking = await _bookingRepository.BookHotelRoomAsync(booking);
            return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Id }, createdBooking);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }

        [HttpGet]
        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }

        private decimal CalculateTotalCost(Booking booking)
        {
            decimal roomRate = booking.RoomType switch
            {
                "Standard" => 100m,
                "Deluxe" => 150m,
                "Suite" => 200m,
                _ => 0m
            };

            decimal totalCost = (roomRate * booking.NumberOfNights) +
                                (booking.BreakfastIncluded ? 15m * booking.NumberOfGuests * booking.NumberOfNights : 0m) +
                                20m;

            return totalCost;
        }

    }
}
