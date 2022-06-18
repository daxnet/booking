namespace Booking.Services.MeetingRooms.Models
{
    /// <summary>
    /// Represents the meeting room entity.
    /// </summary>
    public class MeetingRoom
    {
        public RoomConfiguration Configuration { get; set; } = RoomConfiguration.Default;
        public string? Description { get; set; }
        public long Id { get; set; }

        public string? ImageUrl { get; set; }
        public bool? IsLocked { get; set; }
        public Location Location { get; set; } = Location.Default;
        public string Name { get; set; } = string.Empty;
        public ushort Seats { get; set; }

        public override string ToString() => Name;
    }
}