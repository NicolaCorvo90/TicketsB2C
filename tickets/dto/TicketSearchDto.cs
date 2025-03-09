using System.ComponentModel.DataAnnotations;

namespace TicketsB2C.tickets.dto;

public class TicketSearchDto
{
    [Required(ErrorMessage = "DepartureCity is required.")]
    public required string DepartureCity { get; set; }

    [Required(ErrorMessage = "DestinationCity is required.")]
    public required string DestinationCity { get; set; }
}