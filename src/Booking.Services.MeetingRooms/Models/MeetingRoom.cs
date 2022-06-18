namespace Booking.Services.MeetingRooms.Models
{
    /// <summary>
    /// Represents the meeting room entity.
    /// </summary>
    public class MeetingRoom
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ushort Seats { get; set; }

        public bool IsLocked { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public Location Location { get; set; } = Location.Default;

        public RoomConfiguration Configuration { get; set; } = RoomConfiguration.Default;

        public override string ToString() => Name;
    }
}
