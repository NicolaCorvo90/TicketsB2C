using TicketsB2C.carriers;
using TicketsB2C.tickets.readmodel;

namespace TicketsB2C.tickets;

public class TicketsService(ITicketsRepository ticketsRepository): ITicketsService
{
    public List<TicketsReadModel> GetTickets()
    {
        return ticketsRepository.GetTickets()
            .Select(ticket => new TicketsReadModel
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
            })
            .ToList();
    }
    
}