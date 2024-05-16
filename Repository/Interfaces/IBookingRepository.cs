using BookingServiceAPI.Models;

namespace BookingServiceAPI.Repository.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task AddAsync(Booking booking);
        Task<Booking> DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
