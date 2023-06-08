using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Versta.OrderApi.Models;

namespace Versta.OrderApi.DbContexts;

public partial class VerstaDbContext : DbContext
{
    public VerstaDbContext()
    {
    }

    public VerstaDbContext(DbContextOptions<VerstaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("addresses_pkey");

            entity.ToTable("addresses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Block)
                .HasMaxLength(8)
                .HasColumnName("block");
            entity.Property(e => e.BuildingNumber).HasColumnName("building_number");
            entity.Property(e => e.City)
                .HasMaxLength(32)
                .HasColumnName("city");
            entity.Property(e => e.FlatNumber).HasColumnName("flat_number");
            entity.Property(e => e.HouseNumber).HasColumnName("house_number");
            entity.Property(e => e.StreetName)
                .HasMaxLength(64)
                .HasColumnName("street_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CargoWeight)
                .HasPrecision(6, 3)
                .HasColumnName("cargo_weight");
            entity.Property(e => e.PickupDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("pickup_date");
            entity.Property(e => e.RecipientAddressId).HasColumnName("recipient_address_id");
            entity.Property(e => e.SenderAddressId).HasColumnName("sender_address_id");

            entity.HasOne(d => d.RecipientAddress).WithMany(p => p.OrderRecipientAddresses)
                .HasForeignKey(d => d.RecipientAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_recipient_address_id");

            entity.HasOne(d => d.SenderAddress).WithMany(p => p.OrderSenderAddresses)
                .HasForeignKey(d => d.SenderAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sender_address_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
