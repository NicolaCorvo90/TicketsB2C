using Microsoft.AspNetCore.Mvc;
using TicketsB2C.tickets.readmodel;

namespace TicketsB2C.tickets;

[ApiController]
[Route("tickets")]
public class TicketsController(ITicketsService ticketsService): ControllerBase
{
    [HttpGet("GetTickets")]
    public List<TicketsReadModel> GetTickets()
    {
        return ticketsService.GetTickets();
    }
    
    [HttpGet("GetTicketsByCarrier/{carrierId}")]
    public List<TicketsReadModel> GetTicketsByCarrier(int carrierId)
    {
        return ticketsService.GetTicketsByCarrier(carrierId);
    }
}