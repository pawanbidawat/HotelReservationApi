using Microsoft.EntityFrameworkCore;

namespace HotelApi.Models.DTO
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options)
        {
            
        }

        public DbSet<HotelDetailsModel> HotelDetails { get; set; }
        public DbSet<HotelRoomModel> HotelRooms { get; set; }  
        public DbSet<BlackoutDateModel> BlackoutDate { get; set;}
        public DbSet<RoomDateRangeModel> RoomDateRanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between HotelRoomModel and BlackoutDateModel
            modelBuilder.Entity<HotelRoomModel>()
                .HasMany(room => room.BlackoutDates)
                .WithOne(blackoutDate => blackoutDate.RoomModel)
                .HasForeignKey(blackoutDate => blackoutDate.RoomId);

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }

    }
}
