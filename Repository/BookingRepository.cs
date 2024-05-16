using BookingServiceAPI.Data;
using BookingServiceAPI.Models;
using BookingServiceAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingServiceAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public async Task<Booking> DeleteAsync(int id)
        {
            var booking = await GetByIdAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            return booking;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
