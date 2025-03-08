using TicketsB2C.carriers;

namespace TicketsB2C.tickets.readmodel;

public class TicketsReadModel
{
    public int Id { get; set; }
    public required string DepartureCity { get; set; }
    public required string DestinationCity { get; set; }
    public required string Type { get; set; }
    public int PriceInCent { get; set; }
    public CarriersReadModel? Carrier { get; set; }
}