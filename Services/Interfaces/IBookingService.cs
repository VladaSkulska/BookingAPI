using BookingServiceAPI.Models;
using BookingServiceAPI.Models.DTOs;

namespace BookingServiceAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task<BookingDto> AddBookingAsync(BookingDto bookingDto);
        Task<Booking> DeleteBookingAsync(int id);
    }
}
