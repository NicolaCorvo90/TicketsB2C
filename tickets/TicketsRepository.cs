using Microsoft.EntityFrameworkCore;
using TicketsB2C.db;

namespace TicketsB2C.tickets;

public class TicketsRepository(MsSqlDbContext context): ITicketsRepository
{
    
    public List<Tickets> GetTickets()
    {
        return context.Tickets
            .Include(ticket => ticket.Carrier)
            .ToList();
    }

    public Tickets GetTicketById(int id)
    {
        return context.Tickets.First(ticket => ticket.Id == id);
    }
}