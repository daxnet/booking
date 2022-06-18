namespace Booking.Services.MeetingRooms.Models
{
    public record RoomConfiguration(
        long Id, 
        long MeetingRoomId, 
        MeetingRoom MeetingRoom, 
        bool HasProjector, 
        bool HasWhiteBoard)
    {
        public static readonly RoomConfiguration Default = new(0, 0, new MeetingRoom(), true, true);
    }
}
