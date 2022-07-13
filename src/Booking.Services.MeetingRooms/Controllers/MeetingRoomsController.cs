using Booking.Services.MeetingRooms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services.MeetingRooms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly MeetingRoomApplicationContext _context;

        public MeetingRoomsController(MeetingRoomApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize("management.create")]
        public async Task<IActionResult> CreateMeetingRoom([FromBody] MeetingRoom meetingRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.MeetingRooms!.AddAsync(meetingRoom);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMeetingRoom), new { id = meetingRoom.Id }, meetingRoom.Id);
        }

        [HttpDelete("{id}")]
        [Authorize("management.delete")]
        public async Task<IActionResult> DeleteMeetingRoom(long id)
        {
            var meetingRoom = _context.MeetingRooms!.FirstOrDefault(mr => mr.Id == id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            _context.MeetingRooms!.Remove(meetingRoom);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize("management.read")]
        public IActionResult GetMeetingRoom(long id)
        {
            var meetingRoom = _context.MeetingRooms!.Include(r => r.Location)
                .Include(r => r.Configuration)
                .FirstOrDefault(r => r.Id == id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            return Ok(meetingRoom);
        }

        [HttpGet]
        [Authorize("management.read")]
        public IActionResult GetMeetingRooms([FromQuery] int pageSize = 10, int pageNumber = 0) => Ok(_context.MeetingRooms!
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .Include(r => r.Location)
                    .Include(r => r.Configuration));

        [HttpPatch("{id}")]
        [Authorize("management.update")]
        public async Task<IActionResult> PatchMeetingRoom(long id, [FromBody] JsonPatchDocument<MeetingRoom> patchDoc)
        {
            if (patchDoc != null)
            {
                var meetingRoom = _context.MeetingRooms!.Include(r => r.Location)
                    .Include(r => r.Configuration)
                    .FirstOrDefault(r => r.Id == id);

                if (meetingRoom == null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(meetingRoom, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _context.SaveChangesAsync();

                return new ObjectResult(meetingRoom);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
