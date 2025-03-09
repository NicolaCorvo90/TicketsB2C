using TicketsB2C.tickets.dto;
using TicketsB2C.tickets.readmodel;

namespace TicketsB2C.tickets;

public interface ITicketsService
{ 
    List<TicketsReadModel> GetTickets();
    public List<TicketsReadModel> GetTicketsByCarrier(int carrierId);
    
    public List<TicketsReadModel> SearchTickets(TicketSearchDto ticketSearchDto);
}