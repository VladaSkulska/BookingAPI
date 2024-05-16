using BookingServiceAPI.Models.DTOs;
using BookingServiceAPI.Services.Interfaces;
using BookingServiceAPI.Utilities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllBookings()
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingsAsync();
                return Ok(bookings);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetBookingById(int id)
        {
            try
            {
                var booking = await _bookingService.GetBookingByIdAsync(id);
                return Ok(booking);
            }
            catch (BookingException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BookingDto>> AddBooking(BookingDto bookingDto)
        {
            try
            {
                var newBooking = await _bookingService.AddBookingAsync(bookingDto);
                return CreatedAtAction(nameof(GetBookingById), new { id = newBooking.Id }, newBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                var deletedBooking = await _bookingService.DeleteBookingAsync(id);
                return Ok(deletedBooking);
            }
            catch (BookingException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
