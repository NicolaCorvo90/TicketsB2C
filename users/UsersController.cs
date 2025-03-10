using Microsoft.AspNetCore.Mvc;

namespace TicketsB2C.users;

[ApiController]
[Route("users")]
public class UsersController(IUsersService usersService): ControllerBase
{
    [HttpPost("login")]
    public ActionResult<string> BuyTicket([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return usersService.Login(loginDto);
    }
    
    [HttpPost("register")]
    public ActionResult<int> BuyTicket([FromBody] RegisterDto registerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return usersService.Register(registerDto);
    }
}