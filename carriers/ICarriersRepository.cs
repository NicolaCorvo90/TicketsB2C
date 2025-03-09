namespace TicketsB2C.carriers;

public interface ICarriersRepository
{
    Carriers GetCarrierById(int id);
}