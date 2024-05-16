using AutoMapper;
using BookingServiceAPI.Models;
using BookingServiceAPI.Models.DTOs;

namespace BookingServiceAPI.Utilities.Mapper
{
    public class AccommodationMappingProfile : Profile
    {
        public AccommodationMappingProfile()
        {
            CreateMap<Accommodation, AccommodationDto>();
            CreateMap<AccommodationDto, Accommodation>();
        }
    }
}
