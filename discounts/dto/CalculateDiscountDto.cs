
namespace TicketsB2C.discounts.dto;

public class CalculateDiscountDto
{
    public required int TotalInCent { get; set; }
    public required int Quantity { get; set; }
    public required string Type { get; set; }
}