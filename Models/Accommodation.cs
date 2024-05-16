using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServiceAPI.Models
{
    public class Accommodation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public int Capacity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; }

        public string? Description { get; set; }
    }
}
