using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Document> Documents { get; set; }
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
        builder.Entity<Document>().ToTable("Documents");
        builder.Entity<Document>().HasKey(p => p.Id);
        builder.Entity<Document>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Document>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}