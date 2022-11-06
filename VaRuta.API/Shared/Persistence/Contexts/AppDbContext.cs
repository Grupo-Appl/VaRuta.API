using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Sender> Senders { get; set; }
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
        
        // Aqui otras tablas 
        builder.Entity<Sender>().ToTable("Senders");
        builder.Entity<Sender>().HasKey(p => p.id);
        builder.Entity<Sender>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Sender>().Property(p => p.name).IsRequired().HasMaxLength(100);
        builder.Entity<Sender>().Property(p => p.email).IsRequired().HasMaxLength(120);
        
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}