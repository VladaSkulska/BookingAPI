using AutoMapper;
using BookingServiceAPI.Models;
using BookingServiceAPI.Models.DTOs;
using BookingServiceAPI.Repository.Interfaces;
using BookingServiceAPI.Services.Interfaces;
using BookingServiceAPI.Utilities.Exceptions;

namespace BookingServiceAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _bookingMapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _bookingMapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();

            return _bookingMapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);

            if (booking == null)
            {
                throw new BookingException($"Booking with ID {id} not found.");
            }

            return _bookingMapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> AddBookingAsync(BookingDto bookingDto)
        {
            var booking = _bookingMapper.Map<Booking>(bookingDto);

            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();

            return _bookingMapper.Map<BookingDto>(booking);
        }

        public async Task<Booking> DeleteBookingAsync(int id)
        {
            var existingBooking = await _bookingRepository.DeleteAsync(id);

            if (existingBooking == null)
            {
                throw new BookingException($"Booking with ID {id} not found");
            }

            await _bookingRepository.SaveChangesAsync();
            return existingBooking;
        }
    }
}