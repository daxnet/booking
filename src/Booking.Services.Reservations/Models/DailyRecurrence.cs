namespace Booking.Services.Reservations.Models
{
    public class DailyRecurrence : Recurrence
    {
        public override RecurrenceType Type => RecurrenceType.Daily;

        public int EveryNumberOfDays { get; set; }

        public bool EveryWeekDay { get; set; }

        public override bool IsOverlapped(DateTime utcStart, DateTime utcEnd)
        {
            if (EveryWeekDay)
            {

            }
            else
            {

            }
        }
    }
}
