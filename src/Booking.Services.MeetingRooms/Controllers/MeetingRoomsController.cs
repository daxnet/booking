using Booking.Services.MeetingRooms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services.MeetingRooms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly MeetingRoomApplicationContext _context;

        public MeetingRoomsController(MeetingRoomApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMeetingRooms()
        {
            return Ok(_context.MeetingRooms!.Include(r => r.Location).Include(r=>r.Configuration));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeetingRoom([FromBody] MeetingRoom meetingRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.MeetingRooms!.AddAsync(meetingRoom);
            await _context.SaveChangesAsync();
            return Ok(meetingRoom.Id);
        }
    }
}
