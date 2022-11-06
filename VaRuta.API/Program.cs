using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Persistence.Repositories;
using VaRuta.API.Booking.Services;
using VaRuta.API.Routing.Domain.Repositories;
using VaRuta.API.Routing.Domain.Services;
using VaRuta.API.Routing.Persistence.Repositories;
using VaRuta.API.Routing.Services;
using VaRuta.API.Shared.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Lowercase URLs configuration (PASAR A MINUSCULAS)
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learning Bounded Context Injection Configuration **agregar otros tablas
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IDestinationService, DestinationService>();

builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();

builder.Services.AddScoped<IConsigneesRepository, ConsigneeRepository>();
builder.Services.AddScoped<IConsigneesService, ConsigneesService>();


builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<ITypeOfPackageRepository, TypeOfPackageRepository>();
builder.Services.AddScoped<ITypeOfPackageService, TypeOfPackageService>();
// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(VaRuta.API.Booking.Mapping.ResourceToModelProfile),
    typeof(VaRuta.API.Booking.Mapping.ModelToResourceProfile),
    typeof(VaRuta.API.Routing.Mapping.ResourceToModelProfile),
    typeof(VaRuta.API.Routing.Mapping.ModelToResourceProfile)
    );

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();