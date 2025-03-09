namespace TicketsB2C.tickets;

public interface ITicketsRepository
{
    List<Tickets> GetTickets();
    
    Tickets GetTicketById(int ticketId);
}