using Microsoft.EntityFrameworkCore;
using TicketsB2C.carriers;
using TicketsB2C.tickets;

namespace TicketsB2C.db;

public class MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : DbContext(options)
{
    public DbSet<Tickets> Tickets { get; set; }
    public DbSet<Carriers> Carriers { get; set; }
}