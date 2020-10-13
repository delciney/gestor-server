using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookingCatalog.Models;

namespace BookingCatalog.Data.Maps
{
    public class LivingRoomMap : IEntityTypeConfiguration<LivingRoom>
    {
        public void Configure(EntityTypeBuilder<LivingRoom> builder)
        {
            builder.ToTable("LivingRoom");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
        }
    }
}