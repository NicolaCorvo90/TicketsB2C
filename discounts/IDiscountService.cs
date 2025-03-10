using TicketsB2C.discounts.dto;

namespace TicketsB2C.discounts;

public interface IDiscountService
{
    public int calculateDiscount(CalculateDiscountDto calculateDiscountDto);
}