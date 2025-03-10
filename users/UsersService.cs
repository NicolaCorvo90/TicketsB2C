using TicketsB2C.jwt;

namespace TicketsB2C.users;

public class UsersService(IUsersRepository usersRepository, IJwtService jwtService) : IUsersService
{
    public string Login(LoginDto loginDto)
    {
        Users user = usersRepository.GetUserByEmail(loginDto.Email);
        
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
        {
            throw new BadHttpRequestException("User not found.");
        }

        return jwtService.GenerateToken(user.Id);
    }

    public int Register(RegisterDto registerDto)
    {
        registerDto.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        
        Users user = new Users
        {
            Email = registerDto.Email,
            Password = registerDto.Password
        };
        
        user = usersRepository.SaveUser(user);

        return user.Id;
    }
}