using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Destination> Destinations { get; set; }
    
    
    
    public DbSet<Consignees> Consignees { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // configuracion de tabla destino
        builder.Entity<Destination>().ToTable("Destinations");
        builder.Entity<Destination>().HasKey(p => p.Id);
        builder.Entity<Destination>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Destination>().Property(p => p.Name).IsRequired().HasMaxLength(150);




        
        
        // tablas consignees
        builder.Entity<Consignees>().ToTable("Consignees");
        builder.Entity<Consignees>().HasKey(p => p.Id);
        builder.Entity<Consignees>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Consignees>().Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Entity<Consignees>().Property(p => p.Dni).IsRequired().HasMaxLength(8);
        builder.Entity<Consignees>().Property(p => p.Address).IsRequired().HasMaxLength(200);
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}