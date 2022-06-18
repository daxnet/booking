using Booking.Services.MeetingRooms.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services.MeetingRooms
{
    public class MeetingRoomApplicationContext : DbContext
    {
        public MeetingRoomApplicationContext(DbContextOptions<MeetingRoomApplicationContext> options)
            : base(options)
        { }

        public DbSet<MeetingRoom>? MeetingRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingRoom>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<MeetingRoom>()
                .Property(e => e.ImageUrl)
                .IsRequired()
                .HasMaxLength(4096)
                .IsUnicode();
            modelBuilder.Entity<MeetingRoom>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode();
            modelBuilder.Entity<MeetingRoom>()
                .Property(e => e.Description)
                .HasMaxLength(4096)
                .IsUnicode();
            modelBuilder.Entity<MeetingRoom>()
                .ToTable("MeetingRooms");

            modelBuilder.Entity<Location>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Location>()
                .ToTable("Locations");

            modelBuilder.Entity<RoomConfiguration>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<RoomConfiguration>()
                .ToTable("RoomConfigurations");

            modelBuilder.Entity<MeetingRoom>()
                .HasOne(p => p.Location)
                .WithOne(p => p.MeetingRoom)
                .HasForeignKey<Location>(fke => fke.MeetingRoomId);

            modelBuilder.Entity<MeetingRoom>()
                .HasOne(p => p.Configuration)
                .WithOne(p => p.MeetingRoom)
                .HasForeignKey<RoomConfiguration>(fke => fke.MeetingRoomId);
        }
    }
}
