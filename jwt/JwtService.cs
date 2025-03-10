using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace TicketsB2C.jwt;

public class JwtService: IJwtService
{

    private string jwtSecret;
    
    public JwtService()
    {
        jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");

        if (string.IsNullOrEmpty(jwtSecret))
        {
            throw new BadHttpRequestException("JWT_SECRET is not set.");
        }
    }
    
    public string GenerateToken(int id)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(jwtSecret);
        SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), SecurityAlgorithms.HmacSha256);
        
        SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Sid, id.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = signingCredentials,
        };
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        return jwtSecurityTokenHandler.WriteToken(securityToken);
    }
}