using System.Text.Json.Serialization;

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
        /// <summary>
        /// Returns the default location.
        /// </summary>
        public static readonly Location Default = new();

        public Location()
        { }

        public string? Area { get; set; }
        public string? Building { get; set; }
        public string? Floor { get; set; }

        [JsonIgnore]
        public long Id { get; set; }

        [JsonIgnore]
        public MeetingRoom? MeetingRoom { get; set; }

        [JsonIgnore]
        public long MeetingRoomId { get; set; }
    }
}
