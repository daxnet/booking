namespace Booking.Services.Reservations.Models
{
    public interface IReservationStrategy
    {
        bool IsAvailable(DateTime utcStart, DateTime utcEnd);
    }
}
