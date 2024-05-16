namespace BookingServiceAPI.Utilities.Exceptions
{
    public class BookingException : Exception
    {
        public BookingException() : base() { }

        public BookingException(string message) : base(message) { }

        public BookingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
