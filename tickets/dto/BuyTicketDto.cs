using System.ComponentModel.DataAnnotations;

namespace TicketsB2C.tickets.dto;

public class BuyTicketDto
{
    [Required(ErrorMessage = "TicketId is required.")]
    public required int TicketId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    public required int Quantity { get; set; }
}