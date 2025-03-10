using Microsoft.EntityFrameworkCore;
using TicketsB2C.carriers;
using TicketsB2C.tickets;
using TicketsB2C.users;

namespace TicketsB2C.db;

public class MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : DbContext(options)
{
    public DbSet<Carriers> Carriers { get; set; }
    public DbSet<Tickets> Tickets { get; set; }
    public DbSet<Users> Users { get; set; }
}