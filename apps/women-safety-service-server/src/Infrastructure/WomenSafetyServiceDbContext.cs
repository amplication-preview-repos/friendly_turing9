using Microsoft.EntityFrameworkCore;
using WomenSafetyService.Infrastructure.Models;

namespace WomenSafetyService.Infrastructure;

public class WomenSafetyServiceDbContext : DbContext
{
    public WomenSafetyServiceDbContext(DbContextOptions<WomenSafetyServiceDbContext> options)
        : base(options) { }

    public DbSet<EmergencyContactDbModel> EmergencyContacts { get; set; }

    public DbSet<LocationDbModel> Locations { get; set; }

    public DbSet<SafePathDbModel> SafePaths { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
