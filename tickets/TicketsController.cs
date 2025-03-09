using Microsoft.AspNetCore.Mvc;
using TicketsB2C.tickets.dto;
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
    
    [HttpGet("SearchTickets")]
    public ActionResult<List<TicketsReadModel>> SearchTickets([FromQuery] TicketSearchDto ticketSearchDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return ticketsService.SearchTickets(ticketSearchDto);
    }
    
    [HttpPost("BuyTicket")]
    public ActionResult<BuyTicketReadModel> BuyTicket([FromBody] BuyTicketDto buyTicketDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return ticketsService.BuyTicket(buyTicketDto);
    }
}