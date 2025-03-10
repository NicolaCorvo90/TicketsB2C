using TicketsB2C.db;

namespace TicketsB2C.users;

public class UsersRepository(MsSqlDbContext context): IUsersRepository
{
    public Users GetUserByEmail(string email)
    {
        return context.Users.FirstOrDefault(user => user.Email == email);
    }
    
    public Users SaveUser(Users user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
}