using BookingServiceAPI.Data;
using BookingServiceAPI.Models;
using BookingServiceAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingServiceAPI.Repository
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly AppDbContext _context;

        public AccommodationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Accommodation>> GetAllAsync()
        {
            return await _context.Accommodations.ToListAsync();
        }

        public async Task<Accommodation> GetByIdAsync(int id)
        {
            return await _context.Accommodations.FindAsync(id);
        }

        public async Task AddAsync(Accommodation accommodation)
        {
            await _context.Accommodations.AddAsync(accommodation);
        }

        public async Task UpdateAsync(Accommodation newAccommodation)
        {
            var existingAccommodation = await _context.Accommodations.FindAsync(newAccommodation.Id);

            if (existingAccommodation != null)
            {
                existingAccommodation.Name = newAccommodation.Name;
                existingAccommodation.Location = newAccommodation.Location;
                existingAccommodation.Capacity = newAccommodation.Capacity;
                existingAccommodation.PricePerNight = newAccommodation.PricePerNight;
                existingAccommodation.IsAvailable = newAccommodation.IsAvailable;
                existingAccommodation.Description = newAccommodation.Description;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var accommodation = await GetByIdAsync(id);
            if (accommodation != null)
            {
                _context.Accommodations.Remove(accommodation);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
