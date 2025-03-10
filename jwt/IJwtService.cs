namespace TicketsB2C.jwt;

public interface IJwtService
{
    string GenerateToken(int id);
}