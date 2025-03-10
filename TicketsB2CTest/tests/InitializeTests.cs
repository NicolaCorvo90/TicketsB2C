using Microsoft.EntityFrameworkCore;
using TicketsB2C.carriers;
using TicketsB2C.db;
using TicketsB2C.tickets;
using TicketsB2C.users;

namespace TicketsB2CTest.tests;

public class InitializeTests: IDisposable
{
    private readonly MsSqlDbContext _context;

    public InitializeTests()
    {
        DotNetEnv.Env.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
            ".env.test"));
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        var optionsBuilder = new DbContextOptionsBuilder<MsSqlDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        _context = new MsSqlDbContext(optionsBuilder.Options);

        CleanDb();
        CreateUsers();
        CreateCarriers();
        CreateTickets();
    }

    public void Dispose()
    {
        
    }

    private void CleanDb()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
    
    private void CreateUsers()
    {
        _context.Users.Add(new Users { Email = "test@test.com", Password = BCrypt.Net.BCrypt.HashPassword("test") });
        _context.SaveChanges();
    }
    
    private void CreateCarriers()
    {
        _context.Carriers.Add(new Carriers { Name = "Trenitalia" });
        _context.Carriers.Add(new Carriers { Name = "Flixbus" });
        _context.SaveChanges();
    }

    private void CreateTickets()
    {
        Carriers trenitaliaCarrier = _context.Carriers.Where(carriers => carriers.Name == "Trenitalia").FirstOrDefault();
        Carriers flixbusCarrier = _context.Carriers.Where(carriers => carriers.Name == "Flixbus").FirstOrDefault();
        
        _context.Tickets.Add(new Tickets
        {
            DepartureCity = "Roma",
            DestinationCity = "Napoli",
            Type = "Bus",
            PriceInCent = 1500,
            CarrierId = flixbusCarrier.Id
        });
        _context.Tickets.Add(new Tickets
        {
            DepartureCity = "Roma",
            DestinationCity = "Napoli",
            Type = "Train",
            PriceInCent = 2000,
            CarrierId = trenitaliaCarrier.Id
        });
        _context.Tickets.Add(new Tickets
        {
            DepartureCity = "Milano",
            DestinationCity = "Torino",
            Type = "Bus",
            PriceInCent = 1000,
            CarrierId = flixbusCarrier.Id
        });
        _context.Tickets.Add(new Tickets
        {
            DepartureCity = "Firenze",
            DestinationCity = "Bologna",
            Type = "Bus",
            PriceInCent = 1250,
            CarrierId = flixbusCarrier.Id
        });
        _context.Tickets.Add(new Tickets
        {
            DepartureCity = "Roma",
            DestinationCity = "Firenze",
            Type = "Train",
            PriceInCent = 2500,
            CarrierId = trenitaliaCarrier.Id
        });
        _context.Tickets.Add(new Tickets
        {
            DepartureCity = "Milano",
            DestinationCity = "Venezia",
            Type = "Train",
            PriceInCent = 3000,
            CarrierId = trenitaliaCarrier.Id
        });
        _context.Tickets.Add(new Tickets
        {
            DepartureCity = "Napoli",
            DestinationCity = "Bari",
            Type = "Train",
            PriceInCent = 2000,
            CarrierId = trenitaliaCarrier.Id
        });
        _context.SaveChanges();
    }
}