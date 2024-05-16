namespace BookingServiceAPI.Models.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string AccommodationName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
