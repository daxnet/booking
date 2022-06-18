using System.Text.Json.Serialization;

namespace Booking.Services.MeetingRooms.Models
{
    /// <summary>
    /// Represents the entity that holds the meeting room configuration information.
    /// </summary>
    public class RoomConfiguration
    {
        public static readonly RoomConfiguration Default = new();

        /// <summary>
        /// Initializes a new instance of the <c>RoomConfiguration</c> class.
        /// </summary>
        public RoomConfiguration()
        {

        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value which indicates whether
        /// the meeting room has a projector.
        /// </summary>
        public bool? HasProjector { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value which indicates whether
        /// the meeting room has a white board.
        /// </summary>
        public bool? HasWhiteBoard { get; set; }

        /// <summary>
        /// Gets or sets the id of the room configuration.
        /// </summary>
        [JsonIgnore]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the instance of the meeting room.
        /// </summary>
        [JsonIgnore]
        public MeetingRoom? MeetingRoom { get; set; }

        /// <summary>
        /// Gets or sets the id of the meeting room that associates
        /// with the current room configuration.
        /// </summary>
        [JsonIgnore]
        public long MeetingRoomId { get; set; }
    }
}
