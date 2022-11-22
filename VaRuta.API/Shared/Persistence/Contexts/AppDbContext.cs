using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Publishing.Domain;
using VaRuta.API.Profiles.Domain.Models;
using VaRuta.API.Routing.Domain.Models;
using VaRuta.API.Shared.Extensions;
using VaRuta.API.Tracking.Domain.Models;

namespace VaRuta.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Destination> Destinations { get; set; }

    public DbSet<Sender> Senders { get; set; }



    public DbSet<Document> Documents { get; set; }

    public DbSet<Shipment> Shipments { get; set; }
    
    public DbSet<TypeOfPackage> TypeOfPackages { get; set; }


    
    public DbSet<TypeOfComplaint> TypeOfComplaint { get; set; }
    
    public DbSet<Consignees> Consignees { get; set; }

    public DbSet<Freight>Freights { get; set; }


    public DbSet<Feedback>Feedbacks { get; set; }
    public DbSet<Consignees> Consignees { get; set; }

    public DbSet<Enterprise> Enterprises { get; set; }
    
    public DbSet<Delivery> Deliveries { get; set; }
    
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
        

        
        // configuracion de tabla tipo de paquete
        builder.Entity<TypeOfPackage>().ToTable("TypeOfPackages");
        builder.Entity<TypeOfPackage>().HasKey(p => p.Id);
        builder.Entity<TypeOfPackage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TypeOfPackage>().Property(p => p.Name).IsRequired().HasMaxLength(150);
        
        //configuracion de tabla tipo de reclamo
        builder.Entity<TypeOfComplaint>().ToTable("TypeOfComplaint");
        builder.Entity<TypeOfComplaint>().HasKey(p => p.Id);
        builder.Entity<TypeOfComplaint>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TypeOfComplaint>().Property(p => p.Name).IsRequired().HasMaxLength(150);

        // configuracion de tabla tipo de Documents

        builder.Entity<Document>().ToTable("Documents");
        builder.Entity<Document>().HasKey(p => p.Id);
        builder.Entity<Document>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Document>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        
        // configuracion de tabla feedback
        builder.Entity<Feedback>().ToTable("Feedbacks");
        builder.Entity<Feedback>().HasKey(p => p.Id);
        builder.Entity<Feedback>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Feedback>().Property(p => p.Description).IsRequired().HasMaxLength(500);
        
        // // configuracion de tabla flete
        builder.Entity<Freight>().ToTable("Freight");
        builder.Entity<Freight>().HasKey(p => p.Id);
        builder.Entity<Freight>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Freight>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Freight>().Property(p => p.Type).IsRequired().HasMaxLength(50);

        // configuracion de tabla Shipments
        builder.Entity<Shipment>().ToTable("Shipments");
        builder.Entity<Shipment>().HasKey(p => p.Id);
        builder.Entity<Shipment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Shipment>().Property(p => p.Description).IsRequired().HasMaxLength(150);
        
        // tablas consignees
        builder.Entity<Consignees>().ToTable("Consignees");
        builder.Entity<Consignees>().HasKey(p => p.Id);
        builder.Entity<Consignees>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Consignees>().Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Entity<Consignees>().Property(p => p.Dni).IsRequired().HasMaxLength(8);
        builder.Entity<Consignees>().Property(p => p.Address).IsRequired().HasMaxLength(200);

        builder.Entity<Destination>()
            .HasMany(p => p.Shipments)
            .WithOne(p => p.Destination)
            .HasForeignKey(p => p.DestinyId);
        

        

        

        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}