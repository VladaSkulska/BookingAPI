using BookingServiceAPI.Models;
using BookingServiceAPI.Models.DTOs;

namespace BookingServiceAPI.Services.Interfaces
{
    public interface IAccommodationService
    {
        Task<IEnumerable<AccommodationDto>> GetAllAccommodationsAsync();
        Task<AccommodationDto> GetAccommodationByIdAsync(int id);
        Task<AccommodationDto> AddAccommodationAsync(AccommodationDto accommodationDto);
        Task UpdateAccommodationAsync(int id, AccommodationDto accommodationDto);
        Task<Accommodation> DeleteAccommodationAsync(int id);
    }
}
