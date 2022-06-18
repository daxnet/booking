namespace Booking.Services.MeetingRooms.Models
{
    /// <summary>
    /// Represents the location of a meeting room.
    /// </summary>
    /// <param name="Building">The name of the building where the meeting room is.</param>
    /// <param name="Floor">The name of the floor in the building where the meeting room is.</param>
    /// <param name="Area">The area on the floor where the meeting room is.</param>
    public class Location
    {
        public Location()
        { }

        public Location(
            long Id,
            long MeetingRoomId,
            MeetingRoom MeetingRoom,
            string Building,
            string Floor,
            string Area)
        {

        }

        /// <summary>
        /// Returns the default location.
        /// </summary>
        public static readonly Location Default = new(0, 0, new MeetingRoom(), string.Empty, string.Empty, string.Empty);
    }
}
