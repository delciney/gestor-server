using Microsoft.EntityFrameworkCore;
using BookingCatalog.Data.Maps;
using BookingCatalog.Models;

namespace BookingCatalog.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<LivingRoom> LivingRooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=gestor;User ID=SA;Password=1q2w3e%&");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookingMap());
            builder.ApplyConfiguration(new LivingRoomMap());
        }
    }
}