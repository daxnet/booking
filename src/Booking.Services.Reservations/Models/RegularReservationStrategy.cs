namespace Booking.Services.Reservations.Models
{
    public sealed class RegularReservationStrategy : IReservationStrategy
    {
        public RegularReservationStrategy() { }

        public DateTime UtcStart { get; set; }

        public DateTime UtcEnd { get; set; }

        public bool IsAvailable(DateTime utcStart, DateTime utcEnd)
        {
            if (utcEnd < utcStart)
            {
                throw new InvalidOperationException("Start time should be less than end time.");
            }

            return (UtcStart > utcStart && UtcStart < utcEnd) || (UtcEnd > utcStart && UtcEnd < utcEnd);
        }
    }
}
