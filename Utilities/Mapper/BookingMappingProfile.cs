using AutoMapper;
using BookingServiceAPI.Models.DTOs;
using BookingServiceAPI.Models;

namespace BookingServiceAPI.Utilities.Mapper
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile() 
        {
            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>();
        }
    }
}
