namespace BookingServiceAPI.Models.DTOs
{
    public class AccommodationDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; }

        public string Description { get; set; }
    }
}