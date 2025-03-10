namespace TicketsB2C.users;

public interface IUsersService
{
    string Login(LoginDto loginDto);
    int Register(RegisterDto registerDto);
}