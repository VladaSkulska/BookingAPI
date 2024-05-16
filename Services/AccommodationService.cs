using AutoMapper;
using BookingServiceAPI.Models;
using BookingServiceAPI.Models.DTOs;
using BookingServiceAPI.Repository.Interfaces;
using BookingServiceAPI.Services.Interfaces;
using BookingServiceAPI.Utilities.Exceptions;

namespace BookingServiceAPI.Services
{
    public class AccommodationService : IAccommodationService
    {
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IMapper _accommodationMapper;

        public AccommodationService(IAccommodationRepository accommodationRepository, IMapper mapper)
        {
            _accommodationRepository = accommodationRepository;
            _accommodationMapper = mapper;
        }

        public async Task<IEnumerable<AccommodationDto>> GetAllAccommodationsAsync()
        {
            var accommodations = await _accommodationRepository.GetAllAsync();

            return _accommodationMapper.Map<IEnumerable<AccommodationDto>>(accommodations);
        }

        public async Task<AccommodationDto> GetAccommodationByIdAsync(int id)
        {
            var accommodation = await _accommodationRepository.GetByIdAsync(id);

            if (accommodation == null)

            {
                throw new AccommodationException($"Booking with ID {id} not found.");
            }

            return _accommodationMapper.Map<AccommodationDto>(accommodation);
        }

        public async Task<AccommodationDto> AddAccommodationAsync(AccommodationDto accommodationDto)
        {
            var accommodation = _accommodationMapper.Map<Accommodation>(accommodationDto);

            await _accommodationRepository.AddAsync(accommodation);
            await _accommodationRepository.SaveChangesAsync();

            return _accommodationMapper.Map<AccommodationDto>(accommodation);
        }

        public async Task UpdateAccommodationAsync(int id, AccommodationDto accommodationDto)
        {
            var existingAccommodation = await _accommodationRepository.GetByIdAsync(id);
            if (existingAccommodation == null)
            {
                throw new AccommodationException("Accommodation not found");
            }

            var updatedAccommodation = _accommodationMapper.Map(accommodationDto, existingAccommodation);
            await _accommodationRepository.UpdateAsync(updatedAccommodation);
        }

        public async Task<Accommodation> DeleteAccommodationAsync(int id)
        {
            var existingAccommodation = await _accommodationRepository.GetByIdAsync(id);
            if (existingAccommodation == null)
            {
                throw new AccommodationException("Accommodation not found");
            }

            await _accommodationRepository.DeleteAsync(id);
            return existingAccommodation;
        }
    }
}