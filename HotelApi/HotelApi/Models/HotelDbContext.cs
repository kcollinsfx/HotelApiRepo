using Microsoft.EntityFrameworkCore;

namespace HotelApi.Models
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestInvoice> Invoices { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservedRoom> ReservedRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Reservation>().Property(p => p.TotalPrice).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Room>().Property(p => p.RoomPrice).HasColumnType("decimal(10,2)");
        
        }
    }
}
