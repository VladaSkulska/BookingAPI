using BookingServiceAPI.Data;
using BookingServiceAPI.Models;

namespace BookingServiceAPI.Utilities
{
    public class DbInitializer
    {
        public static void SeedBookings(AppDbContext context)
        {
            if (context.Bookings.Any())
            {
                return; 
            }

            var accommodations = context.Accommodations.Take(3).ToList();

            var bookings = new Booking[]
            {
                new Booking
                {
                    UserId = 1, 
                    AccommodationId = accommodations[0].Id,
                    CheckInDate = DateTime.UtcNow.Date.AddDays(1),
                    CheckOutDate = DateTime.UtcNow.Date.AddDays(3),
                    BookingDate = DateTime.UtcNow,
                    TotalPrice = (accommodations[0].PricePerNight * 2), 
                    IsCancelled = false
                },
                new Booking
                {
                    UserId = 1, 
                    AccommodationId = accommodations[1].Id,
                    CheckInDate = DateTime.UtcNow.Date.AddDays(4),
                    CheckOutDate = DateTime.UtcNow.Date.AddDays(7),
                    BookingDate = DateTime.UtcNow,
                    TotalPrice = (accommodations[1].PricePerNight * 3), 
                    IsCancelled = false
                },
                new Booking
                {
                    UserId = 1, 
                    AccommodationId = accommodations[2].Id,
                    CheckInDate = DateTime.UtcNow.Date.AddDays(2),
                    CheckOutDate = DateTime.UtcNow.Date.AddDays(5),
                    BookingDate = DateTime.UtcNow,
                    TotalPrice = (accommodations[2].PricePerNight * 3), 
                    IsCancelled = false
                }
            };

            context.Bookings.AddRange(bookings);

            context.SaveChanges();
        }


        public static void SeedAccommodations(AppDbContext context)
        {
            if (context.Accommodations.Any())
            {
                return;
            }

            var accommodations = new Accommodation[]
            {
            new Accommodation
            {
                Name = "Luxury Hotel",
                Location = "City Center",
                Capacity = 100,
                PricePerNight = 200,
                IsAvailable = true,
                Description = "A luxurious hotel located in the heart of the city."
            },
            new Accommodation
            {
                Name = "Beach Resort",
                Location = "Beachfront",
                Capacity = 50,
                PricePerNight = 300,
                IsAvailable = true,
                Description = "A beautiful beach resort offering stunning ocean views."
            },
            new Accommodation
            {
                Name = "Mountain Lodge",
                Location = "Mountain Range",
                Capacity = 30,
                PricePerNight = 150,
                IsAvailable = true,
                Description = "A cozy lodge nestled in the mountains, perfect for nature lovers."
            },
            new Accommodation
            {
                Name = "Rural Retreat",
                Location = "Countryside",
                Capacity = 20,
                PricePerNight = 100,
                IsAvailable = true,
                Description = "A peaceful retreat in the countryside, ideal for relaxation."
            },
            new Accommodation
            {
                Name = "Urban Loft",
                Location = "Downtown",
                Capacity = 10,
                PricePerNight = 250,
                IsAvailable = true,
                Description = "A stylish urban loft with modern amenities, perfect for city living."
            },
            new Accommodation
            {
                Name = "Ski Chalet",
                Location = "Ski Resort",
                Capacity = 15,
                PricePerNight = 350,
                IsAvailable = true,
                Description = "A charming chalet located near the ski slopes, ideal for winter getaways."
            }
            };

            context.Accommodations.AddRange(accommodations);
            context.SaveChanges();
        }
    }
}
