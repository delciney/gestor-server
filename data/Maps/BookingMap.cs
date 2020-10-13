using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookingCatalog.Models;

namespace BookingCatalog.Data.Maps
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.BookingDate).IsRequired();
            builder.Property(x => x.Start).IsRequired();
            builder.Property(x => x.End).IsRequired();
            builder.HasOne(x => x.LivingRoom).WithMany(x => x.Bookings);
        }
    }
}