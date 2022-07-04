namespace Booking.Services.Reservations.Models
{
    public class RecurrenceReservationStrategy : IReservationStrategy
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public Recurrence Recurrence { get; set; } = Recurrence.Default;

        public bool IsAvailable(DateTime utcStart, DateTime utcEnd) => !Recurrence.IsOverlapped(utcStart, utcEnd);
    }
}
