using System;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    /// <summary>
    /// Entity Framework database context for the renting microservice.
    /// </summary>
    public sealed class RentingDbContext(DbContextOptions<RentingDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Gets or sets the vehicles table.
        /// </summary>
        public DbSet<VehicleEntity> Vehicles { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            modelBuilder.Entity<VehicleEntity>(builder =>
            {
                builder.ToTable("Vehicles");

                builder.HasKey(vehicle => vehicle.Id);

                builder.Property(vehicle => vehicle.Plate)
                    .IsRequired()
                    .HasMaxLength(20);

                builder.HasIndex(vehicle => vehicle.Plate)
                    .IsUnique();

                builder.Property(vehicle => vehicle.Brand)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(vehicle => vehicle.Model)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(vehicle => vehicle.ManufacturingDate)
                    .IsRequired();

                builder.Property(vehicle => vehicle.Status)
                    .IsRequired()
                    .HasMaxLength(30);

                builder.Property(vehicle => vehicle.CurrentCustomerId)
                    .HasMaxLength(100);
            });
        }
    }
}
