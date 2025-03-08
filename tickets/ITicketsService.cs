using TicketsB2C.tickets.readmodel;

namespace TicketsB2C.tickets;

public interface ITicketsService
{ 
    List<TicketsReadModel> GetTickets();
}