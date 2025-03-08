using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketsB2C.carriers;

namespace TicketsB2C.tickets;

public class Tickets
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required string DepartureCity { get; set; }

    [Required]
    public required string DestinationCity { get; set; }

    [Required]
    public required string Type { get; set; }

    [Required]
    public int PriceInCent { get; set; }

    [ForeignKey("Carrier")]
    public int CarrierId { get; set; }
    
    public Carriers? Carrier { get; set; }
}