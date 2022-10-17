using MeetingRoomApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeetingRommApp.Data
{
    public class MeetingRoomDbContext:DbContext
    {
        public MeetingRoomDbContext(DbContextOptions<MeetingRoomDbContext> options):base(options)
        {

        }
        public DbSet<MeetingRoomType>    MeetingRoomTypes { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Dhivya-Pc\\SqlExpress;Database=MeetingRoomDB_MVC;integrated security=true");
        }
    }
}
