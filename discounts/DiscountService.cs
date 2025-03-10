using TicketsB2C.discounts.dto;

namespace TicketsB2C.discounts;

public class DiscountService: IDiscountService
{
    public int calculateDiscount(CalculateDiscountDto calculateDiscountDto)
    {
        int totalInCentWithDiscount = calculateDiscountDto.TotalInCent;
        
        totalInCentWithDiscount = calculateDiscountBasedOnQuantity(totalInCentWithDiscount, calculateDiscountDto.Quantity);
        totalInCentWithDiscount = calculateDiscountBasedOnType(totalInCentWithDiscount, calculateDiscountDto.Type);
        
        return totalInCentWithDiscount;
    }
    
    private int calculateDiscountBasedOnQuantity(int totalInCent, int quantity)
    {
        int discountPercentage = 0;
        if (quantity is >= 5 and < 10)
        {
            discountPercentage = 5;
        }
        else if (quantity is >= 10 and < 20)
        {
            discountPercentage = 10;
        }
        else if (quantity >= 20)
        {
            discountPercentage = 20;
        }
        
        int discountInCent = totalInCent * discountPercentage / 100;
        
        return totalInCent - discountInCent;
    }

    private int calculateDiscountBasedOnType(int totalInCent, string type)
    {
        int discountPercentage = 0;
        
        switch (type)
        {
            case "Train":
                discountPercentage = 2;
                break;
            case "Bus":
                discountPercentage = 3;
                break;
        }
        
        int discountInCent = totalInCent * discountPercentage / 100;
        
        return totalInCent - discountInCent;
    }
}