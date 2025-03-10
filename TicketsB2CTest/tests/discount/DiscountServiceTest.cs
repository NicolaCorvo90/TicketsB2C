using TicketsB2C.discounts;
using TicketsB2C.discounts.dto;

namespace TicketsB2CTest.tests.discount;

public class DiscountServiceTest
{
    [Fact]
    public void CalculateDiscountWithQuantity2AndTypeBus()
    {
        DiscountService discountService = new DiscountService();
        int totalInCentsWithDiscount = discountService.calculateDiscount(new CalculateDiscountDto
        {
            TotalInCent = 2000,
            Quantity = 2,
            Type = "Bus"
        });
        
        Assert.Equal(1940, totalInCentsWithDiscount);
    }
    
    [Fact]
    public void CalculateDiscountWithQuantity2AndTypeTrain()
    {
        DiscountService discountService = new DiscountService();
        int totalInCentsWithDiscount = discountService.calculateDiscount(new CalculateDiscountDto
        {
            TotalInCent = 2000,
            Quantity = 2,
            Type = "Train"
        });
        
        Assert.Equal(1960, totalInCentsWithDiscount);
    }
    
    [Fact]
    public void CalculateDiscountWithQuantity6AndTypeBus()
    {
        DiscountService discountService = new DiscountService();
        int totalInCentsWithDiscount = discountService.calculateDiscount(new CalculateDiscountDto
        {
            TotalInCent = 6000,
            Quantity = 6,
            Type = "Bus"
        });
        
        Assert.Equal(5529, totalInCentsWithDiscount);
    }
    
    [Fact]
    public void CalculateDiscountWithQuantity6AndTypeTrain()
    {
        DiscountService discountService = new DiscountService();
        int totalInCentsWithDiscount = discountService.calculateDiscount(new CalculateDiscountDto
        {
            TotalInCent = 6000,
            Quantity = 6,
            Type = "Train"
        });
        
        Assert.Equal(5586, totalInCentsWithDiscount);
    }
    
    [Fact]
    public void CalculateDiscountWithQuantity11AndTypeBus()
    {
        DiscountService discountService = new DiscountService();
        int totalInCentsWithDiscount = discountService.calculateDiscount(new CalculateDiscountDto
        {
            TotalInCent = 11000,
            Quantity = 11,
            Type = "Bus"
        });
        
        Assert.Equal(9603, totalInCentsWithDiscount);
    }
    
    [Fact]
    public void CalculateDiscountWithQuantity11AndTypeTrain()
    {
        DiscountService discountService = new DiscountService();
        int totalInCentsWithDiscount = discountService.calculateDiscount(new CalculateDiscountDto
        {
            TotalInCent = 11000,
            Quantity = 11,
            Type = "Train"
        });
        
        Assert.Equal(9702, totalInCentsWithDiscount);
    }
    
    [Fact]
    public void CalculateDiscountWithQuantity22AndTypeBus()
    {
        DiscountService discountService = new DiscountService();
        int totalInCentsWithDiscount = discountService.calculateDiscount(new CalculateDiscountDto
        {
            TotalInCent = 22000,
            Quantity = 22,
            Type = "Bus"
        });
        
        Assert.Equal(17072, totalInCentsWithDiscount);
    }
    
    [Fact]
    public void CalculateDiscountWithQuantity22AndTypeTrain()
    {
        DiscountService discountService = new DiscountService();
        int totalInCentsWithDiscount = discountService.calculateDiscount(new CalculateDiscountDto
        {
            TotalInCent = 22000,
            Quantity = 22,
            Type = "Train"
        });
        
        Assert.Equal(17248, totalInCentsWithDiscount);
    }
}