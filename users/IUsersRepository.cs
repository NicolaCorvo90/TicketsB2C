namespace TicketsB2C.users;

public interface IUsersRepository
{
    Users GetUserByEmail(string email);
    Users SaveUser(Users user);
}