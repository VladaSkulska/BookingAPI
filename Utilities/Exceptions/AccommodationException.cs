namespace BookingServiceAPI.Utilities.Exceptions
{
    public class AccommodationException : Exception
    {
        public AccommodationException() { }

        public AccommodationException(string message) : base(message) { }

        public AccommodationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
