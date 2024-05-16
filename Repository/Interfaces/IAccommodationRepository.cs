using BookingServiceAPI.Models;

namespace BookingServiceAPI.Repository.Interfaces
{
    public interface IAccommodationRepository
    {
        Task<IEnumerable<Accommodation>> GetAllAsync();
        Task<Accommodation> GetByIdAsync(int id);
        Task AddAsync(Accommodation accommodation);
        Task UpdateAsync(Accommodation accommodation);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
