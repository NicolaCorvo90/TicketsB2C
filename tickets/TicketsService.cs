using TicketsB2C.carriers;
using TicketsB2C.tickets.dto;
using TicketsB2C.tickets.readmodel;

namespace TicketsB2C.tickets;

public class TicketsService(ITicketsRepository ticketsRepository, ICarriersRepository carriersRepository): ITicketsService
{
    public List<TicketsReadModel> GetTickets()
    {
        return ticketsRepository.GetTickets()
            .Select(MapToReadModel)
            .ToList();
    }

    public List<TicketsReadModel> GetTicketsByCarrier(int carrierId)
    {
        if (carriersRepository.GetCarrierById(carrierId) == null)
        {
            throw new BadHttpRequestException("Carrier not found.");
        }
        
        return ticketsRepository.GetTickets()
            .Where(ticket => ticket.CarrierId == carrierId)
            .Select(MapToReadModel)
            .ToList();
    }
    
    public List<TicketsReadModel> SearchTickets(TicketSearchDto ticketSearchDto)
    {
        return ticketsRepository.GetTickets()
            .Where(ticket => ticket.DepartureCity == ticketSearchDto.DepartureCity && ticket.DestinationCity == ticketSearchDto.DestinationCity)
            .Select(MapToReadModel)
            .ToList();
    }

    public BuyTicketReadModel BuyTicket(BuyTicketDto buyTicketDto)
    {
        Tickets ticket = ticketsRepository.GetTicketById(buyTicketDto.TicketId);
        
        if(ticket == null)
        {
            throw new BadHttpRequestException("Ticket not found.");
        }
        
        int totalInCent = ticket.PriceInCent * buyTicketDto.Quantity;
        
        return new BuyTicketReadModel { TotalInCent = totalInCent };
    }
    
    private TicketsReadModel MapToReadModel(Tickets ticket)
    {
        return new TicketsReadModel
        {
            Id = ticket.Id,
            DepartureCity = ticket.DepartureCity,
            DestinationCity = ticket.DestinationCity,
            Type = ticket.Type,
            PriceInCent = ticket.PriceInCent,
            Carrier = ticket.Carrier != null ? new CarriersReadModel
            {
                Id = ticket.Carrier.Id,
                Name = ticket.Carrier.Name
            } : null
        };
    }
}