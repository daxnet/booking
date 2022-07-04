namespace Booking.Services.Reservations.Models
{
    public abstract class Recurrence
    {
        public static readonly Recurrence Default = new DefaultRecurrence();

        public abstract RecurrenceType Type { get; }

        public abstract bool IsOverlapped(DateTime utcStart, DateTime utcEnd);

        private class DefaultRecurrence : Recurrence
        {
            public override RecurrenceType Type => RecurrenceType.Daily;

            public override bool IsOverlapped(DateTime utcStart, DateTime utcEnd) => false;
        }
    }
}
