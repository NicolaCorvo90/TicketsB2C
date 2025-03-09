using TicketsB2C.db;

namespace TicketsB2C.carriers;

public class CarriersRepository(MsSqlDbContext context): ICarriersRepository
{
    public Carriers GetCarrierById(int id)
    {
        return context.Carriers.FirstOrDefault(carrier => carrier.Id == id);
    }
}