using hotels.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace hotels.Infrastructure.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public required DbSet<HotelEntity> Hotels { get; set; }
    public required DbSet<SuiteEntity> HotelSuits { get; set; }
    public required DbSet<HotelChainEntity> HotelChains { get; set; }
    public required DbSet<LocationEntity> Locations { get; set; }
    public required DbSet<UserEntity> Users { get; set; }
    public required DbSet<UserInfoEntity> UserInfos { get; set; }
    public required DbSet<ReservationEntity> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Entity<HotelEntity>().ToTable("hotel", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<SuiteEntity>().ToTable("hotel_suit", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<HotelChainEntity>().ToTable("hotel_chain", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<LocationEntity>().ToTable("location", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<UserEntity>().ToTable("user", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<UserInfoEntity>().ToTable("user_info", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<ReservationEntity>().ToTable("reservation", t => t.ExcludeFromMigrations());
    }
}
