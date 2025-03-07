using Microsoft.AspNetCore.Mvc;

namespace TicketsB2C.health;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "OK";
    }
}