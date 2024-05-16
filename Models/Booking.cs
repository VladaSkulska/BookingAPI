using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServiceAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Accommodation))]
        public int AccommodationId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public DateTime BookingDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        public bool IsCancelled { get; set; }
    }
}